using UnityEngine;

namespace BATTLETANKS
{
    [CreateAssetMenu(fileName = "TankPatrolPathSO", menuName = "ScriptableObjects/TankPatrolPath")]
    public class TankPatrolPathSO : ScriptableObject
    {
        public Vector3[] patrolPath;
    }
}
