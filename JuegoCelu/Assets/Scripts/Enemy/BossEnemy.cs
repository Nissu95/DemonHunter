using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyPattern
{
    public class BossEnemy : Enemy
    {
        EnemyFSM enemyMode = EnemyFSM.Move;
        float speed;
        float attackRange;

        public BossEnemy(Transform bossEnemyObj, EnemyDT data)
        {
            enemyObj = bossEnemyObj;
            speed = data.GetData().GetSpeed();
            attackRange = data.GetData().GetRange();
        }

        public override void UpdateEnemy(Transform playerObj)
        {
            float distance = (enemyObj.position - playerObj.position).magnitude;

            switch (enemyMode)
            {
                case EnemyFSM.Move:
                    if (distance <= attackRange)
                    {
                        enemyMode = EnemyFSM.Attack;
                    }
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
                    //Attack player
                    Debug.Log("Boss Enemy is attacking");
                    break;
                case EnemyFSM.Move:
                    Debug.Log("Boss Enemy is moving");
                    break;
            }
        }
    }
}