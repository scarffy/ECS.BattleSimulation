using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

[UpdateInGroup(typeof(SimulationSystemGroup))]
[UpdateAfter(typeof(FixedTickSimulationSystemGroup))]
public partial class NormalTickSimulationSystemGroup : ComponentSystemGroup
{
    protected override void OnUpdate()
    {
        if (!SystemAPI.HasSingleton<SystemTickTrackerComponent>())
            return;
        RefRW<SystemTickTrackerComponent> systemTickTrackerComponent = SystemAPI.GetSingletonRW<SystemTickTrackerComponent>();
        systemTickTrackerComponent.ValueRW.NormalTickDeltaTime = SystemAPI.Time.DeltaTime;

        base.OnUpdate();
    }
}
