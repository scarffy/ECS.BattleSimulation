using Unity.Entities;

[UpdateInGroup(typeof(SimulationSystemGroup))]
public partial class FixedTickSimulationSystemGroup : ComponentSystemGroup
{
    float FixedDeltaTime = 0.125f;
    double ElapsedTime;

    protected override void OnCreate()
    {
        base.OnCreate();
        ElapsedTime = SystemAPI.Time.ElapsedTime;
    }
    protected override void OnUpdate()
    {
        if (!SystemAPI.HasSingleton<SystemTickTrackerComponent>())
            return;

        if (SystemAPI.Time.ElapsedTime < ElapsedTime)
            return;

        RefRW<SystemTickTrackerComponent> systemTickTrackerComponent= SystemAPI.GetSingletonRW<SystemTickTrackerComponent>();
        systemTickTrackerComponent.ValueRW.FixedStepCount++;
        systemTickTrackerComponent.ValueRW.FixedTickDeltaTime = FixedDeltaTime;
        ElapsedTime += FixedDeltaTime;

        base.OnUpdate();
    }
}
