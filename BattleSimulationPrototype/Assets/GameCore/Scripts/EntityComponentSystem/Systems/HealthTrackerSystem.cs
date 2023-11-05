using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

[UpdateInGroup(typeof(NormalTickSimulationSystemGroup))]
[BurstCompile]
public partial struct HealthTrackerSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {

    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {

    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        EntityCommandBuffer commandBuffer = SystemAPI.GetSingleton<EndNormalTickSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);

        HealthTrackingJob healthTrackingJob = new HealthTrackingJob
        {
            ecbp = commandBuffer.AsParallelWriter(),
        };
        healthTrackingJob.ScheduleParallel(state.Dependency).Complete();

    }

    [BurstCompile]
    public partial struct HealthTrackingJob : IJobEntity
    {
        public EntityCommandBuffer.ParallelWriter ecbp;
        [BurstCompile]
        public void Execute([EntityIndexInQuery] int sortKey, Entity entity, RefRO<HealthComponent> _health, RefRO<IsValidTag> _isvalid)
        {
            if(_health.ValueRO.Value<=0)
            {
                ecbp.RemoveComponent<IsValidTag>(sortKey,entity);
                ecbp.AddComponent(sortKey,entity,new CleanUpTag { });
            }           
        }
    }
}
