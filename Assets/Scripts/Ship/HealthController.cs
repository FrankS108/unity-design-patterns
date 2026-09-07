using Ships.Common;
using UnityEngine;

namespace Ships
{
    public class HealthController : MonoBehaviour, Damageable
    {
        [SerializeField] private int health = 100;
        private Ship ship;
        public Teams Team { get; private set; }

        public void Configure(Ship ship, int health, Teams team)
        {
            this.ship = ship;
            this.health = health;
            this.Team = team;
        }

        public void AddDamage(int amount)
        {
            health = Mathf.Max(0, health - amount);
            var isDeath = health <= 0;
            ship.OnDamageReceived(isDeath);
        }
    }
}