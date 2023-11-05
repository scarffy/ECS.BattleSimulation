using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;

public struct UnitEntityData
{
    public Entity entity;
    public FixedString128Bytes unitId;
}
public struct GameUnitListComponent : IComponentData
{
    public CustomFixedList16<UnitEntityData> UnitList;
}
