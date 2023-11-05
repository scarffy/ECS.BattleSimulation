using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New UnitData", menuName = "ScriptableData/UnitData")]
public class UnitData : ScriptableObject
{
    public string UnitID;
    public Sprite Icon;
    public GameObject Prefab;
    public float Health;
    public float MovementSpeed;
    public float AttackDamage;
    public float AttackSpeed;
    public float AttackRange;


    public void CopyFrom(UnitData _unitData)
    {
        if (_unitData == null)
            return;
        UnitID = _unitData.UnitID;
        Icon = _unitData.Icon;
        Prefab = _unitData.Prefab;

        Health = _unitData.Health;
        MovementSpeed = _unitData.MovementSpeed;
        AttackDamage = _unitData.AttackDamage;
        AttackSpeed = _unitData.AttackSpeed;
        AttackRange = _unitData.AttackRange;
    }


    public void Clear()
    {
        UnitID = name;
        Icon = null;
        Prefab = null;
    }
}
