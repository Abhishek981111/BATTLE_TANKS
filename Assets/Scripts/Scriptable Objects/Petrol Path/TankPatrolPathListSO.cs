using UnityEngine;

namespace BATTLETANKS
{
    [CreateAssetMenu(fileName = "TankPatrolPathListSO", menuName = "ScriptableObjects/TankPatrolPathList")]
    public class TankPatrolPathListSO : ScriptableObject
    {
        public TankPatrolPathSO[] patrolPathList;
    }
}

