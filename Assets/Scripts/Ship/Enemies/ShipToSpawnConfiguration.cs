using UnityEditor;
using UnityEngine;

namespace Ships.Enemies
{
    [CreateAssetMenu(menuName = "Enemies/Create ShipToSpawnConfiguration", fileName = "ShipToSpawnConfiguration", order = 0)]
    public class ShipToSpawnConfiguration : ScriptableObject
    {
        [SerializeField] private ShipId shipId;
        [SerializeField] private ProjectileId defaultProjectileId;
        [SerializeField] private Vector2 speed;
        [SerializeField] private float fireRate;
        [SerializeField] private int health;
        [SerializeField] private int score;

        public ShipId ShipId => shipId;
        public ProjectileId DefaultProjectileId => defaultProjectileId;
        public Vector2 Speed => speed;
        public float FireRate => fireRate;
        public int Health => health;
        public int Score => score;

    }
}