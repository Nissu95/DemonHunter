using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyPattern
{
    public class TurretEnemy : Enemy
    {
        EnemyFSM enemyMode = EnemyFSM.Idle;
        float attackRange;

        public TurretEnemy(Transform turretEnemyObj, EnemyDT data)
        {
            enemyObj = turretEnemyObj;
            attackRange = data.GetData().GetRange();
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
                    //Attack player
                    Debug.Log("Turret Enemy is attacking");
                    break;
                case EnemyFSM.Idle:
                    Debug.Log("Turret Enemy is idle");
                    break;
            }
        }
    }
}