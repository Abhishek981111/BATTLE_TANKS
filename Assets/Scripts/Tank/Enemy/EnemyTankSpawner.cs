using BATTLETANKS;
using UnityEngine;

namespace BATTLE_TANKS
{
    public class EnemyTankSpawner : GenericSingleton<EnemyTankSpawner>
    {
        private EnemyTankModel enemyTankModel;
        [SerializeField] private TankListSO tankListSO;
        [SerializeField] private EnemyTankView enemyTankView;
        [SerializeField] private TankPatrolPathListSO tankPatrolPathListSO;

        private void Start()
        {
            SpawnEnemyTanks();
        }

        protected void SpawnEnemyTanks()
        {
            for (int i = 0; i < tankPatrolPathListSO.patrolPathList.Length; i++)
            {
                int tankNumber = Random.Range(0, tankListSO.tankSOArray.Length);
                enemyTankModel = new EnemyTankModel(tankListSO.tankSOArray[tankNumber], 
                    tankPatrolPathListSO.patrolPathList[i]);
                new EnemyTankController(enemyTankModel, enemyTankView);
            }
        }
    }
}
