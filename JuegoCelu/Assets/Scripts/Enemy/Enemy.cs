using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyPattern
{
    //The enemy base class
    public class Enemy
    {
        protected Transform enemyObj;

        protected enum EnemyFSM
        {
            Move,
            Attack,
            Idle,
            Stun
        }

        //Update the enemy by giving it a new state
        public virtual void UpdateEnemy(Transform playerObj) { }

        //Do something based on a state
        protected virtual void DoAction(Transform playerObj, EnemyFSM enemyMode) { }

        public Transform GetEnemyOBJ() { return enemyObj; }
    }
}