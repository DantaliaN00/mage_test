using System;
using System.Collections.Generic;
using MageGame.Players.Skills;
using UnityEngine;

namespace MageGame.Configs
{
    [CreateAssetMenu(menuName = "Mage/Configs/SettingsData")]
    public class SettingsData : ScriptableObject
    {
        [Serializable]
        public class EnemyData
        {
            [SerializeField]
            float maxHp = 1f;
            
            [Range(0f, 1f)]
            [SerializeField]
            float protection = 0f;
            
            [SerializeField]
            float damage = 10f;
            
            [SerializeField]
            float moveSpeed = 5f;
            
            [SerializeField]
            float rotationSpeed = 10f;
            
            public float MaxHp => maxHp;
            
            public float Protection => protection;
            
            public float Damage => damage;
            
            public float MoveSpeed => moveSpeed;
            
            public float RotationSpeed => rotationSpeed;
        }
        
        [SerializeField]
        int maxEnemyCount = 10;
        
        [SerializeField]
        float playerMaxHp = 100f;
        
        [Range(0f, 1f)]
        [SerializeField]
        float playerProtection = 0f;
        
        [SerializeField]
        float playerMoveSpeed = 3f;

        [SerializeField]
        float playerRotationSpeed = 100f;

        [SerializeField]
        ASkill[] playerSkillPrefabs = new ASkill[0];
        
        [SerializeField]
        EnemyData[] enemies = new EnemyData[0];
        
        public int MaxEnemyCount => maxEnemyCount;
        
        public float PlayerMaxHp => playerMaxHp;
        
        public float PlayerProtection => playerProtection;
        
        public float PlayerMoveSpeed => playerMoveSpeed;
        
        public float PlayerRotationSpeed => playerRotationSpeed;
        
        public IReadOnlyList<ASkill> PlayerSkillPrefabs => playerSkillPrefabs;
        
        public IReadOnlyList<EnemyData> Enemies => enemies;
    }
}
