using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Script : MonoBehaviour
{
    [SerializeField] float damage = 10;
    [SerializeField] string enemyTag;
    [SerializeField] string bulletTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(enemyTag))
            collision.GetComponent<Health>().TakeDamage(damage);
        else if (collision.CompareTag(bulletTag))
            collision.GetComponent<Bullet_Script>().Reflect(enemyTag);
    }
}