using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSelectUI : MonoBehaviour
{
    public UnitData UnitData;
    public UnitData SelectedUnitData;
    public Image Icon;    
    // Start is called before the first frame update
    void Start()
    {
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        if (UnitData == null)
            return;
        Icon.sprite = UnitData.Icon;
    }

    public void SetUnitData(UnitData _unitData)
    {
        UnitData = _unitData;
        UpdateInfo();
    }

    public void SelectUnit()
    {
        SelectedUnitData?.CopyFrom(UnitData);
    }
}
