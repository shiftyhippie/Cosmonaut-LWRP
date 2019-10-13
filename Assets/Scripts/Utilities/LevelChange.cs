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
            else
            {
                Debug.Log("ERROR: you shouldn't be able to collide with this object; as canChangeLevel" +
                                   " must be active and Tag must be 'Player'!");
            }
        }

        public void WorldAwake()
        {
            currentScene = SceneManager.GetActiveScene().buildIndex;
            
            int counter;
            var currentSceneTemp = currentScene;
            
            for (counter = 0; currentSceneTemp > 0; counter++)
            {
                currentSceneTemp -= 10;
            }

            currentWorld = counter;
            
            nextSceneValue = currentWorld * 10;
        }

        public void WorldFixedUpdate()
        {
            canChangeLevel = playerStateManager.playerCanChangeLevel;
            
            doorToNewRoom.isTrigger = canChangeLevel;

            level.text = $"{currentWorld} : {currentScene}";
        }

        private void NextLevel()
        {
            nextSceneValue = currentWorld * 10 + 1;
            
            if (currentScene < nextSceneValue - 1)
            {
                SceneManager.LoadSceneAsync(currentScene + 1);
            }
            else if (currentScene >= nextSceneValue - 1)
            {
                SceneManager.LoadSceneAsync(0);
            }
        }
    }
}
