using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 40;

    CharacterController2D controller;
    bool isJumping = false;
    bool isCrouching = false;

    private void Awake()
    {
        controller = GetComponent<CharacterController2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
            isJumping = true;
        else
            isJumping = false;

        if (Input.GetButtonDown("Crouch"))
            isCrouching = true;
        else
            isCrouching = false;
    }

    private void FixedUpdate()
    {
        controller.Move(runSpeed * Time.fixedDeltaTime, isCrouching, isJumping);
    }
}
