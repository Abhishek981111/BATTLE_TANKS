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
            if(enemyStateMachine.PlayerTankInAttackRange())
            {
                stateMachine.SetState(enemyStateMachine.attackState);
            }
            else if(enemyStateMachine.PlayerTankInChaseRange())
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
