using UnityEngine;

namespace Input
{
    public class UnityInputAdapter : Input
    {
        public Vector2 GetDirection()
        {
            float horizontalDir = UnityEngine.Input.GetAxis("Horizontal");
            float verticalDir = UnityEngine.Input.GetAxis("Vertical");
            return new Vector2(horizontalDir, verticalDir);
        }

        public bool GetFire()
        {
            return UnityEngine.Input.GetButton("Fire1");
        }
    }
}