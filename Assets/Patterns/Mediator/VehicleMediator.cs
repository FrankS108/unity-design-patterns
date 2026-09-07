using UnityEngine;
namespace Patterns.Mediator
{
    class VehicleMediator : MonoBehaviour, Vehicle
    {
        [SerializeField] private Wheel[] wheels;
        [SerializeField] private VehicleLight[] brakeLights;
        [SerializeField] private SteeringWheel steeringWheel;
        [SerializeField] private Brake brake;
        [SerializeField] private Autopilot autopilot;


        void Awake()
        {
            foreach (var brakeLight in brakeLights)
            {
                brakeLight.Configure(this);
            }

            foreach (var wheel in wheels)
            {
                wheel.Configure(this);
            }

            brake.Configure(this);
            steeringWheel.Configure(this);
            autopilot.Configure(this);
        }

        public void BrakePressed()
        {
            foreach (var wheel in wheels)
            {
                wheel.AddFriction();
            }

            foreach (var brakeLight in brakeLights)
            {
                brakeLight.TurnOn();
            }
        }

        public void BrakeRelease()
        {
            foreach (var wheel in wheels)
            {
                wheel.RemoveFriction();
            }

            foreach (var brakeLight in brakeLights)
            {
                brakeLight.TurnOff();
            }
        }

        public void LeftPressed()
        {
            foreach (var wheel in wheels)
            {
                wheel.TurnLeft();
            }
        }

        public void RightPressed()
        {
            foreach (var wheel in wheels)
            {
                wheel.TurnRight();
            }
        }

        public void ObstacleDetected()
        {
            BrakePressed();
        }
    }
}