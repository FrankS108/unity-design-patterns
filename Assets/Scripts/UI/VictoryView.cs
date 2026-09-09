using System;
using Battle;
using Common;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class VictoryView : MonoBehaviour, EventObserver
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private Button restartButton;
        [SerializeField] private GameFacade gameFacade;

        private void Awake()
        {
            restartButton.onClick.AddListener(RestartGame);
        }

        private void Start()
        {
            gameObject.SetActive(false);
            EventQueue.Instance.Subscribe(EventIds.Victory, this);
        }

        private void OnDestroy()
        {
            EventQueue.Instance.Unsubscribe(EventIds.Victory, this);
        }

        private void RestartGame()
        {
            gameFacade.StartBattle();
            gameObject.SetActive(false);
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.Victory)
            {
                scoreText.SetText(ScoreView.Instance.CurrentScore.ToString());
                gameObject.SetActive(true);
            }
        }
    }
}