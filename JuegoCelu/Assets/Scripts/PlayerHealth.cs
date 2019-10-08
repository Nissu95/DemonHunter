﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    public override void TakeDamage(float _Damage)
    {
        Death();
    }

    public override void Death()
    {
        gameObject.SetActive(false);
    }
}
