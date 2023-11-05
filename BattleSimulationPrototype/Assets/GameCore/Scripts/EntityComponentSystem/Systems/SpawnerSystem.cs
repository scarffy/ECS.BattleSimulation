using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[UpdateInGroup(typeof(FixedTickSimulationSystemGroup))]
[BurstCompile]
public partial struct SpawnerSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<SystemTickTrackerComponent>();
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {

    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        SystemTickTrackerComponent systemTickTrackerComponent = SystemAPI.GetSingleton<SystemTickTrackerComponent>();
        EntityCommandBuffer commandBuffer = SystemAPI.GetSingleton<BeginFixedTickSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
        new SpawnerJob
        {
            deltaTime= systemTickTrackerComponent.FixedTickDeltaTime,
            ecbp = commandBuffer.AsParallelWriter()
        }.ScheduleParallel();
    }

    [BurstCompile]
    public partial struct SpawnerJob : IJobEntity
    {
        public float deltaTime;
        public EntityCommandBuffer.ParallelWriter ecbp;

        [BurstCompile]
        public void Execute([EntityIndexInQuery] int sortKey,Entity entity, RefRW<SpawnComponent> _spawnerComponent)
        {
            if(_spawnerComponent.ValueRO.gobject==Entity.Null)
            {
                ecbp.DestroyEntity(sortKey, entity);
                return;
            }

            Entity spawnedentity = ecbp.Instantiate(sortKey, _spawnerComponent.ValueRO.gobject);

            if (_spawnerComponent.ValueRO.localTransform != Entity.Null)
            {
                ecbp.AddComponent(sortKey, spawnedentity, new Parent { Value = _spawnerComponent.ValueRO.localTransform });
                DynamicBuffer<LinkedEntityGroup> group = ecbp.AddBuffer<LinkedEntityGroup>(sortKey, _spawnerComponent.ValueRO.localTransform);
                group.Add(_spawnerComponent.ValueRO.localTransform);  // Always add self as first member of group.
                group.Add(spawnedentity);
            }
            ecbp.AddComponent(sortKey, spawnedentity, new SpawnedTag { });
            ecbp.AddComponent(sortKey, spawnedentity, new IsValidTag { });
            ecbp.SetComponent(sortKey, spawnedentity, new LocalTransform { Position = _spawnerComponent.ValueRO.Position, Scale = 1, Rotation = new quaternion() });

            switch(_spawnerComponent.ValueRO.spawnType)
            {
                case SpawnType.PLAYER:
                    ecbp.AddComponent(sortKey, spawnedentity, new PlayerTag { });
                    break;
                case SpawnType.ENEMY:
                    ecbp.AddComponent(sortKey, spawnedentity, new EnemyTag { });
                    break;
                case SpawnType.GRID:
                    ecbp.AddComponent(sortKey, spawnedentity, new GridTag { });
                    break;
            }

            ecbp.DestroyEntity(sortKey, entity);
        }
    }

}
