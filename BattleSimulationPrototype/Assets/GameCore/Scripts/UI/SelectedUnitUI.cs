using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedUnitUI : MonoBehaviour
{
    public UnitData UnitData;
    public Image Icon;

    private void Start()
    {
        UnitData.Clear();
    }

    void Update()
    {
        UpdateInfo();
    }


    public void UpdateInfo()
    {
        if (UnitData == null)
            return;
        Icon.sprite = UnitData.Icon;
    }
}
