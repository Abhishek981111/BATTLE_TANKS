using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController tankController;
    private Rigidbody tankRigidbody;


    private void Awake()
    {
        tankRigidbody = GetComponent<Rigidbody>();
    }

    public void SetTankController(TankController tankController)
    {
        this.tankController = tankController;
    }

    private void Update()
    {
        tankController.GetPlayerInput();

        if (tankController.GetRotationAngle() != 0)
        {
            transform.Rotate(transform.up, tankController.GetRotationAngle() * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        tankRigidbody.linearVelocity = tankController.GetMovementVelocity();
    }
}
