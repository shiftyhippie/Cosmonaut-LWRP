using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Player;
using UnityEngine;

namespace Utilities
{
    public static class SaveSystemForAndroid
    {
        public static void PlayerSaveData(PlayerStateHolder player)
        {
            var binaryFormatter = new BinaryFormatter();
            var filePath = Application.persistentDataPath + "/player.dataFile";
            var fileStream = new FileStream(filePath, FileMode.Create);
            
            var playerData = new PlayerData(player);
            
            binaryFormatter.Serialize(fileStream, playerData);
            fileStream.Close();
        }
        
        public static PlayerData PlayerLoadData()
        {
            var filePath = Application.persistentDataPath + "/player.dataFile";

            if (File.Exists(filePath))
            {
                var binaryFormatter = new BinaryFormatter();
                var fileStream = new FileStream(filePath, FileMode.Open);

                var playerData = binaryFormatter.Deserialize(fileStream) as PlayerData;
                fileStream.Close();
                
                return playerData;
            }
            else
            {
                Debug.LogError($"Save file not found in {filePath}");
                return null;
            }
        }
    }
}
