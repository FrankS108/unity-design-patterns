using Patterns.Builder.Armors;
using Patterns.Builder.Weapons;
using UnityEngine;

namespace Patterns.Builder
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private Transform weaponPosition;
        [SerializeField] private Transform armorPosition;

        public void SetComponents(Weapon weapon, Armor armor)
        {
            weapon.transform.position = weaponPosition.position;
            armor.transform.position = armorPosition.position;
        }
    }
}