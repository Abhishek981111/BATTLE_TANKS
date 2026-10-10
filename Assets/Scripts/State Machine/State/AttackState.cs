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
            if (coolDownTime > 0)
            {
                coolDownTime -= Time.deltaTime;
            }
            else
            {
                FireBullet();
            }
            if(enemyStateMachine.PlayerTankInAttackRange())
            {
                enemyStateMachine.navMeshAgent.SetDestination(enemyStateMachine.playerTransform.position);
            }
            else
            {
                stateMachine.SetState(enemyStateMachine.chaseState);
            }
        }

        private void FireBullet()
        {
            Vector3 bulletSpawnPos = enemyStateMachine.enemyTankView.bulletSpawnPosition.transform.position;

            BulletType bulletType = enemyStateMachine.enemyTankController.tankModel.bulletType;
            BulletService.Instance.SpawnBullet(bulletSpawnPos, enemyStateMachine.transform.rotation, bulletType);

            coolDownTime = 1 / fireRPM * 60f;  //Converting fire rate from minutes to seconds
        }
    }
}
