using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public virtual void TakeDamage(float _Damage) { }
    public virtual void Death() { }
}
