using UnityEngine;
namespace Patterns.Mediator
{
    public class Autopilot : MonoBehaviour
    {
        private Vehicle vehicle;

        public void Configure(Vehicle vehicle)
        {
            this.vehicle = vehicle;
        }

        void OnTriggerEnter(Collider other)
        {
            vehicle.ObstacleDetected();
        }
    }
}