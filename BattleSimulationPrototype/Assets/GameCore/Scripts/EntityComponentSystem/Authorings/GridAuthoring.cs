using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class GridAuthoring : MonoBehaviour
{
    public SpawnType SpawnType;
    public GameObject TilePrefab;
    public uint2 GridSize;
    public float2 CellSize;
    public float3 Origin;
}

public class GridBaker : Baker<GridAuthoring>
{
    public override void Bake(GridAuthoring authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.Dynamic);
        Entity TEntity = Entity.Null;
        if(authoring.TilePrefab!=null)
        {
            TEntity= GetEntity(authoring.TilePrefab,TransformUsageFlags.Dynamic);
        }
        AddComponent(entity, new GridComponent
        {
            SpawnType=authoring.SpawnType,
            TileEntity= TEntity,
            entity = entity,
            GridSize = authoring.GridSize,
            CellSize = authoring.CellSize,
            Origin = authoring.Origin,
            SelectedCell=new uint2(uint.MaxValue, uint.MaxValue),
        });
        DynamicBuffer<DynamicGridCellItem> gridcells = AddBuffer<DynamicGridCellItem>(entity);

        for(int i=0;i< authoring.GridSize.x* authoring.GridSize.y;i++)
        {
            gridcells.Add(new DynamicGridCellItem {  entity= Entity.Null });
        }

    }
}