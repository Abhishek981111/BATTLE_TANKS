using UnityEngine;

namespace BATTLE_TANKS
{
    public struct TankModel
    {

        public TankType tankType;
        public float health;
        public float damage;
        public float movementSpeed;
        public float rotationSpeed;
        public Material tankMaterial;


        public TankModel(TankSO tankSO)
        {
            tankType = tankSO.tankType;
            health = tankSO.health;
            damage = tankSO.damage;
            movementSpeed = tankSO.movementSpeed;
            rotationSpeed = tankSO.rotationSpeed;
            tankMaterial = tankSO.tankMaterial;
        }
        
    }
}
