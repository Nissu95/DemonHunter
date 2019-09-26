using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public override void TakeDamage(bool _IsDamage)
    {
        if (_IsDamage)
            gameObject.SetActive(false);
    }

}
