using System.Collections;
using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    public class LinealProjectile : Projectile
    {
        [SerializeField] private float speed;
        [SerializeField] private float destroyTimeInSeconds;

        protected override void DoStart()
        {
            rigidBody2D.linearVelocity = transform.up * speed;
        }

        protected override void DoMove()
        {

        }

        protected override void DoDestroy()
        {

        }

    }
}