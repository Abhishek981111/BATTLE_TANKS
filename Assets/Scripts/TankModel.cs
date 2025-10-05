using UnityEngine;

public class TankModel
{

    private float movementSpeed;
    private float rotationSpeed;


    public TankModel(float movementSpeed, float rotationSpeed)
    {
        this.movementSpeed = movementSpeed;
        this.rotationSpeed = rotationSpeed;
    }

    public float GetMovementSpeed()
    {
        return movementSpeed;
    }
    
    public float GetRotationSpeed()
    {
        return rotationSpeed;
    }
}
