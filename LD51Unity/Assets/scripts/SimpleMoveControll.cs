using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleMoveControll : MonoBehaviour
{
    public float speed;
    private PlayerInputActions PlayerInputActions;
    public Transform model;

    private void Awake()
    {
        PlayerInputActions = new PlayerInputActions();
        PlayerInputActions.Default.Enable();
    }
    private void FixedUpdate()
    {
        var vet = PlayerInputActions.Default.Movement.ReadValue<Vector2>();
        var movementDirection=new Vector3(vet.x * speed, 0, vet.y * speed);
        transform.position += movementDirection;
        if (movementDirection!=Vector3.zero)
            model.transform.rotation = Quaternion.Slerp (model.transform.rotation, Quaternion.LookRotation (movementDirection), 0.2f);
    }

}
