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
            tankModel = new TankModel(tankListSO.tankSOArray[0]);
            tankController = new TankController(tankModel);
        }

        public void SetCameraToFollowPlayer(Transform player)
        {
            cam.transform.SetParent(player);
        }

        public float GetPlayerInputHorizontal()
        {
            float horizontal = joystick.Horizontal;
            if (Mathf.Abs(horizontal) > Mathf.Epsilon)
            {
                return horizontal;
            }
            return Input.GetAxisRaw("Horizontal");
        }

        public float GetPlayerInputVertical()
        {
            float vertical = joystick.Vertical;
            if (Mathf.Abs(vertical) > Mathf.Epsilon)
            {
                return vertical;
            }
            return Input.GetAxisRaw("Vertical");
        }
    }
}
