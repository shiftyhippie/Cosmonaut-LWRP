using UnityEngine;

namespace _EDITOR
{
    public class FloorTileScript : MonoBehaviour
    {
        public GameObject floorBlock;
        public GameObject wallBlock;
        public GameObject waterBlock;
        public GameObject enemyBlock;
        public GameObject hazardBlock;

        public FloorTilePrefabScript floorTilePrefabScript;
        
        public void MakeFloor()
        {
            var floorBlockPosition = floorBlock.transform.position;
            floorBlockPosition = new Vector3(floorBlockPosition.x, 0, floorBlockPosition.z);
            floorBlock.transform.position = floorBlockPosition;
            
            var wallBlockPosition = wallBlock.transform.position;
            wallBlockPosition = new Vector3(wallBlockPosition.x, -1, wallBlockPosition.z);
            wallBlock.transform.position = wallBlockPosition;
            
            var waterBlockPosition = waterBlock.transform.position;
            waterBlockPosition = new Vector3(waterBlockPosition.x, -1, waterBlockPosition.z);
            waterBlock.transform.position = waterBlockPosition;   

            var enemyBlockPosition = enemyBlock.transform.position;
            enemyBlockPosition = new Vector3(enemyBlockPosition.x, -1, enemyBlockPosition.z);
            enemyBlock.transform.position = enemyBlockPosition;
            
            var hazardBlockPosition = hazardBlock.transform.position;
            hazardBlockPosition = new Vector3(hazardBlockPosition.x, -1, hazardBlockPosition.z);
            hazardBlock.transform.position = hazardBlockPosition;

            floorTilePrefabScript.tileDisplayName = floorTilePrefabScript.DisplayBlockName(0);
        }
        
        public void MakeObstacle()
        {
            var floorBlockPosition = floorBlock.transform.position;
            floorBlockPosition = new Vector3(floorBlockPosition.x, 0, floorBlockPosition.z);
            floorBlock.transform.position = floorBlockPosition;
            
            var wallBlockPosition = wallBlock.transform.position;
            wallBlockPosition = new Vector3(wallBlockPosition.x, 1, wallBlockPosition.z);
            wallBlock.transform.position = wallBlockPosition;
            
            var waterBlockPosition = waterBlock.transform.position;
            waterBlockPosition = new Vector3(waterBlockPosition.x, -1, waterBlockPosition.z);
            waterBlock.transform.position = waterBlockPosition;

            var enemyBlockPosition = enemyBlock.transform.position;
            enemyBlockPosition = new Vector3(enemyBlockPosition.x, -1, enemyBlockPosition.z);
            enemyBlock.transform.position = enemyBlockPosition;
            
            var hazardBlockPosition = hazardBlock.transform.position;
            hazardBlockPosition = new Vector3(hazardBlockPosition.x, -1, hazardBlockPosition.z);
            hazardBlock.transform.position = hazardBlockPosition;
            
            floorTilePrefabScript.tileDisplayName = floorTilePrefabScript.DisplayBlockName(1);
        }
        
        public void MakeWater()
        {
            var floorBlockPosition = floorBlock.transform.position;
            floorBlockPosition = new Vector3(floorBlockPosition.x, -1, floorBlockPosition.z);
            floorBlock.transform.position = floorBlockPosition;
            
            var wallBlockPosition = wallBlock.transform.position;
            wallBlockPosition = new Vector3(wallBlockPosition.x, -1, wallBlockPosition.z);
            wallBlock.transform.position = wallBlockPosition;
            
            var waterBlockPosition = waterBlock.transform.position;
            waterBlockPosition = new Vector3(waterBlockPosition.x, 0, waterBlockPosition.z);
            waterBlock.transform.position = waterBlockPosition;

            var enemyBlockPosition = enemyBlock.transform.position;
            enemyBlockPosition = new Vector3(enemyBlockPosition.x, -1, enemyBlockPosition.z);
            enemyBlock.transform.position = enemyBlockPosition;
            
            var hazardBlockPosition = hazardBlock.transform.position;
            hazardBlockPosition = new Vector3(hazardBlockPosition.x, -1, hazardBlockPosition.z);
            hazardBlock.transform.position = hazardBlockPosition;
            
            floorTilePrefabScript.tileDisplayName = floorTilePrefabScript.DisplayBlockName(2);
        }

        public void MakeEnemy()
        {
            var floorBlockPosition = floorBlock.transform.position;
            floorBlockPosition = new Vector3(floorBlockPosition.x, 0, floorBlockPosition.z);
            floorBlock.transform.position = floorBlockPosition;
            
            var wallBlockPosition = wallBlock.transform.position;
            wallBlockPosition = new Vector3(wallBlockPosition.x, -1, wallBlockPosition.z);
            wallBlock.transform.position = wallBlockPosition;
            
            var waterBlockPosition = waterBlock.transform.position;
            waterBlockPosition = new Vector3(waterBlockPosition.x, -1, waterBlockPosition.z);
            waterBlock.transform.position = waterBlockPosition;

            var enemyBlockPosition = enemyBlock.transform.position;
            enemyBlockPosition = new Vector3(enemyBlockPosition.x, 1.5f, enemyBlockPosition.z);
            enemyBlock.transform.position = enemyBlockPosition;
            
            var hazardBlockPosition = hazardBlock.transform.position;
            hazardBlockPosition = new Vector3(hazardBlockPosition.x, -1, hazardBlockPosition.z);
            hazardBlock.transform.position = hazardBlockPosition;
            
            floorTilePrefabScript.tileDisplayName = floorTilePrefabScript.DisplayBlockName(3);
        }

        public void MakeHazard()
        {
            var floorBlockPosition = floorBlock.transform.position;
            floorBlockPosition = new Vector3(floorBlockPosition.x, 0, floorBlockPosition.z);
            floorBlock.transform.position = floorBlockPosition;
            
            var wallBlockPosition = wallBlock.transform.position;
            wallBlockPosition = new Vector3(wallBlockPosition.x, -1, wallBlockPosition.z);
            wallBlock.transform.position = wallBlockPosition;
            
            var waterBlockPosition = waterBlock.transform.position;
            waterBlockPosition = new Vector3(waterBlockPosition.x, -1, waterBlockPosition.z);
            waterBlock.transform.position = waterBlockPosition;   

            var enemyBlockPosition = enemyBlock.transform.position;
            enemyBlockPosition = new Vector3(enemyBlockPosition.x, -1, enemyBlockPosition.z);
            enemyBlock.transform.position = enemyBlockPosition;
            
            var hazardBlockPosition = hazardBlock.transform.position;
            hazardBlockPosition = new Vector3(hazardBlockPosition.x, 1, hazardBlockPosition.z);
            hazardBlock.transform.position = hazardBlockPosition;

            floorTilePrefabScript.tileDisplayName = floorTilePrefabScript.DisplayBlockName(4);
        }
    }
}

