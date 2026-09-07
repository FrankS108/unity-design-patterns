using UnityEngine;

namespace Patterns.Singleton
{
    public class ScoreSystem
    {
        public static ScoreSystem Instance => instance ?? (instance = new ScoreSystem());
        private static ScoreSystem instance;
        private int currentScore;

        private ScoreSystem()
        {

        }

        public void AddScore(int score)
        {
            currentScore += score;
            Debug.Log(currentScore);
        }
    }
}