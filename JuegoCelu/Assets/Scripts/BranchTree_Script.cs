using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchTree_Script : MonoBehaviour
{
    [SerializeField] string playerTag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            CharacterController2D playerController = collision.gameObject.GetComponentInParent<CharacterController2D>();
            playerController.Jump();
        }
    }
}
