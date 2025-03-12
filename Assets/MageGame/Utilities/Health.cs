using UnityEngine;

namespace MageGame.Utilities
{
    public class Health : MonoBehaviour
    {
        public float MaxHp { get; set; } = 0f;
        
        public float Protection { get; set; } = 0f;
        
        public float Hp { get; private set; } = 0f;
        
        public bool IsAlive { get; private set; } = true;
        
        void Start()
        {
            Hp = MaxHp;
            IsAlive = Hp > 0f;
        }
        
        public void Hit(float damage)
        {
            Hp -= damage * Protection;
            
            if (Hp <= 0f)
                IsAlive = false;
        }
    }
}
