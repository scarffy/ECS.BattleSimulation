using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[UpdateInGroup(typeof(NormalTickSimulationSystemGroup))]
[BurstCompile]
public partial struct MovementSystem : ISystem
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
        float deltaTime = systemTickTrackerComponent.NormalTickDeltaTime;

        new MovementDirectionProviderJob
        {
            localTransformLookUp=SystemAPI.GetComponentLookup<LocalTransform>()
        }.ScheduleParallel(state.Dependency).Complete();

        new MovementJob
        {
            deltaTime = deltaTime
        }.ScheduleParallel(state.Dependency).Complete();


        new LookTowardsMovementJob
        {
            
        }.ScheduleParallel(state.Dependency).Complete();

    }

    [BurstCompile]
    public partial struct MovementDirectionProviderJob : IJobEntity
    {
        [ReadOnly]
        public ComponentLookup<LocalTransform> localTransformLookUp;
        [BurstCompile]
        public void Execute(RefRW<MovementComponent> _movement, RefRW<TargetComponent> _target, RefRO<RangeComponent> _range, RefRO<LocalTransform> _transform, IsValidTag isValidTag)
        {
            if(localTransformLookUp.TryGetComponent(_target.ValueRO.TargetEntity,out LocalTransform componentData))
            {
                float3 Direction = componentData.Position - _transform.ValueRO.Position;

                if(math.length(Direction)<_range.ValueRO.Value)
                {
                    Direction = float3.zero;
                }
                else
                {
                    Direction = math.normalize(Direction);
                    Direction.y = 0;
                }
                
                _movement.ValueRW.Direction = Direction;
            }            
        }
    }


    [BurstCompile]
    public partial struct MovementJob : IJobEntity
    {
        public float deltaTime;

        [BurstCompile]
        public void Execute(RefRO<MovementComponent> _movement,RefRO<SpeedComponent> _speed, RefRW<LocalTransform> _transform,IsValidTag isValidTag)
        {
            _transform.ValueRW.Position += _movement.ValueRO.Direction * _speed.ValueRO.Value * deltaTime;
        }
    }

    [BurstCompile]
    public partial struct LookTowardsMovementJob : IJobEntity
    {
        [BurstCompile]
        public void Execute([EntityIndexInQuery] int sortKey, RefRO<MovementComponent> _movement,RefRW<LocalTransform> _localTransform, IsValidTag isValidTag)
        {
            if(math.lengthsq(_movement.ValueRO.Direction)>0)
                _localTransform.ValueRW.Rotation = quaternion.LookRotation(math.lerp(_localTransform.ValueRO.Forward(),math.normalize(_movement.ValueRO.Direction),0.25f), math.up());
        }
    }

}
