using System.Collections.Generic;
using Controller;
using Enemy;
using Player;
using UnityEngine;
using Utilities;

namespace _EDITOR
{
    public class GameManagerScript : MonoBehaviour
    {
        [SerializeField] private CompleteManager gameManager;
        
        public void SetupGameManager()
        {
            gameManager = GetComponent<CompleteManager>();

            // Camera
            var gameCamera = GameObject.Find("Game Camera");
            gameManager.cameraManager = gameCamera.GetComponent<CameraManager>();
            
            // Player
            var player = GameObject.Find("Player");
            gameManager.inputManager = player.GetComponent<InputManager>();
            gameManager.playerStateManager = player.GetComponent<PlayerStateManager>();

            player.GetComponent<InputManager>().variableJoystick =
                GameObject.Find("Variable Joystick").GetComponent<VariableJoystick>();
            
            // Enemy
            var enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
            var enemies = new List<EnemyAiController>();
            foreach (var enemy in enemyArray)
            {
                enemies.Add(enemy.GetComponent<EnemyAiController>());
            }
            gameManager.enemyAiControllers = enemies;

            // World
            var levelChanger = GameObject.Find("NEXTLEVELGATE");
            gameManager.levelChange = levelChanger.GetComponent<LevelChange>();
        }
    }
}