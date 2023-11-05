using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class GameUnitListAuthoring : MonoBehaviour
{
    public List<UnitData> UnitList;

    class Baker : Baker<GameUnitListAuthoring>
    {
        public override void Bake(GameUnitListAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            CustomFixedList16<UnitEntityData> TempUnitLists = new CustomFixedList16<UnitEntityData>();

            for (int i = 0; i < authoring.UnitList.Count; i++)
            {
                Entity tempentity = GetEntity(authoring.UnitList[i].Prefab, TransformUsageFlags.Dynamic);
                TempUnitLists.Add(new UnitEntityData { entity = tempentity, unitId = authoring.UnitList[i].UnitID });
            }

            AddComponent(entity, new GameUnitListComponent
            {
                UnitList = TempUnitLists
            });



        }
    }

}

