using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controller
{
    public class MainMenuManager : MonoBehaviour
    {
        public void PlayGame()
        {
            SceneManager.LoadScene(1);
        }

        public void PlaySpecificWorld()
        {
            SceneManager.LoadScene(1);
        }
        
        public void QuitToMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void QuitToHubMenu()
        {
            SceneManager.LoadScene(1);
        }
        
        public void QuitGame()
        {
            Application.Quit();
        }
  
    }
}
