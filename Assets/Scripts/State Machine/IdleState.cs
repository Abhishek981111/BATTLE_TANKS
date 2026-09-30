using UnityEngine;

namespace BATTLE_TANKS
{
    public class IdleState : State
    {

        private float idleTime = 5f;
        private float timeElapsed;


        public IdleState(EnemyTankController enemyTankController) : base(enemyTankController){}

        public override void OnStateEnter()
        {
            timeElapsed = 0f;
        }

        public override void Tick()
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed >= idleTime)
            {
                enemyTankController.SetState(new PatrolState(enemyTankController));
            }
        }
    }
}
