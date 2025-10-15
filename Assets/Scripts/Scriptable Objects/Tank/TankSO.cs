using UnityEngine;

namespace BATTLE_TANKS
{
    [CreateAssetMenu(fileName = "TankSO", menuName = "ScriptableObjects/NewTank")]
    public class TankSO : ScriptableObject
    {
        public TankType tankType;
        public float health;
        public float damage;
        public float movementSpeed;
        public float rotationSpeed;
        public Material tankMaterial;
    }
}
