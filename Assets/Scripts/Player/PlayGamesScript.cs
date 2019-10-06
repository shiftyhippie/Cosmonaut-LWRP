/*
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

namespace Player
{
    public class PlayGamesScript : MonoBehaviour
    {
        private void Start()
        {
            var configuration = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(configuration);
            PlayGamesPlatform.Activate();
            
            SignIn();
        }

        private void SignIn()
        {
            Social.localUser.Authenticate(success => { });
        }

        #region Achievements

        public static void UnlockAchievement(string id)
        {
            Social.ReportProgress(id, 100, success => { });
        }

        public static void IncrementAchievement(string id, int stepsToIncrement)
        {
            PlayGamesPlatform.Instance.IncrementAchievement(id, stepsToIncrement, success => { });
        }

        public static void ShowAchievementsUi()
        {
            Social.ShowAchievementsUI();
        }

        #endregion

        #region Leaderboards

        public static void AddScoreToLeaderBoard(string leaderBoardId, long score)
        {
            Social.ReportScore(score, leaderBoardId, success => { });
        }
        
        public static void ShowLeaderBoardUi()
        {
            Social.ShowLeaderboardUI();
        }

        #endregion
    }
}
*/
