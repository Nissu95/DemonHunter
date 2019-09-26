using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Script : MonoBehaviour
{
    [SerializeField] string m_EnemyTag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(m_EnemyTag))
        {
            Health otherHealth = other.GetComponent<Health>();
            otherHealth.TakeDamage(true);
        }
    }
}
