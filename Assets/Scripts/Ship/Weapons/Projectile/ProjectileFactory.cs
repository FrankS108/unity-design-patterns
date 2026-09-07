using Ships.Common;
using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    public class ProjectileFactory
    {
        private ProjectilesConfiguration projectilesConfiguration;

        public ProjectileFactory(ProjectilesConfiguration projectilesConfiguration)
        {
            this.projectilesConfiguration = projectilesConfiguration;
        }

        public Projectile Create(string projectileId, Vector3 position, Quaternion rotation, Teams team)
        {
            var projectilePrefab = projectilesConfiguration.GetProjectileById(projectileId);
            var projectile = Object.Instantiate(projectilePrefab, position, rotation);
            projectile.Configure(team);
            return projectile;
        }
    }
}