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
        [SerializeField] private float range;


        private void Awake()
        {
            tankRigidbody = GetComponent<Rigidbody>();
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                navMeshAgent.SetDestination(enemyTankController.GetRandomPoint(transform.position, range));
            }
        }

        public void SetTankController(EnemyTankController enemyTankController)
        {
            this.enemyTankController = enemyTankController;
            UpdateTankColor();
            navMeshAgent.SetDestination(enemyTankController.GetRandomPoint(transform.position, range));    
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

        private void OnCollisionEnter(Collision other)
        {
           IDamageable damageableObject = other.gameObject.GetComponent<IDamageable>();

           if(damageableObject != null)
           {
                damageableObject.Damage(enemyTankController.GetCollisionDamage());
           }
        }
    }
}
