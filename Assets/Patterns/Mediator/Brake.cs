using UnityEngine;

namespace Patterns.Mediator
{
    public class Brake : MonoBehaviour
    {
        private Vehicle vehicle;

        public void Configure(Vehicle vehicle)
        {
            this.vehicle = vehicle;
        }

        private void Update()
        {
            if (UnityEngine.Input.GetButtonDown("Brake"))
            {
                vehicle.BrakePressed();
            }
            else if (UnityEngine.Input.GetButtonUp("Brake"))
            {
                vehicle.BrakeRelease();
            }
        }
    }
}
