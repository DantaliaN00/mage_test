using JetBrains.Annotations;
using MageGame.Players;
using MageGame.Utilities;
using UnityEngine;

namespace MageGame.Enemies
{
    [RequireComponent(typeof(Movement))]
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(Damager))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] 
        float damageDistance = 1f;
        
        [CanBeNull]
        public Player Target { get; set; }
        
        public bool IsAlive => Health.IsAlive;
        
        [CanBeNull] Movement _movement;
        Movement Movement => _movement ??= GetComponent<Movement>();

        [CanBeNull] Health _health;
        Health Health => _health ??= GetComponent<Health>();
        
        [CanBeNull] Damager _damager;
        Damager Damager => _damager ??= GetComponent<Damager>();
        
        void Update()
        {
            if (Target == null)
                return;
            
            Movement.Target = Target.IsAlive ? Target.transform : null;
            
            if (Vector3.Distance(transform.position, Target.transform.position) < damageDistance)
            {
                Target.Hit(Damager.GetDamage());
                
                Destroy(gameObject);
            }
            
            if (!Health.IsAlive)
                Destroy(gameObject);
        }
        
        public void Initialize(float maxHp, float protection, float moveSpeed, float rotationSpeed, float damage)
        {
            Health.MaxHp = maxHp;
            Health.Protection = protection;
            Movement.MoveSpeed = moveSpeed;
            Movement.RotationSpeed = rotationSpeed;
            Damager.Damage = damage;
        }
        
        public void Hit(float damage)
        {
            Health.Hit(damage);
        }
    }
}