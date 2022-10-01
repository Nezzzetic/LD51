using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterControllerView : MonoBehaviour
{
    public WaterController WaterController;
    public GameObject[] Drops;
    public int WaterInDrops;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (var i = 0; i < 5; i++)
                Drops[i].SetActive(WaterController.WaterLevel >= (i+1) * WaterInDrops);
    }
}
