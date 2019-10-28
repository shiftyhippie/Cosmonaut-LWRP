using UnityEngine;

namespace _EDITOR
{
    public class FloorTilePrefabScript : MonoBehaviour
    {
        [SerializeField] private GameObject floorBlock;
        [SerializeField] private GameObject wallBlock;
        [SerializeField] private GameObject waterBlock;
        [SerializeField] private GameObject enemyBlock;
        [SerializeField] private GameObject hazardBlock;
        
        public string tileDisplayName;

        public void FindBlocks()
        {
            foreach (Transform child in transform)
            {
                switch (child.gameObject.name)
                {
                    case "Floor Block":
                        floorBlock = child.gameObject;
                        
                        var tempFloor = floorBlock.GetComponent<FloorTileScript>();
                        tempFloor.floorBlock = floorBlock;
                        tempFloor.wallBlock = wallBlock;
                        tempFloor.waterBlock = waterBlock;
                        tempFloor.enemyBlock = enemyBlock;
                        tempFloor.hazardBlock = hazardBlock;
                        tempFloor.floorTilePrefabScript = this;
                        
                        break;
                    
                    case "Wall Block":
                        wallBlock = child.gameObject;
                        
                        var tempWall = wallBlock.GetComponent<FloorTileScript>();
                        tempWall.floorBlock = floorBlock;
                        tempWall.wallBlock = wallBlock;
                        tempWall.waterBlock = waterBlock;
                        tempWall.enemyBlock = enemyBlock;
                        tempWall.hazardBlock = hazardBlock;
                        tempWall.floorTilePrefabScript = this;

                        break;
                    
                    case "Water Block":
                        waterBlock = child.gameObject;
                        
                        var tempWater = waterBlock.GetComponent<FloorTileScript>();
                        tempWater.floorBlock = floorBlock;
                        tempWater.wallBlock = wallBlock;
                        tempWater.waterBlock = waterBlock;
                        tempWater.enemyBlock = enemyBlock;
                        tempWater.hazardBlock = hazardBlock;
                        tempWater.floorTilePrefabScript = this;

                        break;
                    
                    case "Enemy Block":
                        enemyBlock = child.gameObject;
                        
                        var tempEnemy = enemyBlock.GetComponent<FloorTileScript>();
                        tempEnemy.floorBlock = floorBlock;
                        tempEnemy.wallBlock = wallBlock;
                        tempEnemy.waterBlock = waterBlock;
                        tempEnemy.enemyBlock = enemyBlock;
                        tempEnemy.hazardBlock = hazardBlock;
                        tempEnemy.floorTilePrefabScript = this;

                        break;
                    
                    case "Hazard Block":
                        hazardBlock = child.gameObject;
                        
                        var tempHazard = hazardBlock.GetComponent<FloorTileScript>();
                        tempHazard.floorBlock = floorBlock;
                        tempHazard.wallBlock = wallBlock;
                        tempHazard.waterBlock = waterBlock;
                        tempHazard.enemyBlock = enemyBlock;
                        tempHazard.hazardBlock = hazardBlock;
                        tempHazard.floorTilePrefabScript = this;

                        break;
                }
            }

            tileDisplayName = DisplayBlockName(0);
        }
        
        public void MakeFloor()
        {
            var floorBlockPosition = floorBlock.transform.position;
            floorBlockPosition = new Vector3(floorBlockPosition.x, 0.5f, floorBlockPosition.z);
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

            tileDisplayName = DisplayBlockName(0);
        }
        
        public void MakeObstacle()
        {
            var floorBlockPosition = floorBlock.transform.position;
            floorBlockPosition = new Vector3(floorBlockPosition.x, 0.5f, floorBlockPosition.z);
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
            
            tileDisplayName = DisplayBlockName(1);
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
            
            tileDisplayName = DisplayBlockName(2);
        }

        public void MakeEnemy()
        {
            var floorBlockPosition = floorBlock.transform.position;
            floorBlockPosition = new Vector3(floorBlockPosition.x, 0.5f, floorBlockPosition.z);
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
            
            tileDisplayName = DisplayBlockName(3);
        }

        public void MakeHazard()
        {
            var floorBlockPosition = floorBlock.transform.position;
            floorBlockPosition = new Vector3(floorBlockPosition.x, 0.5f, floorBlockPosition.z);
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
            
            tileDisplayName = DisplayBlockName(4);
        }

        public string DisplayBlockName(int tile)
        {
            switch (tile)
            {
                case 0:
                    return "Floor Tile";
                case 1:
                    return "Wall Tile";
                case 2:
                    return "Water Tile";
                case 3:
                    return "Enemy Tile";
                case 4:
                    return "Hazard Tile";
                default:
                    Debug.LogError("Error 1: An unexpected tile type!");
                    return "ERROR TILE";
            }
        }
    }
}
