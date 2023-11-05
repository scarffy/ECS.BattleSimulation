using Unity.Entities;
using Unity.Mathematics;

public enum SpawnType
{
    NONE,
    PLAYER,
    ENEMY,
    GRID
}

public struct SpawnComponent : IComponentData
{
    public Entity gobject;
    public Entity localTransform;
    public float3 Position;
    public SpawnType spawnType;
}
