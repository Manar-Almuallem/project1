using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class Move : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 3f;
    public float runSpeed = 6f;
    public AudioSource footstepSource;
    public AudioClip[] footstepClips;
    public float footstepInterval = 0.5f;
    private float footstepTimer = 0f;


    private CharacterController characterController;
    private Animator animator;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0, vertical).normalized;

        bool isMoving = moveDirection.magnitude > 0;
        animator.SetBool("isWalking", isMoving);

        if (isMoving)
        {
            float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
            transform.forward = moveDirection;
            characterController.Move(moveDirection * currentSpeed * Time.deltaTime);

            // Handle footsteps
            footstepTimer -= Time.deltaTime;
            if (footstepTimer <= 0f)
            {
                PlayFootstep();
                footstepTimer = footstepInterval; // reset timer
            }
        }
        else
        {
            footstepTimer = 0f; // reset when not moving
        }
    }

    void PlayFootstep()
    {
        if (footstepClips.Length > 0)
        {
            int index = UnityEngine.Random.Range(0, footstepClips.Length);
            footstepSource.clip = footstepClips[index];
            footstepSource.Play();
        }
    }

}



