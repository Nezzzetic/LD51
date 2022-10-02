using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float XMin;
    public float XMax;
    public float ZMin;
    public float ZMax;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var x = target.transform.position.x;
        var z = target.transform.position.z-13;
        if (x < XMin) x = XMin;
        else if (x > XMax) x = XMax;
        if (z < ZMin) z = ZMin;
        else if (z > ZMax) z = ZMax;
        transform.position = new Vector3(x, 20, z);
    }

    
}
