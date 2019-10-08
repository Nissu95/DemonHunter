using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Script : MonoBehaviour
{
    [SerializeField] float damage = 10;
    [SerializeField] string enemyTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(enemyTag))
            collision.GetComponent<Health>().TakeDamage(damage);
    }

}