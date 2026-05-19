using System.Collections;
using System.Collections.Generic;
using BATTLETANKS;
using UnityEngine;

namespace BATTLE_TANKS
{
    public class EnemyTankModel : TankModel
    {
        public Vector3[] patrolPath;
        
        public EnemyTankModel(TankSO tankSO, TankPatrolPathSO tankPatrolPathSO) : base(tankSO)
        {
            patrolPath = tankPatrolPathSO.patrolPath;
        }
    }
}
