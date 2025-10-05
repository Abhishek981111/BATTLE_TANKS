using System;
using UnityEngine;

public class TankService : GenericSingleton<TankService>
{
    private TankModel tankModel;
    private TankController tankController;

    [SerializeField] private TankView tankView;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;


    private void Start()
    {
        SpawnTank();
    }

    private void SpawnTank()
    {
        tankModel = new TankModel(movementSpeed, rotationSpeed);
        tankController = new TankController(tankModel, tankView, joystick);
    }
}
