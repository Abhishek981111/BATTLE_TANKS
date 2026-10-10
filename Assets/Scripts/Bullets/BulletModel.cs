namespace BATTLE_TANKS
{
    public struct BulletModel
    {
        public BulletType bulletType { get; }
        public float bulletSpeed { get; }
        public float bulletDamage { get; }


        public BulletModel(BulletSO bulletSO)
        {
            bulletType = bulletSO.bulletType;
            bulletSpeed = bulletSO.bulletSpeed;
            bulletDamage = bulletSO.bulletDamage;
        }
       
    }
}
