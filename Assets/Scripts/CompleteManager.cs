using System.Collections.Generic;
using Controller;
using Player;
using UnityEngine;
using Utilities;

public class CompleteManager : MonoBehaviour
{
    [Header("Gameplay Elements")] 
    public int worldNum;
    
    [Header("Camera Components")]
    public CameraManager cameraManager;
    
    [Header("Player Components")]
    public InputManager inputManager;
    public PlayerStateManager playerStateManager;
    
    [Header("Enemy Components")]
    public List<Enemy.Enemy> enemies = new List<Enemy.Enemy>();

    [Header("World Components")] 
    public LevelChange levelChange;

    [Header("Control Components")] 
    public int numOfEnemies;
    
    private void Awake()
    {
        // Assigning Everything it's Components
        
        
        // Camera
        
        // Player
        inputManager.PlayerAwake();
        playerStateManager.PlayerAwake();

        // Enemies
        foreach (var temp in enemies)
        {
            temp.EnemyAwake();
        }
        
        // World
        levelChange.WorldAwake();
    }

    private void Start()
    {
        // Camera
        
        // Player
        playerStateManager.UpdatePlayerHealth();
        playerStateManager.UpdatePlayerGold();
        playerStateManager.UpdatePlayerXp();
        
        // Enemies
        
        // World
    }

    private void Update()
    {
        // Camera        
        cameraManager.CameraUpdate();

        // Player
        inputManager.PlayerUpdate();
        playerStateManager.PlayerUpdate();
        
        // Enemies
        foreach (var enemy in enemies)
        {
            enemy.EnemyUpdate();
        }
        
        // World
    }

    private void FixedUpdate()
    {
        // Camera
        
        // Player
        inputManager.GetClosestEnemy();
        
        // Enemies
        
        // World
        levelChange.WorldFixedUpdate();
    }
}
