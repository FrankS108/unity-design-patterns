using System.Collections.Generic;
using UnityEngine;

namespace Patterns.Factory
{
    [CreateAssetMenu(menuName = "Factory/Create EnemiesConfiguration", fileName = "EnemiesConfiguration", order = 0)]
    public class EnemiesConfiguration : ScriptableObject
    {
        [SerializeField] private Enemy[] enemyPrefabs;
        private Dictionary<string, Enemy> idToEnemyPrefab;

        private void Awake()
        {
            idToEnemyPrefab = new Dictionary<string, Enemy>();

            foreach (var enemyPrefab in enemyPrefabs)
            {
                idToEnemyPrefab.Add(enemyPrefab.Id, enemyPrefab);
            }
        }

        public Enemy GetEnemyById(string id)
        {
            return idToEnemyPrefab[id];
        }
    }
}