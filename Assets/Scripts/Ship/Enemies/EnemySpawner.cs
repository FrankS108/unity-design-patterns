using System;
using System.Collections.Generic;
using Input;
using NUnit.Framework.Constraints;
using Ships.CheckLimits;
using Ships.Common;
using UnityEngine;

namespace Ships.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPositions;
        [SerializeField] private LevelConfiguration levelConfiguration;
        [SerializeField] private ShipsConfiguration shipsConfiguration;
        private ShipFactory shipFactory;
        private float currentTimeInSeconds;
        private int currentConfigurationIndex;
        private bool canSpawn;
        private List<ShipMediator> spawnedShips;

        private void Awake()
        {
            spawnedShips = new List<ShipMediator>();
            shipFactory = new ShipFactory(Instantiate(shipsConfiguration));
        }

        public void StartSpawn()
        {
            canSpawn = true;
        }

        public void StopAndReset()
        {
            canSpawn = false;
            currentTimeInSeconds = 0;
            currentConfigurationIndex = 0;
            if (spawnedShips.Count > 0)
            {
                foreach (var shipMediator in spawnedShips)
                {
                    Destroy(shipMediator.gameObject);
                }
            }
            spawnedShips.Clear();
        }

        private void Update()
        {
            if (!canSpawn) return;
            if (currentConfigurationIndex >= levelConfiguration.SpawnConfigurations.Length)
            {
                return;
            }

            currentTimeInSeconds += Time.deltaTime;

            var spawnConfiguration = levelConfiguration.SpawnConfigurations[currentConfigurationIndex];

            if (spawnConfiguration.TimeToSpawn > currentTimeInSeconds)
            {
                return;
            }

            SpawnShips(spawnConfiguration);
            currentConfigurationIndex += 1;
        }

        private void SpawnShips(SpawnConfiguration spawnConfiguration)
        {
            for (int i = 0; i < spawnConfiguration.ShipToSpawnConfigurations.Length; i++)
            {
                var shipConfiguration = spawnConfiguration.ShipToSpawnConfigurations[i];
                var spawnPosition = spawnPositions[i % spawnPositions.Length];
                var shipBuilder = shipFactory.Create(
                    shipConfiguration.ShipId.Value
                );
                var ship = shipBuilder
                    .WithInputMode(ShipBuilder.InputMode.AI)
                    .WithCheckLimitsType(
                        ShipBuilder.CheckLimitTypes.InitialPosition
                    )
                    .WithConfiguration(shipConfiguration)
                    .WithPosition(spawnPosition.position)
                    .WithRotation(spawnPosition.rotation)
                    .WithTeam(Teams.Enemy)
                    .Build();
                spawnedShips.Add(ship);
            }
        }

    }
}