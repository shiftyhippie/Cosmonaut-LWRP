using System;
using System.Collections.Generic;
using Controller;
using Enemy;
using Player;
using TMPro;
using UnityEngine;
using Utilities;

namespace _EDITOR
{
    public class GameManagerScript : MonoBehaviour
    {
        private void Awake()
        {
            SetupGameManager();
        }

        public void SetupGameManager()
        {
            // Game Manager Setup
            var gameManager = GameObject.Find("Game Manager").GetComponent<CompleteManager>();
            var gameCamera = GameObject.Find("Game Camera");
            var levelDesigner = GameObject.Find("LevelDesigner(DeleteForBuild)");
            var player = GameObject.Find("Player");
            var enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
            var levelChanger = GameObject.Find("NEXTLEVELGATE");
            gameManager.cameraManager = gameCamera.GetComponent<CameraManager>();
            
            // Camera
            gameCamera.GetComponent<CameraManager>().playerTransform = player.transform;
            gameCamera.GetComponent<CameraManager>().minCameraZ = -(levelDesigner.GetComponent<LevelDesignerScript>().levelHeight / 2f) + 1.5f;
            gameCamera.GetComponent<CameraManager>().maxCameraZ =   levelDesigner.GetComponent<LevelDesignerScript>().levelHeight / 2f - 1.5f;

            // Player
            gameManager.inputManager = player.GetComponent<InputManager>();
            gameManager.playerStateManager = player.GetComponent<PlayerStateManager>();

            player.GetComponent<InputManager>().variableJoystick =
                GameObject.Find("Variable Joystick").GetComponent<VariableJoystick>();

            player.GetComponent<PlayerStateManager>().lifeText = GameObject.Find("HealthValue").GetComponent<TextMeshProUGUI>();
            player.GetComponent<PlayerStateManager>().goldText = GameObject.Find("GoldValue").GetComponent<TextMeshProUGUI>();
            player.GetComponent<PlayerStateManager>().xpText = GameObject.Find("XPValue").GetComponent<TextMeshProUGUI>();
            player.GetComponent<PlayerStateManager>().levelChange = levelChanger.GetComponent<LevelChange>();

            // Enemy
//            var enemies = new List<EnemyAiController>();
//            foreach (var enemy in enemyArray)
//            {
//                enemies.Add(enemy.GetComponent<EnemyAiController>());
//            }
//            gameManager.enemyAiControllers = enemies;

            // World
            gameManager.levelChange = levelChanger.GetComponent<LevelChange>();
            
            levelChanger.GetComponent<LevelChange>().playerStateManager = player.GetComponent<PlayerStateManager>();
            levelChanger.GetComponent<LevelChange>().doorToNewRoom = levelChanger.GetComponent<MeshCollider>();
            levelChanger.GetComponent<LevelChange>().level = GameObject.Find("LevelValue").GetComponent<TextMeshProUGUI>();
        }
    }
}