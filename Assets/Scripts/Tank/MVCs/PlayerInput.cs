using UnityEngine;

namespace BATTLE_TANKS
{
    public class PlayerInput 
    {
        private FixedJoystick fixedJoystick;
        private float horizontalInput;
        private float verticalInput;


        public PlayerInput(FixedJoystick fixedJoystick)
        {
            this.fixedJoystick = fixedJoystick;
        }

        public float GetPlayerHorizontalInput()
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");

            if (horizontalInput != 0)
            {
                return horizontalInput;
            }

            return fixedJoystick.Horizontal;
        }

        public float GetPlayerVerticalInput()
        {
            float verticalInput = Input.GetAxisRaw("Vertical");

            if (verticalInput != 0)
            {
                return verticalInput;
            }

            return fixedJoystick.Vertical;
        } 

    }
}
