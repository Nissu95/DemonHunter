using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public override void TakeDamage()
    {
        Death();
    }

    public override void Death()
    {
        GameManager.singleton.OnPlayerDeath();
        animator.SetTrigger("Death");
        gameObject.SetActive(false);
    }
}
