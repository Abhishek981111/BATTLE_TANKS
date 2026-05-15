using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BATTLE_TANKS
{
    public class EnemyTankView : MonoBehaviour
    {
        private EnemyTankController enemyTankController;
        private Rigidbody tankRigidbody;
        public GameObject bulletSpawnPosition;
        public List<MeshRenderer> tankBody;
        private NavMeshAgent navMeshAgent;
        private Vector3 myDestination = new Vector3(0, 0, -30);


        private void Awake()
        {
            tankRigidbody = GetComponent<Rigidbody>();
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            navMeshAgent.destination = myDestination;
        }

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
