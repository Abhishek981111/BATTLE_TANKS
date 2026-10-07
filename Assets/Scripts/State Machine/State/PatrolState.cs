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
            navMeshAgent.SetDestination(enemyStateMachine.GetRandomPoint(enemyStateMachine.transform.position, 50));
            navMeshAgent.isStopped = false;
        }

        public override void Tick()
        {
            if(enemyStateMachine.playerTransform != null)
            {
                if(Vector3.Distance(enemyStateMachine.transform.position, enemyStateMachine.playerTransform.position) < 15f)
                {
                    stateMachine.SetState(enemyStateMachine.chaseState);
                }
            }
            if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                navMeshAgent.SetDestination(enemyStateMachine.GetRandomPoint(enemyStateMachine.transform.position, 50));
            }
        }
    }
}
