using Patterns.Builder.Armors;
using Patterns.Builder.Weapons;
using UnityEngine;

namespace Patterns.Builder
{
    public class HeroBuilder
    {
        private Hero prefab;
        private Armor armor;
        private Weapon weapon;

        public HeroBuilder WithArmor(Armor armor)
        {
            this.armor = armor;
            return this;
        }

        public HeroBuilder WithWeapon(Weapon weapon)
        {
            this.weapon = weapon;
            return this;
        }

        public HeroBuilder FromHeroPrefab(Hero prefab)
        {
            this.prefab = prefab;
            return this;
        }

        public Hero Build()
        {
            var hero = Object.Instantiate(prefab);
            var weapon = Object.Instantiate(this.weapon, hero.transform);
            var armor = Object.Instantiate(this.armor, hero.transform);
            hero.SetComponents(weapon, armor);

            return hero;
        }
    }
}
