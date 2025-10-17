using UnityEngine;

namespace BATTLE_TANKS
{
    public struct BulletModel
    {
        public BulletType bulletType;
        public float bulletSpeed;
        public float bulletDamage;


        public BulletModel(BulletSO bulletSO)
        {
            bulletType = bulletSO.bulletType;
            bulletSpeed = bulletSO.bulletSpeed;
            bulletDamage = bulletSO.bulletDamage;
        }
       
    }
}
