using UnityEngine;

namespace Ships.CheckLimits
{
    public class InitialPositionCheckLimits : CheckLimits
    {
        private readonly Transform transform;
        private readonly Vector3 initialPosition;
        private readonly float maxDistance;

        public InitialPositionCheckLimits(Transform transform, float maxDistance)
        {
            this.transform = transform;
            this.maxDistance = maxDistance;
            initialPosition = transform.position;
        }

        public Vector2 ClampFinalPosition(Vector2 currentPosition)
        {
            Vector3 finalPosition = currentPosition;
            var distance = Mathf.Abs(currentPosition.x - initialPosition.x);

            if (distance <= maxDistance)
            {
                return currentPosition;
            }

            if (currentPosition.x > initialPosition.x)
            {
                finalPosition.x = initialPosition.x + maxDistance;
            }
            else
            {
                finalPosition.x = initialPosition.x - maxDistance;
            }

            return finalPosition;
        }
    }

}