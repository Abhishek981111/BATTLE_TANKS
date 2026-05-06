using UnityEngine;


namespace BATTLE_TANKS
{
    public class PlayerTankController 
    {

        protected TankModel tankModel;
        protected float currentHealth;
        protected PlayerTankView playerTankView;

        public PlayerTankController(TankModel tankModel, PlayerTankView playerTankView,
            Vector3 spawnPosition)
        {
            this.tankModel = tankModel;
            currentHealth = tankModel.health;
            this.playerTankView = playerTankView;
            Initialize(spawnPosition);
        }

        public Material GetMaterial(){
            return tankModel.tankMaterial;
        }

        public void ReduceHealth(float damage){
            currentHealth -= damage;
        }

        private void Initialize(Vector3 spawnPosition)
        {
            playerTankView = GameObject.Instantiate<PlayerTankView>(playerTankView,
                spawnPosition, Quaternion.identity);
            playerTankView.SetTankController(this);

            TankService.Instance.SetCameraToFollowPlayer(playerTankView.transform);
        }

        public void FireBullet()
        {
            Vector3 bulletSpawnPosition = playerTankView.bulletSpawnPosition.transform.position;

            Quaternion bulletSpawnRotation = playerTankView.bulletSpawnPosition.transform.rotation;
            BulletService.Instance.SpawnBullet(bulletSpawnPosition, bulletSpawnRotation,
                tankModel.bulletType);
        }

        public Vector3 GetMovementVelocity()
        {
            return TankService.Instance.GetPlayerInputVertical() * tankModel.movementSpeed *
                playerTankView.transform.forward;
        }

        public float GetRotationAngle()
        {
            return TankService.Instance.GetPlayerInputHorizontal() * tankModel.rotationSpeed;
        }


    }
}
