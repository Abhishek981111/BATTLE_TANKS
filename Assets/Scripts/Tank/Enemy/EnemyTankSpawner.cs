using UnityEngine;

namespace BATTLE_TANKS
{
    public class EnemyTankSpawner : GenericSingleton<EnemyTankSpawner>
    {
        private TankModel tankModel;
        [SerializeField] private Transform[] spawnPosition;
        [SerializeField] private TankListSO tankListSO;
        [SerializeField] private EnemyTankView enemyTankView;

        private void Start()
        {
            SpawnEnemyTanks();
        }

        protected void SpawnEnemyTanks()
        {
            for (int i = 0; i < spawnPosition.Length; i++)
            {
                int tankNumber = Random.Range(0, tankListSO.tankSOArray.Length);
                tankModel = new TankModel(tankListSO.tankSOArray[tankNumber]);
                
                new EnemyTankController(tankModel, enemyTankView,
                    spawnPosition[i].position);
            }
        }
    }
}
