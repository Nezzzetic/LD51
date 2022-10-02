using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterConsumer : MonoBehaviour
{
    public int WaterLevel;
    public int WaterLevelMax;
    public bool full;
    public bool filled;
    public Action OnFull=delegate {  };
    public Action OnFillStart=delegate {  };
    public Action OnFillEnd=delegate {  };
    public GameObject DropsParent;
    public GameObject[] Drops;
    public int WaterInDrops;
    
    public Animator Animator;

    public HicController HicController;
    // Start is called before the first frame update
    void Awake()
    {
        Animator=GetComponent<Animator>();
        OnFillStart += DrinkStart;
        OnFillEnd += DrinkStop;
        OnFull += DrinkStop;
    }

    // Update is called once per frame
    void Update()
    {
        for (var i = 0; i < 5; i++)
            Drops[i].SetActive(WaterLevel < (i + 1) * WaterInDrops && WaterLevelMax >= (i + 1) * WaterInDrops);
    }
    
    public void AddFill()
    {
        WaterLevel++;
        OnFillStart();
        FullCheck();
    }

    void FullCheck()
    {
        if (WaterLevel == WaterLevelMax)
        {
            full = true;
            filled = false;
            HicController.HicActive = false;
            OnFull();
        }
    }

    void DrinkStart()
    {
        if (full) return;
        filled = true;
        Animator.SetBool("drink",true);
    }
    
    void DrinkStop()
    {
        if (!full) WaterLevel = 0;
        filled = false;
        Animator.SetBool("drink",false);
    }
}
