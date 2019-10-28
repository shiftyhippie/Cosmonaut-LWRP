using Player;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utilities
{
    public class LevelChange : MonoBehaviour
    {
        public bool canChangeLevel;
        public int currentWorld;
        public PlayerStateManager playerStateManager;
        public Collider doorToNewRoom;
        public int currentScene;
        public int nextSceneValue;

        public TextMeshProUGUI level;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player") && canChangeLevel)
            {
                NextLevel();
            }
        }

        public void WorldAwake()
        {
            currentScene = SceneManager.GetActiveScene().buildIndex;
            
            int counter;
            var currentSceneTemp = currentScene;
            
            for (counter = 0; currentSceneTemp > 0; counter++)
            {
                currentSceneTemp -= 25;
            }

            currentWorld = counter;
            
            nextSceneValue = currentWorld * 26;
        }

        public void WorldFixedUpdate()
        {
            canChangeLevel = playerStateManager.playerCanChangeLevel;
            
            doorToNewRoom.isTrigger = canChangeLevel;

            level.text = $"{currentWorld} : {currentScene}";
        }

        private void NextLevel()
        {
            nextSceneValue = currentWorld * 26;
            
            if (currentScene < nextSceneValue)
            {
                SceneManager.LoadSceneAsync(currentScene + 1);
            }
            else if (currentScene >= nextSceneValue)
            {
                SceneManager.LoadSceneAsync(0);
            }
        }
    }
}
