using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HicController : MonoBehaviour
{
    public Action OnHicStop = delegate {  };
    public Action OnHic = delegate {  };
    public bool HicActive;
    public Animator Animator;
    public GameObject Sun;
    public AudioSource[] Hics;
    
    public WaterController playerWaterController
    {
        get;
        set;
    }
    public WaterConsumer WaterConsumer;
    public float StartHic;
    private float hicTimer;
    public int HicDamage;

    // Start is called before the first frame update
    void Awake()
    {
        
        Animator=GetComponent<Animator>();
        HicActive = true;
        hicTimer = StartHic;
        WaterConsumer.OnFull += HicStopped;
        OnHic += _playHicSound;
    }

    // Update is called once per frame
    void Update()
    {
        HicUpdate();
    }

    private void HicUpdate()
    {
        if (!HicActive) return;
        hicTimer += Time.deltaTime;
        if (hicTimer < 10) return;
        hicTimer -= 10;
        if (WaterConsumer.filled) return;
        OnHic();
        playerWaterController.Damage(HicDamage);
        Animator.SetTrigger("jump");
    }

    private void HicStopped()
    {
        Sun.SetActive(true);
        OnHicStop();
        
    }

    private void _playHicSound()
    {
        var rnd = Random.Range(0, Hics.Length);
        Hics[rnd].Play();
    }
    
    
}
