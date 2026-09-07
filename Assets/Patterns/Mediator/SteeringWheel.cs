using UnityEngine;

namespace Patterns.Mediator
{
    public class SteeringWheel : MonoBehaviour
    {
        private Vehicle vehicle;

        public void Configure(Vehicle vehicle)
        {
            this.vehicle = vehicle;
        }

        private void Update()
        {
            if (UnityEngine.Input.GetButtonDown("Left"))
            {
                vehicle.LeftPressed();
            }
            else if (UnityEngine.Input.GetButtonDown("Right"))
            {
                vehicle.RightPressed();
            }
        }
    }
}
