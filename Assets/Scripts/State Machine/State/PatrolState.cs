using UnityEngine;
using UnityEngine.AI;   

namespace BATTLE_TANKS
{
    public class PatrolState : BaseState
    {
        private NavMeshAgent navMeshAgent;
        private EnemyStateMachine enemyStateMachine;


        public PatrolState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
        {
            this.enemyStateMachine = enemyStateMachine;
            this.navMeshAgent = enemyStateMachine.navMeshAgent;
        }

        public override void OnStateEnter()
        {
            navMeshAgent.SetDestination(enemyStateMachine.GetRandomPoint());
            navMeshAgent.isStopped = false;
        }

        public override void Tick()
        {
            if(enemyStateMachine.PlayerTankInChaseRange())
            {
                stateMachine.SetState(enemyStateMachine.chaseState);
            }
            else if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                navMeshAgent.SetDestination(enemyStateMachine.GetRandomPoint());
            }
        }
    }
}
