using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthViewer : MonoBehaviour
{
    public TMPro.TMP_Text HealthText;
    public float HealthValue;
    public float AliveTimar;
    public float AliveTimarCounter;
    // Start is called before the first frame update
    void Start()
    {
        AliveTimarCounter = AliveTimar;
    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = "" + HealthValue;
        AliveTimarCounter -= Time.deltaTime;
        if(AliveTimarCounter<=0)
        {
            Destroy(gameObject);
        }
    }
}
