using System;
using System.Collections;
using Ships.Common;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Projectile : MonoBehaviour, Damageable
    {
        [SerializeField] private ProjectileId id;
        [SerializeField] protected Rigidbody2D rigidBody2D;
        [SerializeField] private float destroyTimeInSeconds;
        public Teams Team { get; private set; }
        protected Transform myTransform;
        public string Id => id.Value;

        public void Configure(Teams team)
        {
            this.Team = team;
        }

        private void Start()
        {
            myTransform = transform;
            DoStart();
            StartCoroutine(DestroyIn(destroyTimeInSeconds));
        }

        private void FixedUpdate()
        {
            DoMove();
        }
        private IEnumerator DestroyIn(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            DestroyProjectile();
        }

        private void DestroyProjectile()
        {
            DoDestroy();
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var damageable = other.GetComponent<Damageable>();
            if (damageable.Team == Team)
            {
                return;
            }
            damageable.AddDamage(100);
        }

        protected abstract void DoStart();
        protected abstract void DoMove();
        protected abstract void DoDestroy();

        public void AddDamage(int amount)
        {
            DestroyProjectile();
        }
    }
}