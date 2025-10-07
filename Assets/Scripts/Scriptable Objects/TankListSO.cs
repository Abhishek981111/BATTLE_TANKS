using UnityEngine;

namespace BATTLE_TANKS
{
    [CreateAssetMenu(fileName = "TankListSO", menuName = "ScriptableObjects/TankList")]
    public class TankListSO : ScriptableObject
    {
        public TankSO[] tankSOArray;
    }
}   
