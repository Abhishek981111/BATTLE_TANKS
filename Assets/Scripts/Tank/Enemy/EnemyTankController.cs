using UnityEngine;

namespace BATTLE_TANKS
{
    public class EnemyTankController 
    {
        private EnemyTankAI enemyTankAI;
        private EnemyTankView enemyTankView;
        private EnemyTankModel enemyTankModel;  
        private TankHealth tankHealth;
        private int currentPathNumber;

        public EnemyTankController(EnemyTankModel enemyTankModel, EnemyTankView enemyTankView)
        {
            this.enemyTankModel = enemyTankModel;
            this.enemyTankView = enemyTankView;
            tankHealth = new TankHealth(enemyTankModel.health);
            currentPathNumber = 0;
            Initialize(enemyTankModel.patrolPath[0]);
        }

        private void Initialize(Vector3 position)
        {
            enemyTankView = GameObject.Instantiate<EnemyTankView>(enemyTankView, position, 
                Quaternion.identity);
            enemyTankView.SetTankController(this);
        }

        public Material GetMaterial()
        {
            return enemyTankModel.tankMaterial;
        }

        public void ReduceHealth(float damage)
        {
            tankHealth.ReduceHealth(damage);
            if(tankHealth.IsAlive()){
                return;
            }
            enemyTankView.DestroyTank();
        }

        public Vector3 GetNextDestination()
        {
            int nextPathNumber;
            do 
            {
                nextPathNumber = Random.Range(0, enemyTankModel.patrolPath.Length);
            }   while (currentPathNumber == nextPathNumber);
            
            currentPathNumber = nextPathNumber;
            return enemyTankModel.patrolPath[nextPathNumber];
        }
    }
}
