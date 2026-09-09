using Common;
using Ships.Common;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreView : MonoBehaviour, EventObserver
    {
        public static ScoreView Instance => instance;
        private static ScoreView instance;
        [SerializeField] private TextMeshProUGUI text;
        private int currentScore;
        public int CurrentScore
        {
            get => currentScore;
            private set
            {
                currentScore = value;
                text.SetText(currentScore.ToString());

            }
        }

        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogError("Hay dos instancias de ScoreView");
                Destroy(gameObject);
                return;
            }

            instance = this;

        }

        private void Start()
        {
            EventQueue.Instance.Subscribe(EventIds.ShipDestroyed, this);
        }

        private void OnDestroy()
        {
            EventQueue.Instance.Unsubscribe(EventIds.ShipDestroyed, this);
        }

        public void Reset()
        {
            CurrentScore = 0;
            text.SetText(CurrentScore.ToString());

        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId != EventIds.ShipDestroyed) return;

            var shipDestroyedEventData = (ShipDestroyedEventData)eventData;
            AddScore(shipDestroyedEventData.Team, shipDestroyedEventData.ScoreToAdd);
        }

        private void AddScore(Teams killedTeam, int scoreToAdd)
        {
            if (killedTeam != Teams.Enemy)
            {
                return;
            }

            CurrentScore += scoreToAdd;
            text.SetText(CurrentScore.ToString());
        }
    }
}