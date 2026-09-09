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
        [SerializeField] private GameStateController gameState;

        public void StartBattle()
        {
            gameState.Reset();
            ScoreView.Instance.Reset();
            enemySpawner.StartSpawn();
            shipInstaller.SpawnUserShip();
            screenFade.Hide();
        }

        public void StopBattle()
        {
            enemySpawner.StopAndReset();
            screenFade.Show();
        }
    }

}
