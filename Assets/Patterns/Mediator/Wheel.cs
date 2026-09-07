using UnityEngine;

namespace Patterns.Mediator
{
    public class Wheel : MonoBehaviour
    {
        private Vehicle vehicle;

        public void Configure(Vehicle vehicle)
        {
            this.vehicle = vehicle;
        }

        public void AddFriction()
        {
        }

        public void RemoveFriction()
        {
        }

        public void TurnLeft()
        {
        }

        public void TurnRight()
        {
        }
    }
}
