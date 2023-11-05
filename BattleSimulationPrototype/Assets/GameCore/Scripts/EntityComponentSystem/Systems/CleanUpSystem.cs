using Unity.Burst;
using Unity.Entities;
using UnityEngine;

[UpdateInGroup(typeof(SimulationSystemGroup),OrderFirst =true)]
[BurstCompile]
public partial struct CleanUpSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {

    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {

    }
    
    public void OnUpdate(ref SystemState state)
    {
        EntityCommandBuffer commandBuffer = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);

        foreach (var (cleanUp, entity) in SystemAPI.Query<CleanUpTag>().WithEntityAccess())
        {
            commandBuffer.DestroyEntity(entity);
        }
    }

}
