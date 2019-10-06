/*
using Player;
using TMPro;
using UnityEngine;

namespace Utilities
{
    public class UiTestScript : MonoBehaviour
    {
        public static UiTestScript Instance { get; private set; }

        private void Start()
        {
            Instance = this;
        }

        [SerializeField] private TextMeshProUGUI pointsText;

        public void GetPoint()
        {
            ManagerScript.Instance.IncrementCounter();
        }

        public void Restart()
        {
            ManagerScript.Instance.RestartGame();
        }

        public void Increment()
        {
            PlayGamesScript.IncrementAchievement(GPGSIds.achievement_ppeter_griffin_in_fortnite, 2);
        }

        public void Unlock()
        {
            PlayGamesScript.UnlockAchievement(GPGSIds.achievement_in_space);
        }

        public void ShowAchievements()
        {
            PlayGamesScript.ShowAchievementsUi();
        }

        public void ShowLeaderBoards()
        {
            PlayGamesScript.ShowLeaderBoardUi();
        }

        public void UpdatePointsText()
        {
            pointsText.text = ManagerScript.Counter.ToString();
        }
    }
}
*/
