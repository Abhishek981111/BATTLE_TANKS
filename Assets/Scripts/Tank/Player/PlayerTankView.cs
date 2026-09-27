using UnityEngine;
using System.Collections.Generic;
using System.Collections;


namespace BATTLE_TANKS
{
    public class PlayerTankView : MonoBehaviour, IDamageable
    {
        private PlayerTankController playerTankController;
        private Rigidbody tankRigidbody;
        public GameObject bulletSpawnPosition;
        public List<MeshRenderer> tankBody;


        private void Awake()
        {
            tankRigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            playerTankController.CheckForPlayerInput();
            
            if (playerTankController.GetRotationAngle() != 0)
            {
                transform.Rotate(transform.up, playerTankController.GetRotationAngle() * Time.deltaTime);
            }
        }

        private void FixedUpdate()
        {
            tankRigidbody.linearVelocity = playerTankController.GetMovementVelocity();
        }


        public void SetTankController(PlayerTankController playerTankController)
        {
            this.playerTankController = playerTankController;
            UpdateTankColor();
        }

        private void UpdateTankColor()
        {
            Material material = playerTankController.GetMaterial();
            for (int i = 0; i < tankBody.Count; i++)
            {
                tankBody[i].material = material;
            }
        }

        public void Damage(float damage)
        {
            if (playerTankController.IsTankAlive())
            {
                playerTankController.ReduceHealth(damage);
            }
                
        }

        private void OnCollisionEnter(Collision other)
        {
           IDamageable damageableObject = other.gameObject.GetComponent<IDamageable>();

           if(damageableObject != null)
           {
                damageableObject.Damage(playerTankController.GetCollisionDamage());
           }
        }

        public void ShowEffectAndDestroy()
        {
            ParticleEffectService.Instance.ShowTankExplosionEffect(transform.position);
            StartCoroutine(DestroyEnemyTank());
        }

        IEnumerator DestroyEnemyTank()
        {
            yield return new WaitForSeconds(1.0f);
            Destroy(gameObject);
        }
    }
}
