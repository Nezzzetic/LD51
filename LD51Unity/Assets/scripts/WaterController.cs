using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public int WaterLevel;
    public float FillPeriod;
    public float SendPeriod;
    private float fillTimer;
    private float sendTimer;
    public bool full;
    public bool filled;
    public bool empty;
    public WaterSender WaterSender;
    // Start is called before the first frame update
    void Start()
    {
        FullCheck();
        EmptyCheck();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFill();
        UpdateSend();
    }

    public void StartFill()
    {
        if (full) return;
        fillTimer = 0;
        filled = true;
    }
    
    public void StopFill()
    {
        fillTimer = 0;
        filled = false;
    }
    
    void UpdateFill()
    {
        if (full) return;
        if (!filled) return;
        fillTimer += Time.deltaTime;
        if (fillTimer < FillPeriod) return;
        fillTimer -= FillPeriod;
        WaterLevel++;
        empty = false;
        FullCheck();
    }
    
    void UpdateSend()
    {
        if (empty) return;
        if (WaterSender.currentConsumer== null || WaterSender.currentConsumer.full) return;
        sendTimer += Time.deltaTime;
        if (sendTimer < SendPeriod) return;
        sendTimer -= SendPeriod;
        WaterLevel--;
        WaterSender.currentConsumer.AddFill();
        EmptyCheck();
        FullCheck();
    }
    
    public void Damage(int val)
    {
        WaterLevel -= val;
        if (WaterLevel < 0) WaterLevel = 0;
        EmptyCheck();
        FullCheck();
    }

    void FullCheck()
    {
        if (WaterLevel == 100)
        {
            full = true;
        }
        else
        {
            full = false;
        }
    }
    
    void EmptyCheck()
    {
        if (WaterLevel == 0)
        {
            empty = true;
        }

        else
        {
            empty = false;
        }
    }
    
}
