using UnityEngine;
using System.Collections.Generic;


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
            playerTankController.ReduceHealth(damage);
        }

        public void DestroyTank()
        {
            Destroy(gameObject);
        }
    }
}
