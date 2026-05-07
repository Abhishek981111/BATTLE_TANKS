using UnityEngine;

namespace BATTLE_TANKS
{
    public class PlayerTankSpawner : GenericSingleton<PlayerTankSpawner>
    {
        private TankModel tankModel;
        private PlayerInput playerInput;
        [SerializeField] private Transform spawnPosition;
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
            playerInput = new PlayerInput(fixedJoystick);

            new PlayerTankController(tankModel, playerTankView,
                spawnPosition.position, playerInput);
        }

        public void SetCameraToFollowPlayer(Transform playerTransform)
        {
            cam.transform.position = playerTransform.position;
            cam.transform.SetParent(playerTransform);
        }
    }
}
