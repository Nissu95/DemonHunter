using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Game/Data/Enemy"))]
public class EnemyData : ScriptableObject
{
    /*[SerializeField] float m_Damage;
    [SerializeField] float m_Health;*/
    [SerializeField] float m_AttackRange;
    [SerializeField] float m_ShotRange;
    [SerializeField] float m_AttackCooldown;
    [SerializeField] float m_Speed;
    [SerializeField] float m_StartMoveRange;

    /*public float GetDamage()
    {
        return m_Damage;
    }

    public float GetHealth()
    {
        return m_Health;
    }*/

    public float GetAttackRange()
    {
        return m_AttackRange;
    }

    public float GetShotRange()
    {
        return m_ShotRange;
    }

    public float GetAttackCooldown()
    {
        return m_AttackCooldown;
    }

    public float GetSpeed()
    {
        return m_Speed;
    }

    public float GetStartMoveRange()
    {
        return m_StartMoveRange;
    }
}
