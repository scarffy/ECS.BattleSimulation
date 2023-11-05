using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using static SpawnerSystem;

[UpdateInGroup(typeof(NormalTickSimulationSystemGroup))]
[UpdateBefore(typeof(UnitSpawnerSystem))]
[BurstCompile]
public partial struct GridProcessingSystem : ISystem
{
    
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<SystemTickTrackerComponent>();
        state.RequireForUpdate<GridComponent>();
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {

    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        EntityCommandBuffer commandBuffer = SystemAPI.GetSingleton<EndNormalTickSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);

        bool IsSelected = false;

        foreach (var gridComponent in SystemAPI.Query<RefRW<GridComponent>>())
        {
            if (!gridComponent.ValueRO.Processed)
            {
                for (int i = 0; i < gridComponent.ValueRO.GridSize.x; i++)
                {
                    for (int j = 0; j < gridComponent.ValueRO.GridSize.y; j++)
                    {
                        if (gridComponent.ValueRO.TileEntity != Entity.Null)
                        {
                            var entity = commandBuffer.CreateEntity();
                            commandBuffer.AddComponent(entity, new SpawnComponent { spawnType=SpawnType.GRID,gobject = gridComponent.ValueRO.TileEntity, Position = gridComponent.ValueRO.GetCellPosition((uint)i, (uint)j) });
                        }
                    }
                }
                gridComponent.ValueRW.Processed = true;
            }

            if (!IsSelected)
                new GridSelectorJob
                {
                    grid = gridComponent.ValueRO
                }.ScheduleParallel(state.Dependency).Complete();


            if(gridComponent.ValueRO.IsSelected())
            {
                IsSelected = true;
            }

            if(gridComponent.ValueRO.CleanUp)
            {
                new GridClearJob
                {
                   ecbp= commandBuffer.AsParallelWriter()
                }.ScheduleParallel(state.Dependency).Complete();
            }

            DynamicBuffer<DynamicGridCellItem> gridCells = state.EntityManager.GetBuffer<DynamicGridCellItem>(gridComponent.ValueRO.entity);

            for (int i = 0; i < gridCells.Length; i++)
            {
                gridCells[i] = new DynamicGridCellItem { entity = Entity.Null };
            }

            new GridCellCheckerJob
            {
                gridCells = gridCells,
                grid = gridComponent.ValueRO
            }.Schedule(state.Dependency).Complete();

            int occupiedUNit = 0;

            for (int i = 0; i < gridCells.Length; i++)
            {
                if(gridCells[i].entity!=Entity.Null)
                {
                    occupiedUNit++;
                }
            }

            gridComponent.ValueRW.TotalUnit = occupiedUNit;

        }

        

    }


    [BurstCompile]
    public partial struct GridSelectorJob : IJobEntity
    {
        [ReadOnly]
        public GridComponent grid;

        [BurstCompile]
        public void Execute(RefRO<GridSelectorTag> _tag, RefRW<LocalTransform> _transform)
        {
            _transform.ValueRW.Position = grid.GetCellPosition(grid.SelectedCell);
        }
    }

    [BurstCompile]
    public partial struct GridClearJob : IJobEntity
    {
        public EntityCommandBuffer.ParallelWriter ecbp;
        [BurstCompile]
        public void Execute([EntityIndexInQuery] int sortKey, Entity entity, RefRO<GridTag> _tag)
        {
            ecbp.DestroyEntity(sortKey, entity);
        }
    }

    [BurstCompile]
    public partial struct GridCellCheckerJob : IJobEntity
    {
        public DynamicBuffer<DynamicGridCellItem> gridCells;
        public GridComponent grid;

        [BurstCompile]
        public void Execute(Entity entity, RefRO<UnitTag> _Tag, RefRO<LocalTransform> _transform)
        {
            int index = grid.GetBufferIndex(_transform.ValueRO.Position);
            if(index>=0)
                gridCells[index] = new DynamicGridCellItem { entity = entity };
        }
    }
}
