using UnityEngine;

namespace Input
{
    class JoystickInputAdapter : Input
    {
        private readonly Joystick joystick;
        private readonly JoyButton joyButton;

        public JoystickInputAdapter(Joystick joystick, JoyButton joyButton)
        {
            this.joystick = joystick;
            this.joyButton = joyButton;
        }

        public Vector2 GetDirection()
        {
            return new Vector2(joystick.Horizontal, joystick.Vertical);
        }

        public bool GetFire()
        {
            return joyButton.IsPressed;
        }
    }
}