using System.Collections.Generic;
using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    [CreateAssetMenu(menuName = "Projectile/Create ProjectilesConfiguration", fileName = "ProjectilesConfiguration", order = 0)]
    public class ProjectilesConfiguration : ScriptableObject
    {
        [SerializeField] private Projectile[] projectilesPrefabs;
        private Dictionary<string, Projectile> idToProjectilePrefab;

        private void Awake()
        {
            idToProjectilePrefab = new Dictionary<string, Projectile>();

            foreach (var projectile in projectilesPrefabs)
            {
                idToProjectilePrefab.Add(projectile.Id, projectile);
            }
        }

        public Projectile GetProjectileById(string id)
        {
            if (!idToProjectilePrefab.TryGetValue(id, out var projectile))
            {
                throw new System.Exception($"Projectile {id} not found");
            }

            return projectile;
        }
    }
}