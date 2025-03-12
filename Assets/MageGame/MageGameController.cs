using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using MageGame.Configs;
using MageGame.Enemies;
using MageGame.Players;
using MageGame.Players.Skills;
using UnityEngine;

namespace MageGame
{
    public class MageGameController : MonoBehaviour
    {
        [SerializeField]
        SettingsData settingsData;
        
        [SerializeField]
        Player playerPrefab;
        
        [SerializeField]
        Transform playerSpawnPivot;
        
        [SerializeField]
        Enemy enemyPrefab;
        
        [SerializeField]
        float enemySpawnRadius = 5f;
        
        [CanBeNull]
        public Player Player => player;
        
        readonly List<Enemy> enemies = new();
        
        [CanBeNull]
        Player player;
        
        void Start()
        {
            SpawnPlayer();
        }
        
        void Update()
        {
            if (settingsData.Enemies.Count == 0)
                return;
            
            if (player == null)
                return;
            
            if (!player.IsAlive)
                SpawnPlayer();
            
            foreach (var enemy in enemies)
                enemy.Target = player;
            
            if (enemies.Count(o => o.IsAlive) < settingsData.MaxEnemyCount)
            {
                var enemyData = settingsData.Enemies[Random.Range(0, settingsData.Enemies.Count)];
                
                var spawnPosition2d = Random.insideUnitCircle.normalized * enemySpawnRadius;
                var spawnPosition = new Vector3(spawnPosition2d.x, 0f, spawnPosition2d.y);
                
                var instance = Instantiate(enemyPrefab, spawnPosition, Quaternion.LookRotation(spawnPosition - player.transform.position));
                instance.Initialize(enemyData.MaxHp, 1f - Mathf.Clamp01(enemyData.Protection), enemyData.Damage);
                
                instance.Target = player;
                
                enemies.Add(instance);
            }
            
            enemies.RemoveAll(o => !o.IsAlive || o == null);
        }
        
        void SpawnPlayer()
        {
            if (player != null)
                Destroy(player.gameObject);
            
            var instance = Instantiate(playerPrefab, playerSpawnPivot.position, playerSpawnPivot.rotation);
            
            var skills = new List<ASkill>();
            foreach (var skillPrefab in settingsData.PlayerSkillPrefabs)
            {
                var skillInstance = Instantiate(skillPrefab, instance.transform);
                skills.Add(skillInstance);
            }
            
            instance.Initialize(settingsData.PlayerMaxHp, 1f - Mathf.Clamp01(settingsData.PlayerProtection), skills);
            
            player = instance;
        }
    }
}
