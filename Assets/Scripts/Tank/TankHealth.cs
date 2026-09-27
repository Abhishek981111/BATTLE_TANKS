using UnityEngine;

namespace BATTLE_TANKS
{
    public class TankHealth
    {
        private float currentHealth;
        private float maxHealth;


        public TankHealth(float health)
        {
            currentHealth = maxHealth - health;
        }

        public void ReduceHealth(float damage)
        {
            currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        }

        public bool IsDead()
        {
            return currentHealth == 0;
        }
    }
}    
