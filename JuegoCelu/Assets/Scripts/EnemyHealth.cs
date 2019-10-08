using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public override void TakeDamage(bool _IsDamage)
    {
        if (_IsDamage)
            Death();
    }

    public override void TakeDamage(float _Damage)
    {
        m_Health -= _Damage;
        if (m_Health <= 0)
            Death();
    }

    public override void Death()
    {
        gameObject.SetActive(false);
    }
}
