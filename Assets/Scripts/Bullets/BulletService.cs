using UnityEngine;

namespace BATTLE_TANKS
{
    public class BulletService : GenericSingleton<BulletService>
    {
        private BulletController bulletController;
        private BulletModel bulletModel;
        [SerializeField] private BulletView bulletView;


        public void SpawnBullet(Transform bullet)
        {
            bulletModel = new BulletModel(5);
            bulletController = new BulletController(bulletModel, bulletView, bullet);
        }
    }
}
