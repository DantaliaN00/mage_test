using System.Collections.Generic;
using JetBrains.Annotations;
using MageGame.Players.Skills;
using MageGame.Utilities;
using UnityEngine;

namespace MageGame.Players
{
    [RequireComponent(typeof(Health))]
    public class Player : MonoBehaviour
    {
        [SerializeField]
        float moveSpeed = 3f;
        
        [SerializeField]
        float rotationSpeed = 3f;
        
        public bool IsAlive => Health.IsAlive;
        
        [CanBeNull]
        Health _health;
        Health Health => _health ??= GetComponent<Health>();
        
        int currentSkillIndex = 0;
        
        readonly List<ASkill> skills = new();
        
        Vector3 MoveDirection { get; set; } = Vector3.zero;
        Quaternion Rotation { get; set; } = Quaternion.identity;
        
        void FixedUpdate()
        {
            transform.position += moveSpeed * Time.fixedDeltaTime * MoveDirection;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Rotation, rotationSpeed * Time.fixedDeltaTime);
        }
        
        public void Initialize(float maxHp, float protection, IEnumerable<ASkill> playerSkills)
        {
            Health.MaxHp = maxHp;
            Health.Protection = protection;
            skills.Clear();
            skills.AddRange(playerSkills);
        }
        
        public void Move(Vector3 direction)
        {
            MoveDirection = direction;
        }
        
        public void Rotate(Quaternion rotation)
        {
            Rotation = rotation;
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