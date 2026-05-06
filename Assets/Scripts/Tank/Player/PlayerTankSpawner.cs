using System.Collections;
using UnityEngine;

namespace BATTLE_TANKS
{
    public class PlayerTankSpawner : GenericSingleton<PlayerTankSpawner>
    {
        protected TankModel tankModel;
        [SerializeField] protected Transform spawnPosition;
        [SerializeField] protected TankListSO tankListSO;
        [SerializeField] protected PlayerTankView playerTankView;
        [SerializeField] private GameObject cam;

        private void Start()
        {
            SpawnPlayerTank();
        }

        protected void SpawnPlayerTank()
        {
            int tankNumber = Random.Range(0, tankListSO.tankSOArray.Length);
            tankModel = new TankModel(tankListSO.tankSOArray[2]);
            new PlayerTankController(tankModel, playerTankView,
                spawnPosition.position);
        }

        public void SetCameraToFollowPlayer(Transform playerTransform)
        {
            cam.transform.SetParent(playerTransform);
        }
    }
}
