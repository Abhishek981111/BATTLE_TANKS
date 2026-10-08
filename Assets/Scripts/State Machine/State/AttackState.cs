using UnityEngine;

namespace BATTLE_TANKS
{
    public class AttackState : BaseState
    {
        private EnemyStateMachine enemyStateMachine;
        private float fireRPM;
        private float coolDownTime;
        

        public AttackState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
        {
            this.enemyStateMachine = enemyStateMachine;
            fireRPM = 30f;
        }

        public override void OnStateEnter()
        {
            enemyStateMachine.navMeshAgent.isStopped = false;
        }

        public override void Tick()
        {
            if(enemyStateMachine.playerTransform == null)
            {
                stateMachine.SetState(enemyStateMachine.idleState);
                return;
            }
            if(Vector3.Distance(enemyStateMachine.transform.position, enemyStateMachine.playerTransform.position) < enemyStateMachine.attackRange)
            {
                enemyStateMachine.navMeshAgent.SetDestination(enemyStateMachine.playerTransform.position);
            }
            else
            {
                stateMachine.SetState(enemyStateMachine.chaseState);
            }
            if (coolDownTime > 0)
            {
                coolDownTime -= Time.deltaTime;
            }
            else
            {
                BulletService.Instance.SpawnBullet(enemyStateMachine.enemyTankView.bulletSpawnPosition.transform.position, 
                enemyStateMachine.transform.rotation, enemyStateMachine.enemyTankController.tankModel.bulletType);
                coolDownTime = 1 / fireRPM * 60; 
            }
        }
    }
}
