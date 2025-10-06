using UnityEngine;

namespace BATTLE_TANKS
{
    public class TankService : GenericSingleton<TankService>
    {
        private TankModel tankModel;
        private TankController tankController;

        [SerializeField] private TankView tankView;
        [SerializeField] private FixedJoystick joystick;
        [SerializeField] private float movementSpeed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private GameObject cam;


        private void Start()
        {
            SpawnTank();
        }

        private void SpawnTank()
        {
            tankModel = new TankModel(movementSpeed, rotationSpeed);
            tankController = new TankController(tankModel, tankView);
        }

        public void SetCameraToFollowPlayer(Transform player)
        {
            cam.transform.SetParent(player);
        }   

        public float GetJoystickHorizontalInput()
        {
            return joystick.Horizontal;
        }

        public float GetJoystickVerticalInput()
        {
            return joystick.Vertical;
        }
    }
}
