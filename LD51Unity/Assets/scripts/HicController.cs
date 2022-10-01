using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HicController : MonoBehaviour
{

    public bool HicActive;
    public WaterController playerWaterController;
    public float StartHic;
    private float hicTimer;
    public int HicDamage;

    // Start is called before the first frame update
    void Start()
    {
        HicActive = true;
        hicTimer = StartHic;
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
        playerWaterController.Damage(HicDamage);
        Debug.Log("HIC");
    }
    
    
}
