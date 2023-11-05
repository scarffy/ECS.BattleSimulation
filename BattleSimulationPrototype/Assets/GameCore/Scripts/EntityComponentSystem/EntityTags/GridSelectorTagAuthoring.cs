using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class GridSelectorTagAuthoring : MonoBehaviour
{
    class Baker : Baker<GridSelectorTagAuthoring>
    {
        public override void Bake(GridSelectorTagAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new GridSelectorTag
            {

            });
        }
    }
}
