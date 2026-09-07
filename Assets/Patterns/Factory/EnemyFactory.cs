using System.Linq;
using UnityEngine;

namespace Patterns.Factory
{
    public class EnemyFactory
    {

        private EnemiesConfiguration enemiesConfiguration;

        public EnemyFactory(EnemiesConfiguration enemiesConfiguration)
        {
            this.enemiesConfiguration = enemiesConfiguration;
        }

        public void CreateEnemy(string enemyId)
        {
            var enemyPrefab = enemiesConfiguration.GetEnemyById(enemyId);
            Object.Instantiate(enemyPrefab, Random.onUnitSphere * 3, Quaternion.identity);
        }
    }
}