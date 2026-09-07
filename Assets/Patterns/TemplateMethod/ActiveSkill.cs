using System;
using UnityEngine;

namespace Patterns.TemplateMethod
{
    public abstract class ActiveSkill : ScriptableObject
    {
        [SerializeField] private float cooldownSeconds;
        private float currentCooldown;

        public bool isReady()
        {
            return currentCooldown <= 0 && DoIsReady();
        }

        public void Activate(Hero hero)
        {
            DoActivate(hero);
            SetCooldown();
        }

        private void SetCooldown()
        {
            currentCooldown = cooldownSeconds;
        }

        public void Update()
        {
            currentCooldown -= Time.deltaTime;
            currentCooldown = Math.Max(0, currentCooldown);
            DoUpdate();
        }

        protected abstract bool DoIsReady();
        protected abstract void DoUpdate();
        protected abstract void DoActivate(Hero hero);
    }
}