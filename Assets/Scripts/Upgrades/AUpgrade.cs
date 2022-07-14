using UnityEngine;


namespace Upgrades
{
    public abstract class AUpgrade : MonoBehaviour
    {
        private void Start()
        {
            Init();
        }
        
        protected abstract void Init();
        public abstract void Upgrade();


    }
}