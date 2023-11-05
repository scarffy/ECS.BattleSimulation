using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public struct TargetComponent : IComponentData
{
    public Entity TargetEntity;
}
