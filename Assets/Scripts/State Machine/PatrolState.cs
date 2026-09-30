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
            navMeshAgent.SetDestination(GetRandomPoint(enemyStateMachine.transform.position, 50));
            navMeshAgent.isStopped = false;
        }

        public override void Tick()
        {
            if(navMeshAgent.remainingDistance <= enemyStateMachine.navMeshAgent.stoppingDistance)
            {
                enemyStateMachine.SetState(enemyStateMachine.idleState);
            }
        }

        public override void OnStateExit()
        {
            navMeshAgent.isStopped = true;
        }

        public Vector3 GetRandomPoint(Vector3 center, float range)
        {
            bool pointFound = false;
            Vector3 randomPoint;
            Vector3 result = Vector3.zero;
            NavMeshHit hit;
            do
            {
                randomPoint = center + Random.insideUnitSphere * range;
                if(NavMesh.SamplePosition(randomPoint, out hit, 1, NavMesh.AllAreas))
                {
                    result = hit.position;
                    pointFound = true;
                }
            }while(pointFound == false);
            return result;
        }
    }
}
