using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utilities
{
    public class LevelSelectInputManager : MonoBehaviour
    {
        [SerializeField] private float initialXTouch;
        [SerializeField] private GameHubWorld gameHubWorld;

        // ReSharper disable once NotAccessedField.Global
        public int actualLevelNum;
        
        private void Update()
        {
            foreach (var touch in Input.touches)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        initialXTouch = touch.position.x;
                        break;
                    case TouchPhase.Ended when touch.position.x < initialXTouch:
                        gameHubWorld.NextLevel();
                        break;
                    case TouchPhase.Ended when touch.position.x > initialXTouch:
                        gameHubWorld.LastLevel();
                        break;
                    case TouchPhase.Ended when touch.position.x <= initialXTouch + 0.1f ||
                                               touch.position.x >= initialXTouch + 10f:

                        break;
                }
            }
            
            actualLevelNum = GetLevelClicked();
                        
            if (GetLevelClicked() == 1)
            {
                SceneManager.LoadScene(sceneBuildIndex: 2); // First Scene of Level 1
            }
            else if (GetLevelClicked() == 2)
            {
                SceneManager.LoadScene(sceneBuildIndex: 12); // First Scene of Level 2
            }
        }

        private int GetLevelClicked()
        {
            if( Input.GetMouseButtonDown(0) )
            {
                if (Camera.main != null)
                {
                    var ray = Camera.main.ScreenPointToRay( Input.mousePosition );

                    if( Physics.Raycast( ray, out var hit, 100 ) )
                    {
                        return Convert.ToInt32(hit.transform.gameObject.name);
                    }
                }
            }

            return 0;
        }
    }
}