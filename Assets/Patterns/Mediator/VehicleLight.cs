using UnityEngine;

namespace Patterns.Mediator
{
    public class VehicleLight : MonoBehaviour
    {
        [SerializeField] private Light light;
        private Vehicle vehicle;

        public void Configure(Vehicle vehicle)
        {
            this.vehicle = vehicle;
        }

        public void TurnOn()
        {
            light.enabled = true;
        }

        public void TurnOff()
        {
            light.enabled = false;
        }
    }
}
