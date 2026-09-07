using UnityEngine;

namespace Patterns.Singleton
{
    public class ScoreSystemMonoBehaviour : MonoBehaviour
    {
        private static ScoreSystemMonoBehaviour instance;
        private int currentScore;

        public static ScoreSystemMonoBehaviour Instance()
        {
            if (instance == null)
            {
                var gameObject = new GameObject();
                instance = gameObject.AddComponent<ScoreSystemMonoBehaviour>();
            }
            return instance;
        }

        public void AddScore(int score)
        {
            currentScore += score;
            Debug.Log(currentScore);
        }
    }
}