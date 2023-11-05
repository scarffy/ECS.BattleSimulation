using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class PresentationAuthoring : MonoBehaviour
{
    public GameObject Prefab;
    public GameObject render;

    class Baker : Baker<PresentationAuthoring>
    {
        public override void Bake(PresentationAuthoring authoring)
        {
            Entity entity = this.GetEntity(TransformUsageFlags.Dynamic);
            AddComponentObject(entity, new PresentationComponent
            {
                Prefab=authoring.Prefab
            });
            AddComponent(entity, new PresentationEntityComponent
            {
                entity= GetEntity(authoring.render,TransformUsageFlags.Dynamic)
            });

        }
    }

}
