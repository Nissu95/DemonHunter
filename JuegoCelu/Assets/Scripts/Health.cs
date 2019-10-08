using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected float m_Health;

    public virtual void TakeDamage(bool _IsDamage) { }
    public virtual void TakeDamage(float _Damage) { }
    public virtual void Death() { }
}
