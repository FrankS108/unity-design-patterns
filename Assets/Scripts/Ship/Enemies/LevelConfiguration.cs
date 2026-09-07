using UnityEngine;

namespace Ships.Enemies
{
    [CreateAssetMenu(menuName = "Enemies/Create LevelConfiguration", fileName = "LevelConfiguration", order = 0)]

    public class LevelConfiguration : ScriptableObject
    {
        [SerializeField] private SpawnConfiguration[] spawnConfigurations;

        public SpawnConfiguration[] SpawnConfigurations => spawnConfigurations;
    }
}