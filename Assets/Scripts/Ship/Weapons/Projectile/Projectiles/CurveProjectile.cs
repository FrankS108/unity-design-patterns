using System.Collections;
using UnityEngine;

namespace Ships.Weapons.Projectiles
{
    public class CurveProjectile : Projectile
    {
        [SerializeField] private float speed;
        [SerializeField] private AnimationCurve horizontalCurvePosition;
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
            var horizontalPosition = myTransform.right * horizontalCurvePosition.Evaluate(currentTime);
            rigidBody2D.MovePosition(currentPosition + horizontalPosition);
            currentTime += Time.deltaTime;
        }

        protected override void DoDestroy()
        {

        }
    }
}