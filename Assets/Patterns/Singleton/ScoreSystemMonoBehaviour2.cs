using TMPro;
using UnityEngine;

namespace Patterns.Singleton
{
    public class ScoreSystemMonoBehaviour2 : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        private static ScoreSystemMonoBehaviour2 instance;
        private int currentScore;

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            instance = this;
        }

        public static ScoreSystemMonoBehaviour2 Instance()
        {
            return instance;
        }

        public void AddScore(int score)
        {
            currentScore += score;
            Debug.Log(currentScore);
            text.SetText(currentScore.ToString());
        }
    }
}