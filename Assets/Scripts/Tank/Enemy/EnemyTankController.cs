using UnityEngine;
using UnityEngine.AI;

namespace BATTLE_TANKS
{
    public class EnemyTankController 
    {
        private EnemyTankView enemyTankView;
        public TankModel tankModel { get; private set; } 
        private TankHealth tankHealth;
        private NavMeshAgent navMeshAgent;
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

            navMeshAgent = enemyTankView.GetComponent<NavMeshAgent>();

            enemyStateMachine = enemyTankView.GetComponent<EnemyStateMachine>();
            enemyTankView.SetTankController(this);
            enemyStateMachine.SetEnemyTankController(this);
        }

        public Material GetMaterial()
        {
            return tankModel.tankMaterial;
        }

        public void ReduceHealth(float damage)
        {
            tankHealth.ReduceHealth(damage);

            if(tankHealth.IsDead())
            {
                DestroyTank();
            }
        }

        public float GetCollisionDamage()
        {
            return tankModel.damage;
        }

        private void DestroyTank()
        {
            if(enemyTankView == null)
            {
                return;
            }
            navMeshAgent.isStopped = true;
            enemyTankView.ShowEffectAndDestroy();
            enemyTankView = null;
        }

        public void KillTank()
        {
            tankHealth.ReduceHealth(tankModel.health);
            DestroyTank();
        }

        public bool IsTankAlive()
        {
            return !tankHealth.IsDead();
        }
    }
}
