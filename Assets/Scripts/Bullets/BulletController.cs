using UnityEngine;

namespace BATTLE_TANKS
{
    public class BulletController 
    {
        private BulletModel bulletModel;
        private BulletView bulletView;

        public BulletController(BulletModel bulletModel, BulletView bulletView, Transform bullet)
        {
            this.bulletModel = bulletModel;
            this.bulletView = GameObject.Instantiate<BulletView>(bulletView,
                bullet.position, bullet.rotation);
            this.bulletView.SetBulletController(this);
        }

        public float GetBulletSpeed()
        {
            return bulletModel.bulletSpeed;
        }
    }
}

