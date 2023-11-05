using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public struct SystemTickTrackerComponent : IComponentData
{
    public float FixedTickDeltaTime;
    public float NormalTickDeltaTime;
    public uint FixedStepCount;
}
