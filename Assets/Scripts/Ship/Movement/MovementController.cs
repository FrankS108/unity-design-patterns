using UnityEngine;
namespace Ships.Movement
{
    public class MovementController : MonoBehaviour
    {
        private Vector2 speed;
        private Rigidbody2D rigidbody;
        private Vector2 currentPosition;
        private CheckLimits.CheckLimits checkLimits;
        private Ship ship;

        void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            currentPosition = rigidbody.position;
        }

        public void Configure(Ship ship, CheckLimits.CheckLimits checkLimits, Vector2 speed)
        {
            this.ship = ship;
            this.checkLimits = checkLimits;
            this.speed = speed;
        }

        public void Move(Vector2 direction)
        {
            currentPosition += direction * (speed * Time.deltaTime);
            currentPosition = checkLimits.ClampFinalPosition(currentPosition);
            rigidbody.MovePosition(currentPosition);
        }
    }
}