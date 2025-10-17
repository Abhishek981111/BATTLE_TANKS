using UnityEngine;

namespace BATTLE_TANKS
{
    public class BulletService : GenericSingleton<BulletService>
    {
        private BulletController bulletController;
        private BulletModel bulletModel;
        [SerializeField] private BulletView bulletView;
        [SerializeField] private BulletListSO bulletListSO;


        public void SpawnBullet(Vector3 bulletSpawnPoint, Quaternion bulletSpawnRotation,
            BulletType bulletType)
        {
            for (int i = 0; i < bulletListSO.bulletSOArray.Length; i++)
            {
                if (bulletListSO.bulletSOArray[i].bulletType == bulletType)
                {
                    bulletModel = new BulletModel(bulletListSO.bulletSOArray[i]);
                    bulletController = new BulletController(bulletModel,
                        bulletView, bulletSpawnPoint, bulletSpawnRotation);
                }
            }
        }
    }
}
