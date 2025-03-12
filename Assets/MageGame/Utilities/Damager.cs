using UnityEngine;

namespace MageGame.Utilities
{
    public class Damager : MonoBehaviour
    {
        public float Damage { get; set; } = 0f;
        
        public float GetDamage() => Damage;
    }
}
