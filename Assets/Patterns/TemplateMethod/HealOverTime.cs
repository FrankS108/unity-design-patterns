using UnityEngine;

namespace Patterns.TemplateMethod
{
    [CreateAssetMenu(menuName = "TemplateMethod/Create HealOverTime", fileName = "HealSkill", order = 0)]
    public class HealOverTime : ActiveSkill
    {
        [SerializeField] private float secondsActive;
        [SerializeField] private int healthToAdd;
        [SerializeField] private int charges;
        private float currentTimeInSeconds;
        private Hero hero;
        private bool isActivate;


        protected override void DoUpdate()
        {
            if (!isActivate)
            {
                return;
            }

            currentTimeInSeconds += Time.deltaTime;

            healthToAdd = 10;
            hero.AddHealth(healthToAdd * Time.deltaTime);

            if (currentTimeInSeconds > secondsActive)
            {
                isActivate = false;
                return;
            }
        }

        protected override void DoActivate(Hero hero)
        {
            isActivate = true;
            currentTimeInSeconds = 0;
            this.hero = hero;
        }

        protected override bool DoIsReady()
        {
            return charges > 0;
        }
    }
}