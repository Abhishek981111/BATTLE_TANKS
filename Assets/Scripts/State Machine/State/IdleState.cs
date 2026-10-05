using UnityEngine;

namespace BATTLE_TANKS
{
    public class IdleState : BaseState
    {

        private float idleTime = 5f;
        private float timeElapsed;
        private EnemyStateMachine enemyStateMachine;


        public IdleState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
        {
            this.enemyStateMachine = enemyStateMachine;
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
            if (Vector3.Distance(enemyStateMachine.transform.position, enemyStateMachine.playerTransform.position) < 10f)
            {
                enemyStateMachine.SetState(enemyStateMachine.chaseState);
            }
        }
    }
}
