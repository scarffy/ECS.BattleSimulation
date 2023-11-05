using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectManager : MonoBehaviour
{
    public UnitDataList UnitDataList;
    public GameObject UnitSelectPrefab;
    public Transform Root;
    // Start is called before the first frame update
    void Start()
    {
        UpdateSelectData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSelectData()
    {
        UnitSelectUI[] unitSelectUIs = Root.GetComponentsInChildren<UnitSelectUI>(false);
        
        for(int i=0;i< unitSelectUIs.Length;i++)
        {
            UnitSelectUI unitSelectUI = unitSelectUIs[i];
            Destroy(unitSelectUI.gameObject);
        }

        foreach(UnitData unitData in UnitDataList.UnitDatas)
        {
            UnitSelectUI UnitSelectUI = Instantiate(UnitSelectPrefab, Root).GetComponent<UnitSelectUI>();
            UnitSelectUI.UnitData = unitData;
            UnitSelectUI.UpdateInfo();
        }
    }

    public void StartGame()
    {
        GameManager.Instance.GameStart();
    }

    public void PlayerReady()
    {
        GameManager.Instance.PlayerReady();
    }

}
