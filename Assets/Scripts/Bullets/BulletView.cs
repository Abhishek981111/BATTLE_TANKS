using UnityEngine;

namespace BATTLE_TANKS
{
    public class BulletView : MonoBehaviour
    {
        private BulletController bulletController;
        private Rigidbody bulletRigidbody;
        

        private void Awake()
        {
            bulletRigidbody = GetComponent<Rigidbody>();
        }

        public void SetBulletController(BulletController bulletController)
        {
            this.bulletController = bulletController;
            FireBullet();
        }

        private void FireBullet()
        {
            bulletRigidbody.linearVelocity = transform.forward * bulletController.GetBulletSpeed();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<EnemyTankView>())
            {
                EnemyTankView enemyTankView = other.GetComponent<EnemyTankView>();
                enemyTankView.TakeDamage(bulletController.GetBulletDamage());
            }
            Destroy(gameObject);
        }
    }
}
