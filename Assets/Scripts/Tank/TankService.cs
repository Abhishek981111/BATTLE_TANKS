using UnityEngine;

namespace BATTLE_TANKS
{
    public class TankService : GenericSingleton<TankService>
    {
        private TankModel tankModel;
        private TankController tankController;
        [SerializeField] private FixedJoystick joystick;
        [SerializeField] private GameObject cam;
        [SerializeField] private TankListSO tankListSO;


        private void Start()
        {
            SpawnTank();
        }

        private void SpawnTank()
        {
            int randomTankNumber = Random.Range(0, tankListSO.tankSOArray.Length);
            tankModel = new TankModel(tankListSO.tankSOArray[randomTankNumber]);
            tankController = new PlayerTankController(tankModel);
        }

        public void SetCameraToFollowPlayer(Transform player)
        {
            cam.transform.SetParent(player);
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
