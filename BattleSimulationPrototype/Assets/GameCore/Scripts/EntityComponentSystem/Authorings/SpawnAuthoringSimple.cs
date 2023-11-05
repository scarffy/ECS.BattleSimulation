using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
public class SpawnAuthoringSimple : MonoBehaviour
{
    public GameObject gobject;
    public GameObject localTransform;
    public Vector3 Position;

    class Baker : Baker<SpawnAuthoringSimple>
    {
        public override void Bake(SpawnAuthoringSimple authoring)
        {
            Entity entity = this.GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new SpawnComponent
            {
                gobject = GetEntity(authoring.gobject, TransformUsageFlags.Dynamic),
                localTransform = GetEntity(authoring.localTransform, TransformUsageFlags.Dynamic),
                Position = (float3)authoring.Position,
            });
        }
    }

}


