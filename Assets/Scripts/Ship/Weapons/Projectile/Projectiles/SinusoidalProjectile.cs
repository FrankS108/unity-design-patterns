using System.Collections;
using Ships.CheckLimits;
using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    public class SinusoidalProjectile : Projectile
    {
        [SerializeField] private float speed;
        [SerializeField] private float amplitude;
        [SerializeField] private float frequency;
        private Vector3 currentPosition;
        private float currentTime;

        protected override void DoStart()
        {
            currentTime = 0;
            currentPosition = myTransform.position;
        }

        protected override void DoMove()
        {
            currentPosition += myTransform.up * (speed * Time.deltaTime);
            var horizontalPosition = myTransform.right * (amplitude * Mathf.Sin(currentTime * frequency));
            rigidBody2D.MovePosition(currentPosition + horizontalPosition);
            currentTime += Time.deltaTime;
        }

        protected override void DoDestroy()
        {

        }
    }
}