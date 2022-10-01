using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterConsumer : MonoBehaviour
{
    public int WaterLevel;
    public int WaterLevelMax;
    public bool full;
    public bool filled;

    public HicController HicController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    
    public void AddFill()
    {
        WaterLevel++;
        FullCheck();
    }

    void FullCheck()
    {
        if (WaterLevel == WaterLevelMax)
        {
            full = true;
            filled = false;
            HicController.HicActive = false;
        }
    }
}
