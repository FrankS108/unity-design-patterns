using Battle;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{

    public class Menu : MonoBehaviour
    {
        [SerializeField] private Button startBattleButton;
        [SerializeField] private Button stopBattleButton;
        [SerializeField] private GameFacade gameFacade;

        private void Awake()
        {
            startBattleButton.onClick.AddListener(StartBattle);
            stopBattleButton.onClick.AddListener(StopBattle);

        }

        private void StartBattle()
        {
            gameFacade.StartBattle();
        }

        private void StopBattle()
        {
            gameFacade.StopBattle();
        }
    }

}