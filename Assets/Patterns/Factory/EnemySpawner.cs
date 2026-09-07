using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Patterns.Factory
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyId enemyId1;
        [SerializeField] private EnemyId enemyId2;
        [SerializeField] private EnemiesConfiguration enemiesConfiguration;
        private EnemyFactory enemyFactory;

        private void Awake()
        {
            enemyFactory = new EnemyFactory(Instantiate(enemiesConfiguration));
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Q))
            {
                enemyFactory.CreateEnemy(enemyId1.Value);
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.W))
            {
                enemyFactory.CreateEnemy(enemyId2.Value);
            }
        }


    }
}