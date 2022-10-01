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
    public Rigidbody Rigidbody;

    private void Awake()
    {
        PlayerInputActions = new PlayerInputActions();
        PlayerInputActions.Default.Enable();
        Rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        var vet = PlayerInputActions.Default.Movement.ReadValue<Vector2>();
        var movementDirection=new Vector3(vet.x * speed, 0, vet.y * speed);
        Rigidbody.MovePosition(transform.position+movementDirection);
        //transform.position += movementDirection;
        if (movementDirection!=Vector3.zero)
            model.transform.rotation = Quaternion.Slerp (model.transform.rotation, Quaternion.LookRotation (movementDirection), 0.2f);
    }

}
