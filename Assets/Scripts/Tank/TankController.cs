using UnityEngine;

namespace BATTLE_TANKS
{
    public class TankController
    {

        private TankModel tankModel;
        private TankView tankView;



        public TankController(TankModel tankModel)
        {
            this.tankModel = tankModel;
            this.tankView = tankModel.tankView;
            Initialize();
        }

        private void Initialize()
        {
            this.tankView = GameObject.Instantiate<TankView>(tankView);
            this.tankView.SetTankController(this);
            TankService.Instance.SetCameraToFollowPlayer(tankView.transform);
        }

        public Vector3 GetMovementVelocity()
        {
            return TankService.Instance.GetPlayerInputVertical() * tankModel.movementSpeed *
                tankView.transform.forward;
        }

        public float GetRotationAngle()
        {
            return TankService.Instance.GetPlayerInputHorizontal() * tankModel.rotationSpeed;
        }
    }
}
