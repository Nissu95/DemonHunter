using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyPattern
{
    public class NormalEnemy : Enemy
    {
        EnemyFSM enemyMode = EnemyFSM.Idle;
        float speed;
        float attackRange;
        float startMoveRange;

        public NormalEnemy(Transform normalEnemyObj, EnemyDT data)
        {
            enemyObj = normalEnemyObj;
            speed = data.GetData().GetSpeed();
            attackRange = data.GetData().GetRange();
            startMoveRange = data.GetData().GetStartMoveRange();
        }

        public override void UpdateEnemy(Transform playerObj)
        {
            float distance = Vector2.Distance(enemyObj.position, playerObj.position);

            switch (enemyMode)
            {
                case EnemyFSM.Idle:
                    if (distance <= startMoveRange)
                        enemyMode = EnemyFSM.Move;
                    break;
                case EnemyFSM.Move:
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
                    Attack();
                    Debug.Log("Normal Enemy is attacking");
                    break;
                case EnemyFSM.Idle:
                    Debug.Log("Normal Enemy is idle");
                    break;
                case EnemyFSM.Move:
                    enemyObj.Translate(-enemyObj.right * speed * Time.deltaTime);
                    Debug.Log("Normal Enemy is moving");
                    break;
            }
        }

        void Attack()
        {
            enemyObj.GetComponent<GetHitCollider>().GetCollider().SetActive(true);
        }
    }
}