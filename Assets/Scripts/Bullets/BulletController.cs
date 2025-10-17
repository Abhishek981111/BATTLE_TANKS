using UnityEngine;

namespace BATTLE_TANKS
{
    public class BulletController 
    {
        private BulletModel bulletModel;
        private BulletView bulletView;

        public BulletController(BulletModel bulletModel, BulletView bulletView,
            Vector3 bulletSpawnPoint, Quaternion bulletSpawnRotation)
        {
            this.bulletModel = bulletModel;
            this.bulletView = bulletView;
            
            Instantiate(bulletSpawnPoint, bulletSpawnRotation);
        }

        public void Instantiate(Vector3 bulletSpawnPoint, Quaternion bulletSpawnRotation)
        {
            bulletView = GameObject.Instantiate<BulletView>(bulletView,
                bulletSpawnPoint, bulletSpawnRotation);
            bulletView.SetBulletController(this);
        }

        public float GetBulletSpeed()
        {
            return bulletModel.bulletSpeed;
        }

        public float GetBulletDamage()
        {
            return bulletModel.bulletDamage;
        }
    }
}

