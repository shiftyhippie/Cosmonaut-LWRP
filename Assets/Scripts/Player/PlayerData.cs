using System.Collections.Generic;

namespace Player
{
    [System.Serializable]
    public class PlayerData
    {
        public int level;
        public int xp;
        public int gold;
        public int gems;
        public int bestWorld;
        
        public List<int> ownedItems = new List<int>();
        public List<int> ownedUpgrades = new List<int>();
        public List<int> currentEquips = new List<int>();

        public PlayerData(PlayerStateHolder player)
        {
            level = player.playerAccountLevel;
            xp = player.playerAccountXp;
            gold = player.playerAccountGold;
            gems = player.playerAccountGems;
            bestWorld = player.furthestWorld;

            foreach (var item in player.ownedItems)
            {
                ownedItems.Add(item);
            }
            
            foreach (var item in player.ownedUpgrades)
            {
                ownedUpgrades.Add(item);
            }
            
            foreach (var item in player.currentEquips)
            {
                currentEquips.Add(item);
            }
        }
    }
}
