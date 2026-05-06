using UnityEngine;
using System.Collections.Generic;


namespace BATTLE_TANKS
{
    public class EnemyTankView : MonoBehaviour
    {
        protected EnemyTankController enemyTankController;
        protected Rigidbody tankRigidbody;
        public GameObject bulletSpawnPosition;
        public List<MeshRenderer> tankBody;


        private void Awake()
        {
            tankRigidbody = GetComponent<Rigidbody>();
        }

        /*private void Update()
        {
            if (enemyTankController.GetRotationAngle() != 0)
            {
                transform.Rotate(transform.up, enemyTankController.GetRotationAngle() * Time.deltaTime);
            }
        }

        private void FixedUpdate()
        {
            tankRigidbody.linearVelocity = enemyTankController.GetMovementVelocity();
        }*/


        public void SetTankController(EnemyTankController enemyTankController)
        {
            this.enemyTankController = enemyTankController;
            UpdateTankColor();
        }

        protected void UpdateTankColor()
        {
            Material material = enemyTankController.GetMaterial();
            for (int i = 0; i < tankBody.Count; i++)
            {
                tankBody[i].material = material;
            }
        }

        public void TakeDamage(float damage)
        {
            enemyTankController.ReduceHealth(damage);
        }

        public void DestroyTank()
        {
            Destroy(gameObject);
        }
    }
}
