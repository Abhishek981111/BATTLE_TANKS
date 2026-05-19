using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BATTLE_TANKS
{
    public class EnemyTankView : MonoBehaviour, IDamageable
    {
        private EnemyTankController enemyTankController;
        private Rigidbody tankRigidbody;
        public GameObject bulletSpawnPosition;
        public List<MeshRenderer> tankBody;
        private NavMeshAgent navMeshAgent;
        private Vector3 nextDestination;


        private void Awake()
        {
            tankRigidbody = GetComponent<Rigidbody>();
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            navMeshAgent.destination = nextDestination;
            if (transform.position.x == nextDestination.x && 
                transform.position.z == nextDestination.z)
            {
                nextDestination = enemyTankController.GetNextDestination();
            }
        }

        public void SetTankController(EnemyTankController enemyTankController)
        {
            this.enemyTankController = enemyTankController;
            UpdateTankColor();
            nextDestination = enemyTankController.GetNextDestination();
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
            enemyTankController.ReduceHealth(damage);
        }

        public void DestroyTank()
        {
            Destroy(gameObject);
        }
    }
}
