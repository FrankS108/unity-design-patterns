using Ships;
using Ships.Enemies;
using UI;
using UnityEngine;

namespace Battle
{
    public class GameFacade : MonoBehaviour
    {

        [SerializeField] private UI.ScreenFade screenFade;
        [SerializeField] private ShipInstaller shipInstaller;
        [SerializeField] private EnemySpawner enemySpawner;

        public void StartBattle()
        {
            ScoreView.Instance.Reset();
            enemySpawner.StartSpawn();
            shipInstaller.SpawnUserShip();
            screenFade.Hide();
        }

        public void StopBattle()
        {
            enemySpawner.StopAndReset();
            shipInstaller.DestroyUserShip();
            screenFade.Show();
        }
    }

}
