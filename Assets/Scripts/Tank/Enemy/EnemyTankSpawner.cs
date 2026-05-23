using UnityEngine;
using System.Collections.Generic;

namespace BATTLE_TANKS
{
    public class EnemyTankSpawner : GenericSingleton<EnemyTankSpawner>
    {
        private TankModel tankModel;
        [SerializeField] private TankListSO tankListSO;
        [SerializeField] private EnemyTankView enemyTankView;
        [SerializeField] private Vector3[] enemyTankSpawnPoints;    
        private List<EnemyTankController> enemyTanks;

        private void Start()
        {
            SpawnEnemyTanks();
        }

        private void SpawnEnemyTanks()
        {
            enemyTanks = new List<EnemyTankController>();
            for (int i = 0; i < enemyTankSpawnPoints.Length; i++)
            {
                int tankNumber = Random.Range(0, tankListSO.tankSOArray.Length);
                tankModel = new TankModel(tankListSO.tankSOArray[tankNumber]);

                enemyTanks.Add(new EnemyTankController(tankModel, enemyTankView, enemyTankSpawnPoints[i]));
            }
        }
        public void DestroyAllEnemyTanks()
        {
            for (int i = 0; i < enemyTankSpawnPoints.Length; i++)
            {
                enemyTanks[i].DestroyTank();
            }
        }
    }
}
