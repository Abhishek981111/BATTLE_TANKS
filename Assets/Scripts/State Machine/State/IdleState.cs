using UnityEngine;

namespace BATTLE_TANKS
{
    public class IdleState : BaseState
    {

        private float idleTime;
        private float timeElapsed;
        private EnemyStateMachine enemyStateMachine;


        public IdleState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
        {
            this.enemyStateMachine = enemyStateMachine;
            idleTime = 3f;
        }

        public override void OnStateEnter()
        {
            enemyStateMachine.navMeshAgent.isStopped = true;
            timeElapsed = 0f;
        }

        public override void Tick()
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed >= idleTime)
            {
                enemyStateMachine.SetState(enemyStateMachine.patrolState);
            }
            if(enemyStateMachine.playerTransform != null)
            {
                if (Vector3.Distance(enemyStateMachine.transform.position, enemyStateMachine.playerTransform.position) < enemyStateMachine.chaseRange)
                {
                    enemyStateMachine.SetState(enemyStateMachine.chaseState);
                }
            }
        }
    }
}
