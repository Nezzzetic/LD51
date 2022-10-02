using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterControllerView : MonoBehaviour
{
    public WaterController WaterController;
    public GameObject[] Drops;
    public int WaterInDrops;

    public Transform FXParent;
    public GameObject FXPrefab;

    // Update is called once per frame
    void Update()
    {
        for (var i = 0; i < 10; i++)
                Drops[i].SetActive(WaterController.WaterLevel >= (i+1) * WaterInDrops);
    }

    public void OnDamage()
    {
        var fx = Instantiate(FXPrefab, FXParent);
        Destroy(fx,2);
    }
}
