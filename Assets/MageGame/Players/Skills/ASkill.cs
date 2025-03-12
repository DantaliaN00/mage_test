using UnityEngine;

namespace MageGame.Players.Skills
{
    public abstract class ASkill : MonoBehaviour
    {
        [SerializeField]
        float damage = 1f;
        
        protected float Damage => damage;
        
        public void Use(Vector3 forward)
        {
            MakeUse(forward);
        }

        protected abstract void MakeUse(Vector3 forward);
    }
}
