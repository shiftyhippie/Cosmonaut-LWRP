/*
using Player;
using UnityEngine;

namespace Utilities
{
    public class ManagerScript : MonoBehaviour
    {
        public static ManagerScript Instance { get; private set; }
        public static int Counter { get; private set; }

        private void Start()
        {
            Instance = this;
        }

        public void IncrementCounter()
        {
            Counter++;
            UiTestScript.Instance.UpdatePointsText();
        }

        public void RestartGame()
        {
            PlayGamesScript.AddScoreToLeaderBoard(GPGSIds.leaderboard_leaderboard, Counter);
            Counter = 0;
            UiTestScript.Instance.UpdatePointsText();
        }
    }
}
*/
