using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace Player
{
    public class PlayerStateHolder : MonoBehaviour
    {
        public int furthestWorld;
        public string furthestWorldName;

        public int playerAccountLevel;
        public int playerAccountXp;
        public int playerAccountGold;
        public int playerAccountGems;
        
        public List<int> ownedItems = new List<int>();
        public List<int> ownedUpgrades = new List<int>();
        public List<int> currentEquips = new List<int>();
        
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            furthestWorld = 1;
            furthestWorldName = $"World {furthestWorld}: Spaceship";

            playerAccountLevel = 1;
            playerAccountXp = 0;

            playerAccountGold = 0;
            playerAccountGems = 0;

            LoadPlayer();
        }
        
        public void SavePlayer()
        {
            SaveSystemForAndroid.PlayerSaveData(this);
        }

        public void LoadPlayer()
        {
            var playerData = SaveSystemForAndroid.PlayerLoadData();
            
            furthestWorld = playerData.bestWorld;
            furthestWorldName = $"World {furthestWorld}: Spaceship";

            playerAccountLevel = playerData.level;
            playerAccountXp = playerData.xp;

            playerAccountGold = playerData.gold;
            playerAccountGems = playerData.gems;
        }
    }
}
