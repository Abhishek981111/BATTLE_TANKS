using UnityEngine;

namespace BATTLE_TANKS
{
    public class AttackState : BaseState
    {
        private EnemyStateMachine enemyStateMachine;

        public AttackState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
        {
            this.enemyStateMachine = enemyStateMachine;
        }

        public override void OnStateEnter()
        {
            enemyStateMachine.navMeshAgent.isStopped = false;
        }

        public override void Tick()
        {
            if(Vector3.Distance(enemyStateMachine.transform.position, enemyStateMachine.playerTransform.position) < 5f)
            {
                Debug.Log("Shooting bullet!!!");
            }else
            {
                stateMachine.SetState(enemyStateMachine.chaseState);
            }
        }
    }
}
