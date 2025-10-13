using UnityEngine;

namespace BATTLE_TANKS
{
    [CreateAssetMenu(fileName = "BulletSO", menuName = "Scriptable Objects/NewBullet")]
    public class BulletSO : ScriptableObject
    {
        public BulletType bulletType;
        public float bulletSpeed;
        public float bulletDamage;
        public BulletView bulletView;
    }
}

