using UnityEngine;


namespace BATTLE_TANKS
{
    public class PlayerTankController 
    {

        private TankModel tankModel;
        private float currentHealth;
        private PlayerTankView playerTankView;
        private PlayerInput playerInput;
        

        public PlayerTankController(TankModel tankModel, PlayerTankView playerTankView,
            Vector3 spawnPosition, PlayerInput playerInput)
        {
            this.tankModel = tankModel;
            currentHealth = tankModel.health;
            this.playerTankView = playerTankView;
            this.playerInput = playerInput;

            Initialize(spawnPosition);
        }

        private void Initialize(Vector3 spawnPosition)
        {
            playerTankView = GameObject.Instantiate<PlayerTankView>(playerTankView,
                spawnPosition, Quaternion.identity);
            playerTankView.SetTankController(this);

            PlayerTankSpawner.Instance.SetCameraToFollowPlayer(playerTankView.transform);
        }

        public Material GetMaterial(){
            return tankModel.tankMaterial;
        }

        public void ReduceHealth(float damage){
            currentHealth -= damage;
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
            return playerInput.GetPlayerVerticalInput() * tankModel.movementSpeed *
                playerTankView.transform.forward;
        }

        public float GetRotationAngle()
        {
            return playerInput.GetPlayerHorizontalInput() * tankModel.rotationSpeed;
        }


    }
}
