using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utilities
{
    public class QuitToMenuQuickly : MonoBehaviour
    {
        public void QuitToMainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}
