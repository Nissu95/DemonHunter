using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Game/Data/Enemy"))]
public class EnemyData : ScriptableObject
{
    [SerializeField] float m_Damage;
    [SerializeField] float m_Health;
    [SerializeField] float m_AttackRange;
    [SerializeField] float m_Speed;

    public float GetDamage()
    {
        return m_Damage;
    }

    public float GetHealth()
    {
        return m_Health;
    }

    public float GetRange()
    {
        return m_AttackRange;
    }

    public float GetSpeed()
    {
        return m_Speed;
    }
}
