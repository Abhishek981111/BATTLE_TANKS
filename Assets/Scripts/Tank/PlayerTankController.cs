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
            Vector3 bulletSpawnPosition = tankView.bulletSpawnPosition.transform.position;

            Quaternion bulletSpawnRotation = tankView.bulletSpawnPosition.transform.rotation;
            BulletService.Instance.SpawnBullet(bulletSpawnPosition, bulletSpawnRotation,
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
