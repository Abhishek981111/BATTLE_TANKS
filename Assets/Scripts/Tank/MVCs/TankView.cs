using UnityEngine;
using System.Collections.Generic;

/*
namespace BATTLE_TANKS
{
    public abstract class TankView : MonoBehaviour
    {

        protected Rigidbody tankRigidbody;
        public GameObject bulletSpawnPosition;
        public List<MeshRenderer> tankBody;


        private void Awake()
        {
            tankRigidbody = GetComponent<Rigidbody>();
        }

        public void SetTankController(TankController tankController)
        {
            this.tankController = tankController;
            UpdateTankColor();
        }

        protected void UpdateTankColor()
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
*/
