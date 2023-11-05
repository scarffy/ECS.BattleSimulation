using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.Rendering;

[UpdateInGroup(typeof(NormalTickSimulationSystemGroup))]
[BurstCompile]
public partial struct DamageDealerSystem : ISystem
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
        EntityCommandBuffer commandBuffer = SystemAPI.GetSingleton<EndNormalTickSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
        SystemTickTrackerComponent systemTickTrackerComponent = SystemAPI.GetSingleton<SystemTickTrackerComponent>();
        float deltaTime = systemTickTrackerComponent.NormalTickDeltaTime;

        new DamageDealerJob
        {
            deltaTime= deltaTime,
            localTransformLookUp=SystemAPI.GetComponentLookup<LocalTransform>(),
            ecbp= commandBuffer.AsParallelWriter()
        }.ScheduleParallel(state.Dependency).Complete();

        new DamageJob
        {
            
        }.ScheduleParallel(state.Dependency).Complete();

    }

    [BurstCompile]
    public partial struct DamageDealerJob : IJobEntity
    {
        public float deltaTime;
        [ReadOnly]
        public ComponentLookup<LocalTransform> localTransformLookUp;
        public EntityCommandBuffer.ParallelWriter ecbp;
        [BurstCompile]
        public void Execute([EntityIndexInQuery] int sortKey,RefRW<AttackComponent> _attackComponent, RefRO<TargetComponent> _target, RefRO<RangeComponent> _range, RefRO<LocalTransform> _transform, IsValidTag isValidTag)
        {
            if(_attackComponent.ValueRO.CoolDown<=0)
            {
                _attackComponent.ValueRW.CoolDown = 1.0f / _attackComponent.ValueRO.AttackSpeed;
                if(localTransformLookUp.TryGetComponent(_target.ValueRO.TargetEntity,out LocalTransform componentData))
                {                    
                    if (math.length(componentData.Position- _transform.ValueRO.Position)<= _range.ValueRO.Value)
                    {
                        ecbp.AppendToBuffer<DamageBuffer>(sortKey, _target.ValueRO.TargetEntity, new DamageBuffer { Value = _attackComponent.ValueRO.AttackDamage });
                    }
                }
                
            }
            else
            {
                _attackComponent.ValueRW.CoolDown -= deltaTime;
            } 
        }
    }


    [BurstCompile]
    public partial struct DamageJob : IJobEntity
    {
        [BurstCompile]
        public void Execute(DynamicBuffer<DamageBuffer> _damageBuffer, RefRW<HealthComponent> _health, IsValidTag isValidTag)
        {
            foreach(DamageBuffer damageBuffer in _damageBuffer)
            {
                _health.ValueRW.Value -= damageBuffer.Value;
            }

            _damageBuffer.Clear();
        }
    }

}
