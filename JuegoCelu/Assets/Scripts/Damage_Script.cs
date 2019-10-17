using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Script : MonoBehaviour
{
    [SerializeField] float damage = 10;
    [SerializeField] string[] enemyTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < enemyTag.Length; i++)
            if (collision.CompareTag(enemyTag[i]))
                collision.GetComponent<Health>().TakeDamage(damage);
    }
}