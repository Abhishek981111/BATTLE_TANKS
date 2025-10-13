using UnityEngine;


namespace BATTLE_TANKS
{
    public class TankView : MonoBehaviour
    {

        private TankController tankController;
        private Rigidbody tankRigidbody;
        public GameObject bulletSpawnPoint;


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
        }

        public void TakeDamage()
        {
            Destroy(gameObject);
        }
    }
}
