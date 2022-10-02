using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollector : MonoBehaviour
{
    public WaterController WaterController;
    public bool Filled { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var waterSource = other.GetComponent<WaterSource>();
        if (waterSource != null)
        {
            WaterController.StartFill();
            
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        var waterSource = other.GetComponent<WaterSource>();
        if (waterSource != null)
        {
            WaterController.StopFill();
        }
    }
}
