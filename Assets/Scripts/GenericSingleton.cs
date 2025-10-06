using UnityEngine;

namespace BATTLE_TANKS
{
    public class GenericSingleton<T> : MonoBehaviour where T : GenericSingleton<T>
    {

        private static T _instance;
        public static T Instance { get { return _instance; } }


        protected void Awake()
        {
            if (_instance == null)
            {
                _instance = (T)this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
        }
    }
}
