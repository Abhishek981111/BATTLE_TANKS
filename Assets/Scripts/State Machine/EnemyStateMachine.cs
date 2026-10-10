using UnityEngine.AI;
using UnityEngine;

namespace BATTLE_TANKS
{
    public class EnemyStateMachine : StateMachine
    {
        public IdleState idleState { get; private set; }
        public PatrolState patrolState { get; private set; }
        public AttackState attackState { get; private set; }
        public ChaseState chaseState { get; private set; }
        public DeadState deadState { get; private set; }

        public NavMeshAgent navMeshAgent { get; private set; }
        public Transform playerTransform { get; private set; }
        public EnemyTankController enemyTankController { get; private set; }
        public EnemyTankView enemyTankView { get; private set; }
        public float chaseRange { get; private set; } 
        public float attackRange { get; private set; }
        public float enemyPatrolRange { get; private set; }


        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            enemyTankView = GetComponent<EnemyTankView>();
        }

        private void Start()
        {
            chaseRange = 15f;
            attackRange = 10f;  
            enemyPatrolRange = 50f;

            playerTransform = PlayerTankSpawner.Instance.playerTankController.playerTankView.transform;
            
            idleState = new IdleState(this);
            patrolState = new PatrolState(this);
            attackState = new AttackState(this);
            chaseState = new ChaseState(this);
            deadState = new DeadState(this);

            SetState(idleState);
        }

        private void Update()
        {
            if(currentState != null)
            {
                currentState.Tick();
            }
        }

        public void SetEnemyTankController(EnemyTankController enemyTankController)
        {
            this.enemyTankController = enemyTankController;
        }

        public bool PlayerTankInChaseRange()
        {
            if(playerTransform == null)
            {
                return false;
            }
            return Vector3.Distance(transform.position, playerTransform.position) < chaseRange;
        }

        public bool PlayerTankInAttackRange()
        {
            if(playerTransform == null)
            {
                return false;
            }
            return Vector3.Distance(transform.position, playerTransform.position) < attackRange;
        }

        public Vector3 GetRandomPoint()
        {
            bool pointFound = false;
            Vector3 randomPoint;
            Vector3 result = Vector3.zero;
            NavMeshHit hit;
            do
            {
                randomPoint = transform.position + Random.insideUnitSphere * enemyPatrolRange;
                if(NavMesh.SamplePosition(randomPoint, out hit, 1, NavMesh.AllAreas))
                {
                    result = hit.position;
                    pointFound = true;
                }
            }while(pointFound == false);
            return result;
        }
    }
}
