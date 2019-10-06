using Player;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utilities
{
    public class LevelChange : MonoBehaviour
    {
        [SerializeField] private bool canChangeLevel;
        
        [SerializeField] private int currentWorld;

        [SerializeField] private PlayerStateManager playerStateManager;
        
        [SerializeField] private Collider doorToNewRoom;
        
        [SerializeField] private int currentScene;
        [SerializeField] private int nextSceneValue;

        [SerializeField] private TextMeshProUGUI level;
        
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
            var currentSceneTemp = currentScene - 2;
            
            for (counter = 0; currentSceneTemp > 0; counter++)
            {
                currentSceneTemp -= 10;
            }

            if (currentScene == 2)
            {
                counter = 1;
            }
            
            currentWorld = counter;
            
            nextSceneValue = currentWorld * 10 + 2;
        }

        public void WorldFixedUpdate()
        {
            canChangeLevel = playerStateManager.playerCanChangeLevel;
            
            doorToNewRoom.isTrigger = canChangeLevel;

            level.text = $"{currentWorld} : {currentScene + -1}";
        }

        private void NextLevel()
        {
            nextSceneValue = currentWorld * 10 + 2;
            
            if (currentScene < nextSceneValue - 1)
            {
                SceneManager.LoadSceneAsync(currentScene + 1);
            }
            else if (currentScene >= nextSceneValue - 1)
            {
                SceneManager.LoadSceneAsync(1);
            }
        }
    }
}
