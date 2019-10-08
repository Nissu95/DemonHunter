using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    private void Awake()
    {
        m_Health = GetComponent<EnemyDT>().GetData().GetHealth();
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
