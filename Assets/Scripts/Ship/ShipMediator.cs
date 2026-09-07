using UnityEngine;
using Ships.Weapons;
using Ships.Movement;
using Ships.Weapons.Projectiles;
using Ships.Common;
using UI;
using UnityEngine.SocialPlatforms.Impl;

namespace Ships
{
    public class ShipMediator : MonoBehaviour, Ship
    {
        [SerializeField] private MovementController movementController;
        [SerializeField] private WeaponController weaponController;
        [SerializeField] private HealthController healthController;
        private Input.Input input;

        [SerializeField] public ShipId shipId;
        private Teams team;
        private int score;

        public string Id => shipId.Value;

        public void Configure(ShipConfiguration shipConfiguration)
        {
            this.input = shipConfiguration.input;
            movementController.Configure(this, shipConfiguration.checkLimits, shipConfiguration.speed);
            weaponController.Configure(this, shipConfiguration.fireRate, shipConfiguration.defaultProjectileId, shipConfiguration.Team);
            healthController.Configure(this, shipConfiguration.health, shipConfiguration.Team);
            team = shipConfiguration.Team;
            score = shipConfiguration.score;
        }

        private void FixedUpdate()
        {
            Vector2 direction = input.GetDirection(); ;
            movementController.Move(direction);
        }

        void Update()
        {
            TryShoot();
        }

        private void TryShoot()
        {
            if (input.GetFire())
            {
                weaponController.TryShoot();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var damageable = other.GetComponent<Damageable>();
            if (damageable.Team == team)
            {
                return;
            }
            damageable.AddDamage(100);
        }

        public void OnDamageReceived(bool isDeath)
        {
            if (isDeath)
            {
                ScoreView.Instance.AddScore(team, score);
                Destroy(gameObject);
                if (team == Teams.Ally)
                {
                    GameOverView.Instance.Show();
                }
            }
        }

    }

}