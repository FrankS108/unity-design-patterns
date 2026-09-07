using System;
using UnityEngine;

namespace Ships.Enemies
{
    [Serializable]
    public class SpawnConfiguration
    {
        [SerializeField] private ShipToSpawnConfiguration[] shipToSpawnConfigurations;
        [SerializeField] private float timeToSpawn;

        public ShipToSpawnConfiguration[] ShipToSpawnConfigurations => shipToSpawnConfigurations;
        public float TimeToSpawn => timeToSpawn;
    }
}