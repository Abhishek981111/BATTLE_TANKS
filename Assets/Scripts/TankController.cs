using UnityEngine;

public class TankController 
{

    private float tankSpeed;
    private float rotationSpeed;
    private float movementInput;
    private float rotationInput;
    private FixedJoystick joystick;
    private TankModel tankModel;
    private TankView tankView;



    public TankController(TankModel tankModel, TankView tankView, FixedJoystick joystick)
    {
        this.tankModel = tankModel;
        this.tankView = GameObject.Instantiate<TankView>(tankView);
        this.tankView.SetTankController(this);
        this.joystick = joystick;
    }

    public void GetPlayerInput()
    {
        movementInput = joystick.Vertical;
        rotationInput = joystick.Horizontal;
    }

    public Vector3 GetMovementVelocity()
    {
        return movementInput * tankModel.GetMovementSpeed() * tankView.transform.forward;
    }

    public float GetRotationAngle()
    {
        return rotationInput * tankModel.GetRotationSpeed();
    }
}
