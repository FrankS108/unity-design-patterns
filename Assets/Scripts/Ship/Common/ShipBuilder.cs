
using Input;
using NUnit.Framework;
using Ships.CheckLimits;
using Ships.Enemies;
using UnityEngine;

namespace Ships.Common
{
    public class ShipBuilder
    {
        public enum InputMode
        {
            Unity,
            Joystick,
            AI
        }

        public enum CheckLimitTypes
        {
            InitialPosition,
            Viewport
        }
        private ShipMediator prefab;
        private Vector3 position;
        private Quaternion rotation = Quaternion.identity;
        private Input.Input input;
        private CheckLimits.CheckLimits checkLimits;
        private ShipToSpawnConfiguration shipConfiguration;
        private InputMode inputMode;
        private Joystick joystick;
        private JoyButton joyButton;
        private CheckLimitTypes checkLimitType;
        private Teams team;

        public ShipBuilder FromPrefab(ShipMediator prefab)
        {
            this.prefab = prefab;
            return this;
        }

        public ShipBuilder WithTeam(Teams team)
        {
            this.team = team;
            return this;
        }

        public ShipBuilder WithPosition(Vector3 position)
        {
            this.position = position;
            return this;
        }

        public ShipBuilder WithRotation(Quaternion rotation)
        {
            this.rotation = rotation;
            return this;
        }

        public ShipBuilder WithInput(Input.Input input)
        {
            this.input = input;
            return this;
        }

        public ShipBuilder WithCheckLimits(CheckLimits.CheckLimits checkLimits)
        {
            this.checkLimits = checkLimits;
            return this;
        }

        public ShipBuilder WithConfiguration(ShipToSpawnConfiguration shipConfiguration)
        {
            this.shipConfiguration = shipConfiguration;
            return this;
        }

        public ShipBuilder WithInputMode(InputMode inputMode)
        {
            this.inputMode = inputMode;
            return this;
        }

        public ShipBuilder WithJoysticks(Joystick joystick, JoyButton joyButton)
        {
            this.joystick = joystick;
            this.joyButton = joyButton;
            return this;
        }

        public ShipBuilder WithCheckLimitsType(CheckLimitTypes type)
        {
            this.checkLimitType = type;
            return this;
        }

        private CheckLimits.CheckLimits GetCheckLimits(ShipMediator ship)
        {
            if (checkLimits != null)
            {
                return checkLimits;
            }

            switch (checkLimitType)
            {
                case CheckLimitTypes.InitialPosition:
                    return new InitialPositionCheckLimits(ship.transform, 10);
                case CheckLimitTypes.Viewport:
                    return new ViewportCheckLimits(Camera.main);
                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        private Input.Input GetInput(ShipMediator shipMediator)
        {
            if (input != null)
            {
                return input;
            }

            switch (inputMode)
            {
                case InputMode.Unity:
                    return new UnityInputAdapter();
                case InputMode.Joystick:
                    Assert.IsNotNull(joystick);
                    Assert.IsNotNull(joyButton);
                    return new JoystickInputAdapter(joystick, joyButton);
                case InputMode.AI:
                    return new AIInputAdapter(shipMediator);
                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        public ShipMediator Build()
        {
            var ship = Object.Instantiate(prefab, position, rotation);
            var shipConfiguration = new ShipConfiguration(
                GetInput(ship),
                GetCheckLimits(ship),
                this.shipConfiguration.Speed,
                this.shipConfiguration.FireRate,
                this.shipConfiguration.Health,
                this.shipConfiguration.DefaultProjectileId,
                team,
                this.shipConfiguration.Score
            );

            ship.Configure(shipConfiguration);
            return ship;
        }
    }
}