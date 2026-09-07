using Ships;
using UnityEngine;

namespace Input
{
    public class AIInputAdapter : Input
    {
        [SerializeField] private float minScreen = 0.05f;
        [SerializeField] private float maxScreen = 0.95f;
        private readonly ShipMediator ship;
        private Transform shipTransform;
        private Camera cameraMain;
        private float currentDirectionX;


        public AIInputAdapter(ShipMediator ship)
        {
            this.ship = ship;
            this.currentDirectionX = 1;
            this.shipTransform = this.ship.transform;
            this.cameraMain = Camera.main;
        }
        public Vector2 GetDirection()
        {
            Vector3 viewportPoint = cameraMain.WorldToViewportPoint(shipTransform.position);

            if (viewportPoint.x < minScreen)
            {
                currentDirectionX = -shipTransform.right.x;
            }
            else if (viewportPoint.x > maxScreen)
            {
                currentDirectionX = shipTransform.right.x;
            }

            return new Vector2(currentDirectionX, -1);
        }

        public bool GetFire()
        {
            return Random.Range(0, 100) < 20;
        }
    }
}