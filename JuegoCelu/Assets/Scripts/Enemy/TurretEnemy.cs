using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyPattern
{
    public class TurretEnemy : Enemy
    {
        EnemyFSM enemyMode = EnemyFSM.Idle;
        Pool pool;
        float shotRange;
        float attackCooldown;
        float timer;
        float startMoveRange;
        float speed;
        float attackRange;

        Animator animator;

        public TurretEnemy(Transform turretEnemyObj, EnemyDT data)
        {
            enemyObj = turretEnemyObj;
            shotRange = data.GetData().GetShotRange();
            attackCooldown = data.GetData().GetAttackCooldown();
            timer = attackCooldown;
            startMoveRange = data.GetData().GetStartMoveRange();
            speed = data.GetData().GetSpeed();
            attackRange = data.GetData().GetAttackRange();

            animator = enemyObj.GetComponent<Animator>();
        }

        public override void UpdateEnemy(Transform playerObj)
        {
            float distance = (enemyObj.position - playerObj.position).magnitude;

            switch (enemyMode)
            {
                case EnemyFSM.Idle:
                    if (distance <= shotRange)
                        enemyMode = EnemyFSM.Shot;
                    break;
                case EnemyFSM.Shot:
                    if (distance <= startMoveRange)
                        enemyMode = EnemyFSM.Move;
                    break;
                case EnemyFSM.Move:
                    if (distance <= attackRange)
                        enemyMode = EnemyFSM.Attack;
                    break;
            }

            //Move the enemy based on a state
            DoAction(playerObj, enemyMode);
        }

        protected override void DoAction(Transform playerObj, EnemyFSM enemyMode)
        {
            switch (enemyMode)
            {
                case EnemyFSM.Shot:
                    Shot(playerObj);
                    Debug.Log("Turret Enemy is Shooting");
                    break;
                case EnemyFSM.Idle:
                    Debug.Log("Turret Enemy is idle");
                    animator.SetBool("Walking", false);
                    break;
                case EnemyFSM.Move:
                    Move();
                    Debug.Log("Turret Enemy is moving");
                    break;
                case EnemyFSM.Attack:
                    Attack();
                    Debug.Log("Turret Enemy is attacking");
                    break;
            }
        }

        void Shot(Transform playerObj)
        {
            timer += Time.deltaTime;

            if (timer >= attackCooldown)
            {

                animator.SetTrigger("Attack");

                pool = PoolManager.GetInstance().GetPool("ProyectilePool");

                PoolObject po = pool.GetPooledObject();
                po.GetComponent<Bullet_Script>().SetEnemyTag(playerObj.tag);
                po.gameObject.transform.position = enemyObj.position;
                po.gameObject.transform.rotation = enemyObj.rotation;
                timer = 0;
            }
        }

        void Attack()
        {
            enemyObj.GetComponent<GetHitCollider>().GetCollider().SetActive(true);
            animator.SetTrigger("Attack");
        }

        void Move()
        {
            enemyObj.Translate(-enemyObj.right * speed * Time.deltaTime);
            animator.SetBool("Walking", true);
        }
    }
}