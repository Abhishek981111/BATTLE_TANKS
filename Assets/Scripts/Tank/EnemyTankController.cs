using UnityEngine;

namespace BATTLE_TANKS
{
    public class EnemyTankController : TankController
    {

        private EnemyTankAI enemyTankAI;
        public EnemyTankController(TankModel tankModel, Vector3 position) : base(tankModel)
        {
            Initialize(position);
        }

        protected void Initialize(Vector3 position)
        {
            tankView = GameObject.Instantiate<TankView>(tankView, position, Quaternion.identity);
            tankView.SetTankController(this);
            enemyTankAI = new EnemyTankAI();
            TankService.Instance.SetEnemyTankForUpdate(enemyTankAI);
        }

        public override Vector3 GetMovementVelocity()
        {
            return enemyTankAI.GetEnemyInputVertical() * tankModel.movementSpeed *
            tankView.transform.forward;
        }

        public override float GetRotationAngle()
        {
            return enemyTankAI.GetEnemyInputHorizontal() * tankModel.rotationSpeed;
        }

        public override void FireBullet() {}
    }
}

