using Unity.VisualScripting;
using UnityEngine;


namespace BATTLE_TANKS
{
    public class PlayerTankController : TankController
    {

        public PlayerTankController(TankModel tankModel,
            TankView tankView) : base(tankModel, tankView)
        {
            Initialize();
        }

        private void Initialize()
        {
            this.tankView = GameObject.Instantiate<TankView>(tankView);
            this.tankView.SetTankController(this);
            TankService.Instance.SetCameraToFollowPlayer(tankView.transform);
        }

        public override void FireBullet()
        {
            Vector3 bulletSpawnPoint = tankView.bulletSpawnPoint.transform.position;

            Quaternion bulletSpawnRotation = tankView.bulletSpawnPoint.transform.rotation;
            BulletService.Instance.SpawnBullet(bulletSpawnPoint, bulletSpawnRotation,
                tankModel.bulletType);
        }

        public override Vector3 GetMovementVelocity()
        {
            return TankService.Instance.GetPlayerInputVertical() * tankModel.movementSpeed *
                tankView.transform.forward;
        }

        public override float GetRotationAngle()
        {
            return TankService.Instance.GetPlayerInputHorizontal() * tankModel.rotationSpeed;
        }


    }
}
