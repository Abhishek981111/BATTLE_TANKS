using UnityEngine;

namespace BATTLE_TANKS
{
    [CreateAssetMenu(fileName = "BulletListSO", menuName = "Scriptable Objects/NewBulletList")]
    public class BulletListSO : ScriptableObject
    {
        public BulletSO[] bulletSOArray;
    }
}
