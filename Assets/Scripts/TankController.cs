using UnityEngine;

public class TankController : MonoBehaviour
{

    public float tankSpeed;
    public float rotationSpeed;


    private float movement;
    private float rotation;
    private Rigidbody tankRigidbody;



    private void Awake()
    {
        tankRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        movement = Input.GetAxisRaw("Vertical");
        rotation = Input.GetAxisRaw("Horizontal");

        if (rotation != 0)
        {
            transform.Rotate(0, rotation * rotationSpeed, 0, Space.World);
        }
    }
    
    private void FixedUpdate()
    {
        tankRigidbody.linearVelocity = transform.forward * movement * tankSpeed;
    }
}
