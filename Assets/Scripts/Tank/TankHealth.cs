using UnityEngine;

namespace BATTLE_TANKS
{
    public class TankHealth
    {
        private float currentHealth;
        private bool isAlive;


        public TankHealth(float health)
        {
            currentHealth = health;
            isAlive = true;
        }

        public void ReduceHealth(float damage)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                isAlive = false;
            }
        }

        public bool IsAlive()
        {
            return isAlive;
        }
    }
}    
