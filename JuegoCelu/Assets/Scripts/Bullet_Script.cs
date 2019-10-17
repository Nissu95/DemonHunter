using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] float maxTime;

    float damage;
    string enemyTag;
    float timer;

    private void OnEnable()
    {
        RestartTimer();
    }

    private void FixedUpdate()
    {
        transform.Translate(bulletSpeed * Time.deltaTime, 0, 0);

        if (timer > 0)
            timer -= Time.deltaTime;

        if (timer <= 0)
            GetComponent<PoolObject>().Recycle();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(enemyTag))
        {
            GetComponent<PoolObject>().Recycle();
            Health enemy = collision.GetComponent<Health>();
            enemy.TakeDamage();
            enemy.TakeDamage(damage);
        }
    }

    public void SetDamage(float _Damage)
    {
        damage = _Damage;
    }

    public void SetEnemyTag(string _EnemyTag)
    {
        enemyTag = _EnemyTag;
    }

    public void RestartTimer()
    {
        timer = maxTime;
    }
}
