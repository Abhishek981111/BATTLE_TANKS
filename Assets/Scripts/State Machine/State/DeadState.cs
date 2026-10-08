using UnityEngine;

namespace BATTLE_TANKS
{
    public class DeadState : BaseState
    {
        private float despawnTime;
        private float timeElapsed;
        private EnemyStateMachine enemyStateMachine;


        public DeadState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
        {
            this.enemyStateMachine = enemyStateMachine;
            despawnTime = 1f; 
        }

        public override void OnStateEnter()
        {
            enemyStateMachine.navMeshAgent.isStopped = true;

            ParticleEffectService.Instance.ShowTankExplosionEffect(enemyStateMachine.transform.position);
            timeElapsed = 0f;
        }

        public override void OnStateExit()
        {
            GameObject.Destroy(enemyStateMachine.gameObject);
        }

        public override void Tick()
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed >= despawnTime)
            {
                stateMachine.SetState(null);
            }
        }
    }
}
