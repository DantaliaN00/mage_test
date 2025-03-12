using MageGame.Enemies;
using UnityEngine;

namespace MageGame.Players.Skills.Bullets
{
    public class StraightBullet : ABullet
    {
        [SerializeField]
        float lifeTime = 5f;
        
        [SerializeField]
        float moveSpeed = 3f;
        
        public Vector3 MoveDirection { get; set; } = Vector3.zero;
        
        float lifeTimer = 0f;
        
        void Update()
        {
            lifeTimer += Time.deltaTime;
            if (lifeTimer > lifeTime)
            {
                Destroy(gameObject);
            }
        }
        
        void FixedUpdate()
        {
            transform.position += moveSpeed * Time.fixedDeltaTime * MoveDirection;
        }
        
        public void Initialize(float damage)
        {
            Damager.Damage = damage;
        }
        
        void OnCollisionEnter(Collision other)
        {
            var enemy = other.transform.GetComponent<Enemy>();
            if (enemy == null)
                return;
            
            enemy.Hit(Damager.GetDamage());
            
            Destroy(gameObject);
        }
    }
}
