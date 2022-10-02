using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public int WaterLevel;
    public int WaterLevelMax;
    public WaterSender WaterSender;
    public float FillPeriod;
    public float SendPeriod;
    private float fillTimer;
    private float sendTimer;
    public bool full => WaterLevel == WaterLevelMax;
    public bool Filled { get; private set; }
    public bool empty => WaterLevel == 0;
    public WaterControllerView WaterControllerView;
    
    // Start is called before the first frame update
    void Start()
    {
        LevelCheck();
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
        Filled = true;
    }
    
    public void StopFill()
    {
        fillTimer = 0;
        Filled = false;
    }
    
    void UpdateFill()
    {
        if (full) return;
        if (!Filled) return;
        fillTimer += Time.deltaTime;
        if (fillTimer < FillPeriod) return;
        fillTimer -= FillPeriod;
        WaterLevel++;
        LevelCheck();
    }
    
    void UpdateSend()
    {
        if (empty) return;
        if (WaterSender.currentConsumer== null || WaterSender.currentConsumer.full) return;
        sendTimer += Time.deltaTime;
        WaterSender.currentConsumer.OnFillStart();
        if (sendTimer < SendPeriod) return;
        sendTimer -= SendPeriod;
        WaterSender.currentConsumer.AddFill();
        WaterLevel--;
        if (WaterSender.currentConsumer!=null && empty) WaterSender.currentConsumer.OnFillEnd();
        LevelCheck();
    }
    
    public void Damage(int val)
    {
        if (empty) return;
        WaterLevel -= val;
        if (WaterLevel < 0) WaterLevel = 0;
        LevelCheck();
        WaterControllerView.OnDamage();
    }

    void LevelCheck()
    {

    }

    
}
