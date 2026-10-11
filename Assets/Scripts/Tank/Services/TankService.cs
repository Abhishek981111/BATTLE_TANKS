using UnityEngine;
using System.Collections.Generic;

namespace BATTLE_TANKS
{
    public class TankService : GenericSingleton<TankService>
    {
        public PlayerTankController playerTankController { get; private set; }
        public List<EnemyTankController> enemyTankControllerList { get; private set; }
        [SerializeField] private FixedJoystick fixedJoystick;
        [SerializeField] private float enemyTankCount;


        private void Start()
        {
            playerTankController = TankSpawner.Instance.SpawnPlayerTank(Vector3.zero);
            enemyTankControllerList = new List<EnemyTankController>();
            for (int i = 0; i < enemyTankCount; i++)
            {
                enemyTankControllerList.Add(TankSpawner.Instance.SpawnEnemyTank());
            }
        }

        public FixedJoystick GetFixedJoystick()
        {
            return fixedJoystick;
        }

        public Vector3 GetPlayerTankPosition()
        {
            return playerTankController.GetTankPosition();
        }

        public bool IsPlayerTankAlive()
        {
            return playerTankController.IsTankAlive();
        }

        public void RespawnEnemyTank()
        {
            if(IsPlayerTankAlive() == true)
            {
                enemyTankControllerList.Add(TankSpawner.Instance.SpawnEnemyTank());
            }
        }
    }
}
