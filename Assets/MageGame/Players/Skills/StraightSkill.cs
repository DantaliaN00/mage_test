using MageGame.Players.Skills.Bullets;
using UnityEngine;

namespace MageGame.Players.Skills
{
    public class StraightSkill : ASkill
    {
        [SerializeField]
        StraightBullet bulletPrefab;
        
        protected override void MakeUse(Vector3 forward)
        {
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.LookRotation(forward));
            
            bullet.MoveDirection = forward;
            bullet.Initialize(Damage);
        }
    }
}
