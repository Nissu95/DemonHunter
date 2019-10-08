using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StrategyPattern
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] GameObject playerObj;
        [SerializeField] List<GameObject> normalEnemies;
        [SerializeField] List<GameObject> turretEnemies;
        [SerializeField] GameObject bossEnemy;

        //A list that will hold all enemies
        List<Enemy> m_AllEnemies = new List<Enemy>();

        void Start()
        {
            //Add the enemies we have
            for (int i = 0; i < normalEnemies.Count; i++)
                m_AllEnemies.Add(new NormalEnemy(normalEnemies[i].transform, normalEnemies[i].GetComponent<EnemyDT>()));

            for (int i = 0; i < turretEnemies.Count; i++)
                m_AllEnemies.Add(new TurretEnemy(turretEnemies[i].transform, normalEnemies[i].GetComponent<EnemyDT>()));

            if (bossEnemy)
                m_AllEnemies.Add(new BossEnemy(bossEnemy.transform, bossEnemy.GetComponent<EnemyDT>()));
        }

        void Update()
        {
            //Update all enemies to see if they should change state and move/attack player
            for (int i = 0; i < m_AllEnemies.Count; i++)
            {
                m_AllEnemies[i].UpdateEnemy(playerObj.transform);
            }
        }
    }
}