using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

namespace BATTLE_TANKS
{
    public class EnemyTankView : MonoBehaviour, IDamageable
    {
        public List<MeshRenderer> tankBody;
        public GameObject bulletSpawnPosition;

        private EnemyTankController enemyTankController;
        private Coroutine destroyCoroutine;

        [SerializeField] private float range;


        public void SetTankController(EnemyTankController enemyTankController)
        {
            this.enemyTankController = enemyTankController;
            UpdateTankColor();
        }

        private void UpdateTankColor()
        {
            Material material = enemyTankController.GetMaterial();
            for (int i = 0; i < tankBody.Count; i++)
            {
                tankBody[i].material = material;
            }
        }

        public void Damage(float damage)
        {
            if(enemyTankController.IsTankAlive())
            {
                enemyTankController.ReduceHealth(damage);
            }
        }

        /*private void OnCollisionEnter(Collision other)
        {
           IDamageable damageableObject = other.gameObject.GetComponent<IDamageable>();

           if(damageableObject != null)
           {
                damageableObject.Damage(enemyTankController.GetCollisionDamage());
           }
        }*/

        public void ShowEffectAndDestroy()
        {
            if(destroyCoroutine != null)
            {
                return;
            }
            destroyCoroutine = StartCoroutine(DestroyEnemyTank());

            ParticleEffectService.Instance.ShowTankExplosionEffect(transform.position);
        }

        IEnumerator DestroyEnemyTank()
        {
            yield return new WaitForSeconds(1.0f);
            Destroy(gameObject);
        }
    }
}
