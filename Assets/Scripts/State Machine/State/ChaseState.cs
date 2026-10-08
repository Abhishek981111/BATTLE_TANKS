using UnityEngine;

namespace BATTLE_TANKS
{
    public class ChaseState : BaseState
    {
        private EnemyStateMachine enemyStateMachine;

        public ChaseState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
        {
            this.enemyStateMachine = enemyStateMachine;
        }

        public override void OnStateEnter()
        {
            enemyStateMachine.navMeshAgent.isStopped = false;
        }

        public override void Tick()
        {
            if(Vector3.Distance(enemyStateMachine.transform.position, enemyStateMachine.playerTransform.position) < enemyStateMachine.attackRange)
            {
                stateMachine.SetState(enemyStateMachine.attackState);
            }
            else if(Vector3.Distance(enemyStateMachine.transform.position, enemyStateMachine.playerTransform.position) < enemyStateMachine.chaseRange)
            {
                enemyStateMachine.navMeshAgent.SetDestination(enemyStateMachine.playerTransform.position);
            }
            else
            {
                enemyStateMachine.SetState(enemyStateMachine.idleState);
            }
        }
    }
}
