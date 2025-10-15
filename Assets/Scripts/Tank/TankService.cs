using UnityEngine;
using System.Collections.Generic;

namespace BATTLE_TANKS
{
    public class TankService : GenericSingleton<TankService>
    {
        private TankModel tankModel;
        private TankController tankController;
        private List<EnemyTankAI> enemyTankAIList;
        [SerializeField] private FixedJoystick joystick;
        [SerializeField] private GameObject cam;
        [SerializeField] private TankListSO tankListSO;
        [SerializeField] private TankView tankView;


        private void Start()
        {
            SpawnPlayerTank();
            enemyTankAIList = new List<EnemyTankAI>();
            SpawnEnemyTanks();
        }

        private void Update()
        {
            CheckPlayerInput();
            UpdateEnemyTankAI();
        }

        private void CheckPlayerInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                tankController.FireBullet();
            }
        }
        
        private void UpdateEnemyTankAI()
        {
            for(int i=0; i< enemyTankAIList.Count; i++)
            {
                enemyTankAIList[i].UpdateDuration(Time.deltaTime);
            }
        }

        private void SpawnPlayerTank()
        {
            int randomTankNumber = Random.Range(0, tankListSO.tankSOArray.Length);
            tankModel = new TankModel(tankListSO.tankSOArray[randomTankNumber]);
            tankController = new PlayerTankController(tankModel, tankView);
        }

        private void SpawnEnemyTanks()
        {
            for (int i = 1; i <= 3; i++)
            {
                SpawnEnemyTank(new Vector3(-i*10, 0, 0));
            }
        }

        private void SpawnEnemyTank(Vector3 position)
        {
            int randomTankNumber = Random.Range(0, tankListSO.tankSOArray.Length);
            tankModel = new TankModel(tankListSO.tankSOArray[randomTankNumber]);
            new EnemyTankController(tankModel, tankView, position);
        }

        public void SetCameraToFollowPlayer(Transform player)
        {
            cam.transform.SetParent(player);
        }

        public void SetEnemyTankForUpdate(EnemyTankAI enemyTankAI)
        {
            enemyTankAIList.Add(enemyTankAI);
        }

        public float GetPlayerInputHorizontal()
        {
            if (Mathf.Abs(joystick.Horizontal) > Mathf.Epsilon)
            {
                return joystick.Horizontal;
            }
            return Input.GetAxisRaw("Horizontal");
        }

        public float GetPlayerInputVertical()
        {
            if (Mathf.Abs(joystick.Vertical) > Mathf.Epsilon)
            {
                return joystick.Vertical;
            }
            return Input.GetAxisRaw("Vertical");
        }
    }
}
