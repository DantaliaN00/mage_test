using System.Collections.Generic;
using JetBrains.Annotations;
using MageGame.Players.Skills;
using MageGame.Utilities;
using UnityEngine;

namespace MageGame.Players
{
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(DirectionMovement))]
    public class Player : MonoBehaviour
    {
        public bool IsAlive => Health.IsAlive;
        
        [CanBeNull]
        Health _health;
        Health Health => _health ??= GetComponent<Health>();
        
        [CanBeNull]
        DirectionMovement _movement;
        DirectionMovement Movement => _movement ??= GetComponent<DirectionMovement>();
        
        int currentSkillIndex = 0;
        
        readonly List<ASkill> skills = new();
        
        public void Initialize(float maxHp, float protection, float moveSpeed, float rotationSpeed, IEnumerable<ASkill> playerSkills)
        {
            Health.MaxHp = maxHp;
            Health.Protection = protection;
            Movement.MoveSpeed = moveSpeed;
            Movement.RotationSpeed = rotationSpeed;
            skills.Clear();
            skills.AddRange(playerSkills);
        }
        
        public void Move(Vector3 direction)
        {
            Movement.MoveDirection = direction;
        }
        
        public void Rotate(Quaternion rotation)
        {
            Movement.Rotation = rotation;
        }
        
        public void UseSkill()
        {
            if (skills.Count == 0 || skills.Count <= currentSkillIndex)
            {
                Debug.LogError($"Skill {currentSkillIndex} not found");
                return;
            }
            
            var skill = skills[currentSkillIndex];
            skill.Use(transform.forward);
        }
        
        public void NextSkill()
        {
            currentSkillIndex++;
            if (currentSkillIndex >= skills.Count)
                currentSkillIndex = skills.Count - 1;
        }
        
        public void PrevSkill()
        {
            currentSkillIndex--;
            if (currentSkillIndex < 0)
                currentSkillIndex = 0;
        }
        
        public void Hit(float damage)
        {
            Health.Hit(damage);
        }
    }
}