using UnityEngine;

namespace BATTLE_TANKS
{
    public class EnemyTankAI
    {

        private TankMovement tankMovement;
        private TankRotation tankRotation;
        private float currentDuration;
        private float minDuration = 2f;
        private float maxDuration = 5f;

        public EnemyTankAI()
        {
            RandomTankAction();
        }

        public void UpdateDuration(float deltaTime)
        {
            currentDuration -= deltaTime;
            if (currentDuration <= 0f)
            {
                RandomTankAction();
            }
        }

        private void RandomTankAction()
        {
            tankMovement = (TankMovement)Random.Range(0, 2);
            tankRotation = (TankRotation)Random.Range(0, 3);
            currentDuration = Random.Range(minDuration, maxDuration);
        }

        public float GetEnemyInputVertical()
        {
            if (tankMovement == TankMovement.FORWARD)
            {
                return 1f;
            }
            return 0f;
        }

        public float GetEnemyInputHorizontal()
        {
            if (tankRotation == TankRotation.LEFT)
            {
                return -1f;
            }
            else if (tankRotation == TankRotation.RIGHT)
            {
                return 1f;
            }
            return 0f;
        }
    }
}


