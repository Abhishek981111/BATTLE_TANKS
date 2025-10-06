using UnityEngine;

namespace BATTLE_TANKS
{
    public class TankController
    {

        private float tankSpeed;
        private float rotationSpeed;
        private float movementInput;
        private float rotationInput;
        private TankModel tankModel;
        private TankView tankView;



        public TankController(TankModel tankModel, TankView tankView)
        {
            this.tankModel = tankModel;
            this.tankView = GameObject.Instantiate<TankView>(tankView);
            this.tankView.SetTankController(this);
            TankService.Instance.SetCameraToFollowPlayer(this.tankView.transform);
        }

        public Vector3 GetMovementVelocity()
        {
            return TankService.Instance.GetJoystickVerticalInput() * tankModel.movementSpeed *
                tankView.transform.forward;
        }

        public float GetRotationAngle()
        {
            return TankService.Instance.GetJoystickHorizontalInput() * tankModel.rotationSpeed;
        }
    }
}
