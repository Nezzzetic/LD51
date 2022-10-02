using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class SimpleMoveControll : MonoBehaviour
{
    public float speed;
    private PlayerInputActions PlayerInputActions;
    public Transform model;
    public Rigidbody Rigidbody;
    public AudioSource[] WalkSounds;
    public float WalkSoundDelay;
    private float _walkSoundTimer;

    private void Awake()
    {
        PlayerInputActions = new PlayerInputActions();
        PlayerInputActions.Default.Enable();
        Rigidbody = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        if (_walkSoundTimer > 0) _walkSoundTimer -= Time.deltaTime;
    }
    private void FixedUpdate()
    {
        
        var vet = PlayerInputActions.Default.Movement.ReadValue<Vector2>();
        var movementDirection=new Vector3(vet.x * speed, 0, vet.y * speed);
        Rigidbody.MovePosition(transform.position+movementDirection);
        //transform.position += movementDirection;
        if (movementDirection!=Vector3.zero) {
            model.transform.rotation = Quaternion.Slerp (model.transform.rotation, Quaternion.LookRotation (movementDirection), 0.2f);
            if (_walkSoundTimer>0) return;
            var rnd = Random.Range(0, WalkSounds.Length);
            WalkSounds[rnd].Play();
            _walkSoundTimer = WalkSoundDelay;
        }
    }

}
