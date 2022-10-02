using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public HicController[] Hics;
    public WaterController Player;
    public CameraController Camera;
    public CameraShake CameraShake;

    public static int Level;
    // Start is called before the first frame update
    void Awake()
    {
        Camera.target = Player.transform;
        foreach (var hic in Hics)
        {
            hic.playerWaterController = Player;
            hic.OnHicStop += LevelEndCheck;
            hic.OnHic += CameraShake.StartShake;
        }
    }

    void LevelEndCheck()
    {
        foreach (var hic in Hics)
            if (hic.HicActive) return;
        LevelEnd();
    }
    void LevelEnd()
    {
        Level++;
        SceneManager.LoadScene(Level);
    }
}
