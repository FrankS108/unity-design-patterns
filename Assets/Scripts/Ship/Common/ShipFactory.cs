using UnityEngine;

namespace Ships.Common
{
    public class ShipFactory
    {
        private readonly ShipsConfiguration configuration;

        public ShipFactory(ShipsConfiguration shipsConfiguration)
        {
            this.configuration = shipsConfiguration;
        }

        public ShipBuilder Create(string id)
        {
            var prefab = configuration.GetShipById(id);
            return new ShipBuilder()
                .FromPrefab(prefab);
        }
    }
}