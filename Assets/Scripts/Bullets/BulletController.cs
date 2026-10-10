using UnityEngine;

namespace BATTLE_TANKS
{
    public class BulletController 
    {
        public BulletModel bulletModel { get; }
        public BulletView bulletView { get; private set; }

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
    }
}

