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
        public NavMeshAgent navMeshAgent { get; private set; }
        public Transform playerTransform { get; private set; }
        public EnemyTankController enemyTankController { get; private set; }
        public EnemyTankView enemyTankView { get; private set; }


        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            enemyTankView = GetComponent<EnemyTankView>();
        }

        private void Start()
        {
            playerTransform = PlayerTankSpawner.Instance.playerTankController.playerTankView.transform;
            
            idleState = new IdleState(this);
            patrolState = new PatrolState(this);
            attackState = new AttackState(this);
            chaseState = new ChaseState(this);

            SetState(idleState);
        }

        private void Update()
        {
            currentState.Tick();
        }

        public void SetEnemyTankController(EnemyTankController enemyTankController)
        {
            this.enemyTankController = enemyTankController;
        }

        public Vector3 GetRandomPoint(Vector3 center, float range)
        {
            bool pointFound = false;
            Vector3 randomPoint;
            Vector3 result = Vector3.zero;
            NavMeshHit hit;
            do
            {
                randomPoint = center + Random.insideUnitSphere * range;
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
