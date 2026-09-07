using System.Collections.Generic;
using UnityEngine;

namespace Ships
{
    [CreateAssetMenu(menuName = "Ship/Create ShipsConfiguration", fileName = "ShipsConfiguration", order = 0)]
    public class ShipsConfiguration : ScriptableObject
    {
        [SerializeField] private ShipMediator[] shipPrefabs;
        private Dictionary<string, ShipMediator> idToShipPrefab;

        private void Awake()
        {
            idToShipPrefab = new Dictionary<string, ShipMediator>();

            foreach (var ship in shipPrefabs)
            {
                idToShipPrefab.Add(ship.Id, ship);
            }
        }

        public ShipMediator GetShipById(string id)
        {
            if (!idToShipPrefab.TryGetValue(id, out var ship))
            {
                throw new System.Exception($"Ship {id} not found");
            }

            return ship;
        }
    }
}