using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Springboard_Script : MonoBehaviour
{
    [SerializeField] string playerGroundTag;
    [SerializeField] float jumpForce;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerGroundTag))
        {
            CharacterController2D playerController = collision.GetComponentInParent<CharacterController2D>();
            playerController.SpringboardJump(jumpForce);
        }
    }
}
