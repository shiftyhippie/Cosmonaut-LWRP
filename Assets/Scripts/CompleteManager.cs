using System.Collections.Generic;
using Controller;
using Enemy;
using Player;
using UnityEngine;
using Utilities;

public class CompleteManager : MonoBehaviour
{
    [Header("Camera Components")]
    public CameraManager cameraManager;
    
    [Header("Player Components")]
    public InputManager inputManager;
    public PlayerStateManager playerStateManager;
    
    [Header("Enemy Components")]
    public List<EnemyAiController> enemyAiControllers = new List<EnemyAiController>();

    [Header("World Components")] 
    public LevelChange levelChange;

    private void Awake()
    {
        // Assigning Everything it's Components
        
        // Camera
        
        // Player

        // Enemies
        
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
        foreach (var enemy in enemyAiControllers)
        {
            enemy.EnemyUpdate();
        }
        
        // World
    }

    private void FixedUpdate()
    {
        // Camera
        
        // Player
        
        // Enemies
        
        // World
        levelChange.WorldFixedUpdate();
    }
}
