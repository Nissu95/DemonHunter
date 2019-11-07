using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    public override void TakeDamage()
    {
        Death();
    }

    public override void Death()
    {
        GameManager.singleton.OnPlayerDeath();
        gameObject.SetActive(false);
    }
}
