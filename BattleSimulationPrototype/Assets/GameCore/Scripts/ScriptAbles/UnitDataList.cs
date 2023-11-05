using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New UnitDataList", menuName = "ScriptableData/UnitDataList")]
public class UnitDataList : ScriptableObject
{
    [SerializeField]
    private List<UnitData> unitDatas;

    public List<UnitData> UnitDatas { get => unitDatas; set => unitDatas = value; }
}
