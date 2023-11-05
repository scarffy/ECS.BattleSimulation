using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct DynamicGridCellItem:IBufferElementData
{
    public Entity entity;
}

public struct GridComponent : IComponentData
{
    public SpawnType SpawnType;
    public Entity TileEntity;
    public Entity entity;
    public uint2 GridSize;
    public float2 CellSize;
    public float3 Origin;
    public uint2 SelectedCell;

    public bool Processed;
    public bool CleanUp;

    public int TotalUnit;

    public float3 GetCellPosition(uint x, uint y)
    {
        if (x > 100000)
            x = 100000;
        if (y > 100000)
            y = 100000;

        return Origin + new float3(CellSize.x*x, 0, CellSize.y * y);
    }

    public float3 GetSelectedCellPosition()
    {
        return GetCellPosition(SelectedCell);
    }

    public float3 GetCellPosition(uint2 sellIndex)
    {
        return GetCellPosition(sellIndex.x, sellIndex.y);
    }

    public uint2 GetCellIndex(float3 position)
    {
        return new uint2((uint)math.floor((position.x - Origin.x + CellSize.x / 2)/ CellSize.x), (uint)math.floor((position.z - Origin.z + CellSize.y / 2)/ CellSize.y));
    }

    public int GetBufferIndex(float3 position)
    {
        uint2 index = GetCellIndex(position);
        return GetBufferIndex(index);
    }

    public int GetBufferIndex(uint2 cellIndex)
    {
        if (!ContainsCell(cellIndex))
            return -1;
        return ((int)(cellIndex.x + cellIndex.y * GridSize.x));
    }

    public void SelectCell(float3 position)
    {
        uint2 index = GetCellIndex(position);
        SelectCell(index);
    }

    public void SelectCell(uint2 index)
    {
        if (ContainsCell(index))
            SelectedCell = index;
        else
            UnSelectCell();
    }

    public void UnSelectCell()
    {
        SelectedCell = new uint2(uint.MaxValue, uint.MaxValue);
    }

    public bool IsSelected()
    {
        return (SelectedCell.x != uint.MaxValue || SelectedCell.y!= uint.MaxValue);
    }

    public bool ContainsCell(uint2 index)
    {
        if (index.x >= 0 && index.x < GridSize.x && index.y >= 0 && index.y < GridSize.y)
            return true;

        return false;
    }
}
