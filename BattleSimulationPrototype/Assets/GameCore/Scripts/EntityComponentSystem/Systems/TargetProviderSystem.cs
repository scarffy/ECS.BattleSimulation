using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine.UIElements;
using static MovementSystem;

[UpdateInGroup(typeof(NormalTickSimulationSystemGroup))]
[BurstCompile]
public partial struct TargetProviderSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<RandomComponent>();
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {

    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {

        NativeList<Entity> PlayerUnitList = new NativeList<Entity>(Allocator.Persistent);
        NativeList<Entity> EnemyUnitList = new NativeList<Entity>(Allocator.Persistent);

        foreach ((RefRO<PlayerTag> _Tag, Entity entity) in SystemAPI.Query<RefRO<PlayerTag>>().WithEntityAccess())
        {
            PlayerUnitList.Add(entity);
        }

        foreach ((RefRO<EnemyTag> _Tag, Entity entity) in SystemAPI.Query<RefRO<EnemyTag>>().WithEntityAccess())
        {
            EnemyUnitList.Add(entity);
        }

        var random = SystemAPI.GetSingletonRW<RandomComponent>();

        int offset = random.ValueRW.random.NextInt();
        var IsValidLookUp = SystemAPI.GetComponentLookup<Simulate>();
        new TargetProviderToPlayerJob
        {
            IsValidLookUp= IsValidLookUp,
            offset = offset,
            PotentialTargetUnitList = EnemyUnitList
        }.ScheduleParallel(state.Dependency).Complete();

        offset = random.ValueRW.random.NextInt();

        new TargetProviderToEnemyJob
        {
            IsValidLookUp = IsValidLookUp,
            offset = offset,
            PotentialTargetUnitList = PlayerUnitList
        }.ScheduleParallel(state.Dependency).Complete();

        PlayerUnitList.Dispose();
        EnemyUnitList.Dispose();
    }

    [BurstCompile]
    public partial struct TargetProviderToPlayerJob : IJobEntity
    {
        public int offset;
        [ReadOnly]
        public ComponentLookup<Simulate> IsValidLookUp;
        [ReadOnly]
        public NativeList<Entity> PotentialTargetUnitList;
        [BurstCompile]
        public void Execute([EntityIndexInQuery] int sortKey, RefRW<TargetComponent> _target,RefRO<PlayerTag> _Tag, IsReadyTag isReadyTag, IsValidTag isValidTag)
        {
            int count = offset + sortKey;

            count = math.abs(count);

            if (IsValidLookUp.TryGetComponent(_target.ValueRW.TargetEntity, out Simulate componentData))
            {

            }
            else
            {
                if (PotentialTargetUnitList.Length > 0)
                {
                    _target.ValueRW.TargetEntity = PotentialTargetUnitList[count % PotentialTargetUnitList.Length];
                }
            }
        }
    }

    [BurstCompile]
    public partial struct TargetProviderToEnemyJob : IJobEntity
    {
        public int offset;
        [ReadOnly]
        public ComponentLookup<Simulate> IsValidLookUp;
        [ReadOnly]
        public NativeList<Entity> PotentialTargetUnitList;
        [BurstCompile]
        public void Execute([EntityIndexInQuery] int sortKey,RefRW<TargetComponent> _target, RefRO<EnemyTag> _Tag,IsReadyTag isReadyTag, IsValidTag isValidTag)
        {

            int count = offset + sortKey;
            count = math.abs(count);
            if (IsValidLookUp.TryGetComponent(_target.ValueRW.TargetEntity,out Simulate componentData))
            {

            }
            else
            {
                if (PotentialTargetUnitList.Length > 0)
                {
                    _target.ValueRW.TargetEntity = PotentialTargetUnitList[count % PotentialTargetUnitList.Length];
                }
            }            
        }
    }
}
