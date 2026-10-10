using UnityEngine;

namespace BATTLE_TANKS
{
    public abstract class StateMachine : MonoBehaviour
    {
        protected BaseState currentState;


        public void SetState(BaseState state)
        {
            if(currentState != null)
            {
                currentState.OnStateExit();
            }
            
            currentState = state;

            if(currentState != null)
            {
                currentState.OnStateEnter();
            }
        }
    }
}
