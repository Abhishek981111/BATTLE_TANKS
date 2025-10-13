using UnityEngine;

namespace BATTLE_TANKS
{
    public class BulletService : GenericSingleton<BulletService>
    {
        private BulletController bulletController;
        private BulletModel bulletModel;
        [SerializeField] private BulletView bulletView;
        [SerializeField] private BulletListSO bulletListSO;


        public void SpawnBullet(Transform bullet)
        {
            bulletModel = new BulletModel(bulletListSO.bulletSOArray[0]);
            bulletController = new BulletController(bulletModel, bullet);
        }
    }
}
