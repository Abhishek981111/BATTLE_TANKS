using UnityEngine;

namespace BATTLE_TANKS
{
    public class EnemyTankController 
    {
        public EnemyTankView enemyTankView { get; private set; }
        public TankModel tankModel { get; } 
        public TankHealth tankHealth { get; }
        private EnemyStateMachine enemyStateMachine;


        public EnemyTankController(TankModel tankModel, EnemyTankView enemyTankView, Vector3 spawnPosition)
        {
            this.tankModel = tankModel;
            this.enemyTankView = enemyTankView;
            tankHealth = new TankHealth(tankModel.health);
            Initialize(spawnPosition);
        }

        private void Initialize(Vector3 position)
        {
            enemyTankView = GameObject.Instantiate<EnemyTankView>(enemyTankView, position, 
            Quaternion.identity);

            enemyStateMachine = enemyTankView.GetComponent<EnemyStateMachine>();
            enemyTankView.SetTankController(this);
            enemyStateMachine.SetEnemyTankController(this);
        }

        public void DestroyTank()
        {
            if(enemyTankView == null)
            {
                return;
            }
            enemyStateMachine.SetState(enemyStateMachine.deadState);
            enemyTankView = null;
        }

        public bool IsTankAlive()
        {
            return !tankHealth.IsDead();
        }
    }
}
