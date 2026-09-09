using System;
using Input;
using Ships.CheckLimits;
using Ships.Common;
using Ships.Enemies;
using UnityEngine;

namespace Ships
{
    public class ShipInstaller : MonoBehaviour
    {
        [SerializeField] private bool useAI;
        [SerializeField] private bool useJoystick;
        [SerializeField] private Joystick joystick;
        [SerializeField] private JoyButton joyButton;
        [SerializeField] private ShipMediator ship;
        [SerializeField] private ShipToSpawnConfiguration shipConfiguration;
        [SerializeField] private ShipsConfiguration shipsConfiguration;
        private ShipBuilder shipBuilder;

        void Awake()
        {
            var shipFactory = new ShipFactory(Instantiate(shipsConfiguration));
            shipBuilder = shipFactory
                .Create(shipConfiguration.ShipId.Value)
                .WithConfiguration(shipConfiguration)
                .WithTeam(Teams.Ally);

            SetInput(shipBuilder);
            SetCheckLimitsStrategy(shipBuilder);

        }

        public void SpawnUserShip()
        {
            shipBuilder.Build();
        }

        private void SetCheckLimitsStrategy(ShipBuilder shipBuilder)
        {
            if (useAI)
            {
                shipBuilder.WithCheckLimitsType(
                    ShipBuilder.CheckLimitTypes.InitialPosition
                );
                return;
            }

            shipBuilder.WithCheckLimitsType(ShipBuilder.CheckLimitTypes.Viewport);
        }

        private void SetInput(ShipBuilder shipBuilder)
        {
            if (useAI)
            {
                shipBuilder.WithInputMode(ShipBuilder.InputMode.AI);
                Destroy(joystick.gameObject);
                Destroy(joyButton.gameObject);
                return;
            }
            if (useJoystick)
            {
                shipBuilder.WithInputMode(ShipBuilder.InputMode.Joystick);
                shipBuilder.WithJoysticks(joystick, joyButton);
                return;
            }


            Destroy(joystick.gameObject);
            Destroy(joyButton.gameObject);
            shipBuilder.WithInputMode(ShipBuilder.InputMode.Unity);
            return;
        }
    }
}