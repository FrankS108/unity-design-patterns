using UnityEngine;

namespace Patterns.Factory
{
    [CreateAssetMenu(menuName = "Factory/Create EnemyId", fileName = "EnemyId", order = 0)]
    public class EnemyId : ScriptableObject
    {
        [SerializeField] private string value;

        public string Value => value;
    }
}