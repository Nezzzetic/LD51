using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSender : MonoBehaviour
{
    public WaterController WaterController;
    public WaterConsumer currentConsumer;
    private void OnTriggerEnter(Collider other)
    {
        var waterConsumer = other.GetComponent<WaterConsumer>();
        if (waterConsumer != null)
        {
            currentConsumer = waterConsumer;
            
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        var waterConsumer = other.GetComponent<WaterConsumer>();
        if (waterConsumer != null)
        {
            waterConsumer.OnFillEnd();
            currentConsumer = null;
        }
    }
}
