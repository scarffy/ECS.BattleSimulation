using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Entities.UniversalDelegates;
using UnityEngine;

public class UnitDataAuthoring : MonoBehaviour
{
    public UnitData UnitData;

    class Baker : Baker<UnitDataAuthoring>
    {
        public override void Bake(UnitDataAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new HealthComponent
            {
                Value = authoring.UnitData.Health
            });
            AddComponent(entity, new SpeedComponent
            {
                Value = authoring.UnitData.MovementSpeed
            });
            AddComponent(entity, new AttackComponent
            {
                AttackDamage = authoring.UnitData.AttackDamage,
                AttackSpeed = authoring.UnitData.AttackSpeed
            });
            AddComponent(entity, new RangeComponent
            {
                Value = authoring.UnitData.AttackRange
            });
            AddComponent(entity, new MovementComponent
            {

            });
            AddComponent(entity, new TargetComponent
            {
                TargetEntity=Entity.Null
            });
            AddComponent(entity, new UnitTag
            {

            });
            AddBuffer<DamageBuffer>(entity);
        }
    }
}
