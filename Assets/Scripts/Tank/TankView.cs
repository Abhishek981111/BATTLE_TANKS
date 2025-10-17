using UnityEngine;
using System.Collections.Generic;


namespace BATTLE_TANKS
{
    public class TankView : MonoBehaviour
    {

        private TankController tankController;
        private Rigidbody tankRigidbody;
        public GameObject bulletSpawnPoint;
        public List<MeshRenderer> tankBody;


        private void Awake()
        {
            tankRigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (tankController.GetRotationAngle() != 0)
            {
                transform.Rotate(transform.up, tankController.GetRotationAngle() * Time.deltaTime);
            }
        }

        private void FixedUpdate()
        {
            tankRigidbody.linearVelocity = tankController.GetMovementVelocity();
        }


        public void SetTankController(TankController tankController)
        {
            this.tankController = tankController;
            UpdateTankColor();
        }

        private void UpdateTankColor()
        {
            Material material = tankController.GetMaterial();
            for (int i = 0; i < tankBody.Count; i++)
            {
                tankBody[i].material = material;
            }
        }

        public void TakeDamage(float damage)
        {
            tankController.ReduceHealth(damage);
        }
        
        public void DestroyTank()
        {
            Destroy(gameObject);
        }
    }
}
