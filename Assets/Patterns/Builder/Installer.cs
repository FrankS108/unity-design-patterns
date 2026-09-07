using System;
using Patterns.Builder.Armors;
using Patterns.Builder.Weapons;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns.Builder
{
    public class Installer : MonoBehaviour
    {
        [SerializeField] private Armor normalArmor;
        [SerializeField] private Armor reflectiveArmor;
        [SerializeField] private Weapon bow;
        [SerializeField] private Weapon sword;
        [SerializeField] private Hero heroPrefab;

        [SerializeField] private Button normalArmorButton;
        [SerializeField] private Button reflectiveArmorButton;
        [SerializeField] private Button bowButton;
        [SerializeField] private Button swordButton;
        [SerializeField] private Button buildButton;

        private HeroBuilder heroBuilder;
        private GameObject currentHero;

        private void Awake()
        {
            heroBuilder = new HeroBuilder().FromHeroPrefab(heroPrefab);
            normalArmorButton.onClick.AddListener(() => heroBuilder.WithArmor(normalArmor));
            reflectiveArmorButton.onClick.AddListener(() => heroBuilder.WithArmor(reflectiveArmor));
            swordButton.onClick.AddListener(() => heroBuilder.WithWeapon(sword));
            bowButton.onClick.AddListener(() => heroBuilder.WithWeapon(bow));

            buildButton.onClick.AddListener(InstantiateHero);
        }

        private void InstantiateHero()
        {
            if (currentHero != null)
            {
                Destroy(currentHero);
            }

            currentHero = heroBuilder.Build().gameObject;
        }
    }
}
