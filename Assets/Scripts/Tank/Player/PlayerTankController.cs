using UnityEngine;


namespace BATTLE_TANKS
{
    public class PlayerTankController 
    {

        private TankModel tankModel;
        private TankHealth tankHealth;
        private PlayerTankView playerTankView;
        private FixedJoystick fixedJoystick;
        

        public PlayerTankController(TankModel tankModel, PlayerTankView playerTankView,
            Vector3 spawnPosition, FixedJoystick fixedJoystick)
        {
            this.tankModel = tankModel;
            tankHealth = new TankHealth(tankModel.health);
            this.playerTankView = playerTankView;
            this.fixedJoystick = fixedJoystick;

            Initialize(spawnPosition);
        }

        private void Initialize(Vector3 spawnPosition)
        {
            playerTankView = GameObject.Instantiate<PlayerTankView>(playerTankView,
                spawnPosition, Quaternion.identity);
            playerTankView.SetTankController(this);

            PlayerTankSpawner.Instance.StartFollowingPlayer(playerTankView.transform);
        }

        public Material GetMaterial()
        {
            return tankModel.tankMaterial;
        }

        public void ReduceHealth(float damage)
        {
            tankHealth.ReduceHealth(damage);

            if (tankHealth.IsAlive())
            {
                return;
            }
            DestroyTank();
        }

        private void DestroyTank()
        {
            PlayerTankSpawner.Instance.StopFollowingPlayer();
            GameObject.Destroy(playerTankView.gameObject);
            GameOver.Instance.DestroyEverything();
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
            return fixedJoystick.Vertical * tankModel.movementSpeed *
                playerTankView.transform.forward;
        }

        public float GetRotationAngle()
        {
            return fixedJoystick.Horizontal * tankModel.rotationSpeed;
        }

        public void CheckForPlayerInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FireBullet();
            }
        }

        public float GetCollisionDamage()
        {
            return tankModel.damage;
        }

    }
}
