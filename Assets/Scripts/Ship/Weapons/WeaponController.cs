using System.Linq;
using UnityEngine;
using Ships.Weapons.Projectiles;
using Ships.Common;

namespace Ships.Weapons
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private ProjectileId defaultProjectileId;
        private float fireRateInSeconds;
        private Teams team;
        [SerializeField] private Transform projectileSpawnPosition;
        [SerializeField] private ProjectilesConfiguration projectilesConfiguration;
        private ProjectileFactory projectileFactory;

        private float remainingSecondsToBeAbleToShoot;
        private Ship ship;
        private string activeProjectileId;

        public void Configure(Ship ship, float fireRate, ProjectileId defaultProjectileId, Teams team)
        {
            this.ship = ship;
            activeProjectileId = defaultProjectileId.Value;
            this.fireRateInSeconds = fireRate;
            this.team = team;
        }

        private void Awake()
        {
            projectileFactory = new ProjectileFactory(Instantiate(projectilesConfiguration));
        }

        public void TryShoot()
        {
            remainingSecondsToBeAbleToShoot -= Time.deltaTime;
            if (remainingSecondsToBeAbleToShoot > 0) return;
            Shoot();
        }

        private void Shoot()
        {
            projectileFactory.Create(
                activeProjectileId,
                projectileSpawnPosition.position,
                projectileSpawnPosition.rotation,
                team
            );
            remainingSecondsToBeAbleToShoot = fireRateInSeconds;
        }
    }
}