using UnityEngine;

namespace Patterns.Factory
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyId id;

        public string Id => id.Value;
    }
}