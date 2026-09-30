using UnityEngine.AI;

namespace BATTLE_TANKS
{
    public class EnemyStateMachine : StateMachine
    {
        public IdleState idleState { get; private set; }
        public PatrolState patrolState { get; private set; }
        public NavMeshAgent navMeshAgent { get; private set; }


        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            idleState = new IdleState(this);
            patrolState = new PatrolState(this);

            SetState(idleState);
        }

        private void Update()
        {
            currentState.Tick();
        }
    }
}
