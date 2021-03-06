﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    private PlatformController PlatformController;
    public Vector2 RunAnimationSpeed;
    private Animator Animator;
    // Start is called before the first frame update
    
    void Start()
    {
        PlatformController = GetComponent<PlatformController>();
        PlatformController.OnJump += OnJump;
        
        PlatformController.OnMoveStart += OnMoveStart;
        PlatformController.OnMoveStop += OnMoveStop;
        PlatformController.OnLand += OnLand;
       
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlatformController.InputJump = Input.GetButtonDown("Jump");
        PlatformController.InputMove = Input.GetAxisRaw("Horizontal");
        
        var speedRatio = PlatformController.CurrentSpeed / PlatformController.MoveSpeed;
        
        Animator.speed = RunAnimationSpeed.Lerp(speedRatio);
        
    }

    private void OnJump(PlatformController platformController)
    {
        Animator.Play("Mario_Jump");
    }

    private void OnLand(PlatformController platformController)
    {
        if (PlatformController.IsMoving)
        {
            Animator.Play("Mario_Run");
        }
        else
        {
            Animator.Play("Mario_Idle");
        }
        
    }
    
    private void OnMoveStart(PlatformController platformController)
    {
        Animator.Play("Mario_Run");
    }
    private void OnMoveStop(PlatformController platformController)
    {
        if (!PlatformController.IsJumping)
        {
            Animator.Play("Mario_Idle");
        }
    }
    
}
