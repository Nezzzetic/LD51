using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
    
    public AudioSource[] SwalSounds;
    public float SwalSoundDelay;
    private float _swalSoundTimer;

    public GameObject SwalAudio;
    // Start is called before the first frame update
    void Awake()
    {
        var i = 0;
        var audios = SwalAudio.GetComponents<AudioSource>();
        SwalSounds = new AudioSource[audios.Length];
        foreach (var audio in SwalAudio.GetComponents<AudioSource>())
        {
            SwalSounds[i] = audio;
            i++;
        }
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
        if (!filled) return;
        if (_swalSoundTimer > 0) _swalSoundTimer -= Time.deltaTime;
        if (_swalSoundTimer>0) return;
        var rnd = Random.Range(0, SwalSounds.Length);
        SwalSounds[rnd].Play();
        _swalSoundTimer = SwalSoundDelay;
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
