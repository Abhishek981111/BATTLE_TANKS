using UnityEngine;

namespace BATTLE_TANKS
{
    public class EnemyTankSpawner : GenericSingleton<EnemyTankSpawner>
    {
        protected TankModel tankModel;
        [SerializeField] protected Transform spawnPosition;
        [SerializeField] protected TankListSO tankListSO;
        [SerializeField] protected EnemyTankView enemyTankView;

        private void Start()
        {
            SpawnEnemyTank();
        }

        protected void SpawnEnemyTank()
        {
            int tankNumber = Random.Range(0, tankListSO.tankSOArray.Length);
            tankModel = new TankModel(tankListSO.tankSOArray[0]);
            new EnemyTankController(tankModel, enemyTankView,
                spawnPosition.position);
        }
    }
}
