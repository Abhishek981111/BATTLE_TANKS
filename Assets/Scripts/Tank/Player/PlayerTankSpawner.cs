using UnityEngine;

namespace BATTLE_TANKS
{
    public class PlayerTankSpawner : GenericSingleton<PlayerTankSpawner>
    {
        private TankModel tankModel;
        [SerializeField] private Vector3 spawnPosition;
        [SerializeField] private TankListSO tankListSO;
        [SerializeField] private PlayerTankView playerTankView;
        [SerializeField] private FixedJoystick fixedJoystick;
        public PlayerTankController playerTankController { get; private set; }


        private void Start()
        {
            SpawnPlayerTank();
        }

        private void SpawnPlayerTank()
        {
            int tankNumber = Random.Range(0, tankListSO.tankSOArray.Length);
            tankModel = new TankModel(tankListSO.tankSOArray[tankNumber]);

            playerTankController = new PlayerTankController(tankModel, playerTankView, 
            spawnPosition, fixedJoystick);
        }

    }
}
