using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyPattern
{
    public class TurretEnemy : Enemy
    {
        EnemyFSM enemyMode = EnemyFSM.Idle;
        Pool pool;
        float attackRange;
        float attackCooldown;
        float timer;

        public TurretEnemy(Transform turretEnemyObj, EnemyDT data)
        {
            enemyObj = turretEnemyObj;
            attackRange = data.GetData().GetRange();
            attackCooldown = data.GetData().GetAttackCooldown();
            timer = attackCooldown;
        }

        public override void UpdateEnemy(Transform playerObj)
        {
            float distance = (enemyObj.position - playerObj.position).magnitude;

            switch (enemyMode)
            {
                case EnemyFSM.Idle:
                    if (distance <= attackRange)
                        enemyMode = EnemyFSM.Attack;
                    break;
                    /*case EnemyFSM.Attack:
                        break;*/
            }

            //Move the enemy based on a state
            DoAction(playerObj, enemyMode);
        }

        protected override void DoAction(Transform playerObj, EnemyFSM enemyMode)
        {
            switch (enemyMode)
            {
                case EnemyFSM.Attack:
                    Attack(playerObj);
                    Debug.Log("Turret Enemy is attacking");
                    break;
                case EnemyFSM.Idle:
                    Debug.Log("Turret Enemy is idle");
                    break;
            }
        }

        void Attack(Transform playerObj)
        {
            timer += Time.deltaTime;

            if (timer >= attackCooldown)
            {
                pool = PoolManager.GetInstance().GetPool("ProyectilePool");

                PoolObject po = pool.GetPooledObject();
                po.GetComponent<Bullet_Script>().SetEnemyTag(playerObj.tag);
                po.gameObject.transform.position = enemyObj.position;
                po.gameObject.transform.rotation = enemyObj.rotation;
                timer = 0;
            }
        }
    }
}