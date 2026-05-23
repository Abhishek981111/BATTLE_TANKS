using UnityEngine;

namespace BATTLE_TANKS
{
    public class EnemyTankSpawner : GenericSingleton<EnemyTankSpawner>
    {
        private TankModel tankModel;
        [SerializeField] private TankListSO tankListSO;
        [SerializeField] private EnemyTankView enemyTankView;
        [SerializeField] private Vector3[] enemyTankSpawnPoints;    

        private void Start()
        {
            SpawnEnemyTanks();
        }

        protected void SpawnEnemyTanks()
        {
            for (int i = 0; i < enemyTankSpawnPoints.Length; i++)
            {
                int tankNumber = Random.Range(0, tankListSO.tankSOArray.Length);
                tankModel = new TankModel(tankListSO.tankSOArray[tankNumber]);

                new EnemyTankController(tankModel, enemyTankView, enemyTankSpawnPoints[i]);
            }
        }
    }
}
