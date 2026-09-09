using UnityEngine;
using Ships.Weapons;
using Ships.Movement;
using Ships.Common;
using UI;
using Common;

namespace Ships
{
    public class ShipMediator : MonoBehaviour, Ship, EventObserver
    {
        [SerializeField] private MovementController movementController;
        [SerializeField] private WeaponController weaponController;
        [SerializeField] private HealthController healthController;
        [SerializeField] public ShipId shipId;


        private CheckDestroyLimits.CheckDestroyLimits checkDestroyLimits;
        private Input.Input input;
        private Teams team;
        private int score;

        public string Id => shipId.Value;

        public void Configure(ShipConfiguration shipConfiguration)
        {
            checkDestroyLimits = shipConfiguration.checkDestroyLimits;
            input = shipConfiguration.input;
            movementController.Configure(this, shipConfiguration.checkLimits, shipConfiguration.speed);
            weaponController.Configure(this, shipConfiguration.fireRate, shipConfiguration.defaultProjectileId, shipConfiguration.Team);
            healthController.Configure(this, shipConfiguration.health, shipConfiguration.Team);
            team = shipConfiguration.Team;
            score = shipConfiguration.score;
        }

        private void Start()
        {
            EventQueue.Instance.Subscribe(EventIds.GameOver, this);
            EventQueue.Instance.Subscribe(EventIds.Victory, this);
        }

        private void OnDestroy()
        {
            EventQueue.Instance.Unsubscribe(EventIds.GameOver, this);
            EventQueue.Instance.Unsubscribe(EventIds.Victory, this);
        }

        private void FixedUpdate()
        {
            Vector2 direction = input.GetDirection(); ;
            movementController.Move(direction);
        }

        void Update()
        {
            TryShoot();
            CheckDestroyLimits();
        }

        private void CheckDestroyLimits()
        {
            if (checkDestroyLimits.isInsideTheLimits(transform.position))
            {
                return;
            }

            Destroy(gameObject);
            var shipDestroyedEventData = new ShipDestroyedEventData(0, team, GetEntityId().GetHashCode());
            EventQueue.Instance.EnqueueEvent(shipDestroyedEventData);
        }

        private void TryShoot()
        {
            if (input.GetFire())
            {
                weaponController.TryShoot();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var damageable = other.GetComponent<Damageable>();
            if (damageable.Team == team)
            {
                return;
            }
            damageable.AddDamage(100);
        }

        public void OnDamageReceived(bool isDeath)
        {
            if (isDeath)
            {
                Destroy(gameObject);
                var shipDestroyedEventData = new ShipDestroyedEventData(score, team, GetEntityId().GetHashCode());
                EventQueue.Instance.EnqueueEvent(shipDestroyedEventData);
            }
        }

        public void Process(EventData eventData)
        {
            if (
                eventData.EventId != EventIds.GameOver &&
                eventData.EventId != EventIds.Victory
            ) return;
            Destroy(gameObject);
        }
    }

}