using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public virtual void TakeDamage(bool _IsDamage) { }
    public virtual void TakeDamage(float _Damage) { }
}
