using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage_Script : MonoBehaviour
{
    [SerializeField] string playerTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
            collision.GetComponent<Health>().TakeDamage();
    }
}
