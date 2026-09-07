using System;
using Battle;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameOverView : MonoBehaviour
    {
        public static GameOverView Instance { get; private set; }
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private Button restartButton;
        [SerializeField] private GameFacade gameFacade;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            restartButton.onClick.AddListener(RestartGame);
            gameObject.SetActive(false);
        }

        private void RestartGame()
        {
            gameFacade.StartBattle();
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameFacade.StopBattle();
            scoreText.SetText(ScoreView.Instance.CurrentScore.ToString());
            gameObject.SetActive(true);

        }
    }
}

