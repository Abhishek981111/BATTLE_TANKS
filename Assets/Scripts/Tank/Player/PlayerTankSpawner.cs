using UnityEngine;
using System.Collections;

namespace BATTLE_TANKS
{
    public class PlayerTankSpawner : GenericSingleton<PlayerTankSpawner>
    {
        private TankModel tankModel;
        [SerializeField] private Vector3 spawnPosition;
        [SerializeField] private TankListSO tankListSO;
        [SerializeField] private PlayerTankView playerTankView;
        [SerializeField] private GameObject cam;
        [SerializeField] private FixedJoystick fixedJoystick;


        private void Start()
        {
            SpawnPlayerTank();
        }

        private void SpawnPlayerTank()
        {
            int tankNumber = Random.Range(0, tankListSO.tankSOArray.Length);
            tankModel = new TankModel(tankListSO.tankSOArray[tankNumber]);

            new PlayerTankController(tankModel, playerTankView,
                spawnPosition, fixedJoystick);
        }

        public void StartFollowingPlayer(Transform playerTransform)
        {
            cam.transform.position = playerTransform.position + new Vector3 ( 0, 12, -8);
            cam.transform.SetParent(playerTransform);
        }

        public void StopFollowingPlayer()
        {
            cam.transform.SetParent(null);
        }
    }
}
