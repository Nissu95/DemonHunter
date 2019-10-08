using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 40;

    CharacterController2D controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController2D>();
    }

    private void FixedUpdate()
    {
        //controller.Move(runSpeed * Time.fixedDeltaTime, isCrouching, isJumping);
        controller.Move(runSpeed * Time.fixedDeltaTime,
            InputManager.singleton.GetInput().GetCrouch(),
            InputManager.singleton.GetInput().GetJump());

        controller.Attack(InputManager.singleton.GetInput().GetAttack());

        InputManager.singleton.GetInput().SetJump(false);
        InputManager.singleton.GetInput().SetCrouch(false);
        //InputManager.singleton.GetInput().SetAttack(false);
    }
}
