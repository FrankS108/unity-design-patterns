using UnityEngine;

namespace Ships.Common
{
    public class ShipConfiguration
    {
        public readonly Input.Input input;
        public readonly CheckLimits.CheckLimits checkLimits;
        public readonly Vector2 speed;
        public readonly float fireRate;
        public readonly int health;
        public readonly ProjectileId defaultProjectileId;
        public readonly Teams Team;
        public readonly int score;


        public ShipConfiguration(Input.Input input, CheckLimits.CheckLimits checkLimits, Vector2 speed, float fireRate, int health, ProjectileId defaultProjectileId, Teams team, int score)
        {
            this.input = input;
            this.checkLimits = checkLimits;
            this.speed = speed;
            this.fireRate = fireRate;
            this.health = health;
            this.defaultProjectileId = defaultProjectileId;
            this.Team = team;
            this.score = score;
        }
    }

}