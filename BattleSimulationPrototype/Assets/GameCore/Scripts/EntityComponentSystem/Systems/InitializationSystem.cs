using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using static UnityEngine.UI.Image;

[UpdateInGroup(typeof(InitializationSystemGroup))]
[BurstCompile]
public partial struct InitializationSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<SystemTickTrackerComponent>();
        Entity entity = state.EntityManager.CreateEntity();
        state.EntityManager.AddComponent<SystemTickTrackerComponent>(entity);
        state.EntityManager.AddComponentData<RandomComponent>(entity,new RandomComponent { random=new Random(999) });

    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {

    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        
    }
}
