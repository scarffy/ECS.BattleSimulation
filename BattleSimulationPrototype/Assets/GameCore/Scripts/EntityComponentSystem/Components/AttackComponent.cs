using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public struct AttackComponent : IComponentData
{
    public float AttackDamage;
    public float AttackSpeed;
    public float CoolDown;
}
