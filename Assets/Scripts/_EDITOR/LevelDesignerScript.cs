using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace _EDITOR
{
    public class LevelDesignerScript : MonoBehaviour
    {
        [Header("Level Requirements")] public GameObject tile;
        public Vector3 tileLocation;
        public bool hasOutOfBounds;
        private bool optimised;
        public GameObject levelPrefab;
        public GameObject enemyPrefab;
        public GameObject hazardPrefab;
        public GameObject level;
        public Material tileLightMat;
        public Material tileDarkMat;

        [Header("Level Setup - DONT EDIT")]
        public GameObject gameCamera;
        public GameObject gameLight;
        public GameObject gameManager;
        public GameObject gameUi;
        public GameObject gameLevelChange;
        public GameObject player;

        [Header("Wall GameObjects")] public GameObject levelOobPrefab;
        public GameObject levelOobosPrefab;
        public GameObject tileOob;
        public GameObject tileOobGateway;
        public Material tileOutOfBoundsMat;

        [Header("Level Width")] public int levelWidth;
        public float xOffset;

        [Header("Level Height")] public int levelHeight;
        public float yOffset;

        public Transform[] toAdd;
        public Transform[] hazards;

        public void BuildLevel()
        {
            GameObject temp;
            
            if (level == null)
            {
                level = new GameObject {name = "Level"};
                level.transform.position = Vector3.zero;
            }
            
            if (player == null)
            {
                player = Resources.Load("Player") as GameObject;
                temp = Instantiate(player, new Vector3(0, 0, -(levelHeight / 2f)), Quaternion.identity);
                player = temp;
                temp.name = "Player";
            }
            else
            {
                player = null;
                var tempDelete = GameObject.Find("Player");
                DestroyImmediate(tempDelete);
                
                player = Resources.Load("Player") as GameObject;
                temp = Instantiate(player, new Vector3(0, 0, -(levelHeight / 2f)), Quaternion.identity);
                player = temp;
                temp.name = "Player";
            }

            if (gameCamera == null)
            {
                gameCamera = Resources.Load("Game Camera") as GameObject;
                temp = Instantiate(gameCamera);
                gameCamera = temp;
                temp.name = "Game Camera";
            }
            else
            {
                gameCamera = null;
                var tempDelete = GameObject.Find("Game Camera");
                DestroyImmediate(tempDelete);

                gameCamera = Resources.Load("Game Camera") as GameObject;
                temp = Instantiate(gameCamera);
                gameCamera = temp;
                temp.name = "Game Camera";
            }

            if (gameLight == null)
            {
                gameLight = Resources.Load("Game Light") as GameObject;
                temp = Instantiate(gameLight);
                gameLight = temp;
                temp.name = "Game Light";
            }
            else
            {
                gameLight = null;
                var tempDelete = GameObject.Find("Game Light");
                DestroyImmediate(tempDelete);

                gameLight = Resources.Load("Game Light") as GameObject;
                temp = Instantiate(gameLight);
                gameLight = temp;
                temp.name = "Game Light";
            }
            
            if (gameManager == null)
            {
                gameManager = Resources.Load("Game Manager") as GameObject;
                temp = Instantiate(gameManager);
                gameManager = temp;
                temp.name = "Game Manager";
            }
            else
            {
                gameManager = null;
                var tempDelete = GameObject.Find("Game Manager");
                DestroyImmediate(tempDelete);

                gameManager = Resources.Load("Game Manager") as GameObject;
                temp = Instantiate(gameManager);
                gameManager = temp;
                temp.name = "Game Manager";
            }

            if (gameUi == null)
            {
                gameUi = Resources.Load("Game Ui") as GameObject;
                temp = Instantiate(gameUi);
                gameUi = temp;
                temp.name = "Game Ui";
            }
            else
            {
                gameUi = null;
                var tempDelete = GameObject.Find("Game Ui");
                DestroyImmediate(tempDelete);

                gameUi = Resources.Load("Game Ui") as GameObject;
                temp = Instantiate(gameUi);
                gameUi = temp;
                temp.name = "Game Ui";
            }
            
            if (gameLevelChange == null)
            {
                gameLevelChange = Resources.Load("TempDoorModel") as GameObject;
                temp = Instantiate(gameLevelChange);
                gameLevelChange = temp;
                temp.name = "TempDoorModel";
            }
            else
            {
                gameLevelChange = null;
                var tempDelete = GameObject.Find("TempDoorModel");
                DestroyImmediate(tempDelete);

                gameLevelChange = Resources.Load("TempDoorModel") as GameObject;
                temp = Instantiate(gameLevelChange);
                gameLevelChange = temp;
                temp.name = "TempDoorModel";
            }

            optimised = false;
        }

        public void BuildInBounds()
        {
            tileLocation = Vector3.zero;

            if (levelPrefab == null)
            {
                levelPrefab = new GameObject {name = "FloorOfLevel"};
                levelPrefab.transform.position = Vector3.zero;
                levelPrefab.transform.parent = level.transform;
            }
            else
            {
                var children = (from Transform child in levelPrefab.transform select child.gameObject).ToList();
                children.ForEach(DestroyImmediate);
            }

            if (enemyPrefab == null)
            {
                enemyPrefab = new GameObject {name = "EnemyHolder"};
                enemyPrefab.transform.position = Vector3.zero;
                enemyPrefab.transform.parent = level.transform;
            }
            else
            {
                var children = (from Transform child in enemyPrefab.transform select child.gameObject).ToList();
                children.ForEach(DestroyImmediate);
            }

            if (hazardPrefab == null)
            {
                hazardPrefab = new GameObject {name = "HazardPrefab"};
                hazardPrefab.transform.position = Vector3.zero;
                hazardPrefab.transform.parent = level.transform;
            }
            else
            {
                var children = (from Transform child in hazardPrefab.transform select child.gameObject).ToList();
                children.ForEach(DestroyImmediate);
            }

            xOffset = levelWidth / 2.0f;
            yOffset = levelHeight / 2.0f;

            tileLocation = new Vector3(tileLocation.x - xOffset, 0, tileLocation.z - yOffset);

            #region World Generation

            var isItEven = 0;
            var hasItBeenLevelWidth = 0;
            if (levelWidth % 2 == 0 && levelHeight % 2 == 0) // Even Even
            {
                for (var i = 0.5f; i < levelHeight; i++) // Vertical
                for (var j = 0.5f; j < levelWidth; j++) // Horizontal
                {
                    if (hasItBeenLevelWidth % levelWidth == 0) isItEven++;
                    hasItBeenLevelWidth++;
                    isItEven++;

                    tileLocation = new Vector3(j - xOffset, tileLocation.y, i - yOffset);

                    var curTile = Instantiate(tile, tileLocation, Quaternion.identity);
                    curTile.name = $"{j - xOffset}, {i - yOffset}";
                    curTile.transform.parent = levelPrefab.transform;

                    if (isItEven % 2 == 0) curTile.GetComponentInChildren<MeshRenderer>().material = tileDarkMat;
                    if (isItEven % 2 != 0) curTile.GetComponentInChildren<MeshRenderer>().material = tileLightMat;
                }
            }
            else if (levelWidth % 2 == 0 && levelHeight % 2 != 0) // Even Odd
            {
                for (var i = 0.5f; i < levelHeight; i++) // Vertical
                for (var j = 0.5f; j < levelWidth; j++) // Horizontal
                {
                    if (hasItBeenLevelWidth % levelWidth == 0) isItEven++;
                    hasItBeenLevelWidth++;
                    isItEven++;

                    tileLocation = new Vector3(j - xOffset, tileLocation.y, i - yOffset);

                    var curTile = Instantiate(tile, tileLocation, Quaternion.identity);
                    curTile.name = $"{j - xOffset}, {i - yOffset}";
                    curTile.transform.parent = levelPrefab.transform;

                    if (isItEven % 2 == 0) curTile.GetComponentInChildren<MeshRenderer>().material = tileDarkMat;
                    if (isItEven % 2 != 0) curTile.GetComponentInChildren<MeshRenderer>().material = tileLightMat;
                }
            }
            else
            {
                if (levelWidth % 2 != 0 && levelHeight % 2 == 0) // Odd Even
                    for (var i = 0.5f; i < levelHeight; i++) // Vertical
                    for (var j = 0.5f; j < levelWidth; j++) // Horizontal
                    {
                        isItEven++;

                        tileLocation = new Vector3(j - xOffset, tileLocation.y, i - yOffset);

                        var curTile = Instantiate(tile, tileLocation, Quaternion.identity);
                        curTile.name = $"{j - xOffset}, {i - yOffset}";
                        curTile.transform.parent = levelPrefab.transform;

                        if (isItEven % 2 == 0) curTile.GetComponentInChildren<MeshRenderer>().material = tileDarkMat;
                        if (isItEven % 2 != 0) curTile.GetComponentInChildren<MeshRenderer>().material = tileLightMat;
                    }
                else if (levelWidth % 2 != 0 && levelHeight % 2 != 0) // Odd Odd
                    for (var i = 0.5f; i < levelHeight; i++) // Vertical
                    for (var j = 0.5f; j < levelWidth; j++) // Horizontal
                    {
                        isItEven++;

                        tileLocation = new Vector3(j - xOffset, tileLocation.y, i - yOffset);

                        var curTile = Instantiate(tile, tileLocation, Quaternion.identity);
                        curTile.name = $"{j - xOffset}, {i - yOffset}";
                        curTile.transform.parent = levelPrefab.transform;

                        if (isItEven % 2 == 0) curTile.GetComponentInChildren<MeshRenderer>().material = tileDarkMat;
                        if (isItEven % 2 != 0) curTile.GetComponentInChildren<MeshRenderer>().material = tileLightMat;
                    }
            }

            #endregion
        }

        public void BuildOutOfBounds()
        {
            if (levelOobPrefab == null)
            {
                levelOobPrefab = new GameObject {name = "OutOfBoundsWalls"};
                levelOobPrefab.transform.position = Vector3.zero;
                levelOobPrefab.transform.parent = level.transform;
            }
            else
            {
                var children = (from Transform child in levelOobPrefab.transform select child.gameObject).ToList();
                children.ForEach(DestroyImmediate);
            }

            if (levelOobosPrefab == null)
            {
                levelOobosPrefab = new GameObject {name = "OutOfBoundsOffScreen"};
                levelOobosPrefab.transform.position = Vector3.zero;
                levelOobosPrefab.transform.parent = level.transform;
            }
            else
            {
                var children = (from Transform child in levelOobosPrefab.transform select child.gameObject).ToList();
                children.ForEach(DestroyImmediate);
            }

            var lastHeight = 0;
            var lastWidth = 0;

            for (var h = 0; h <= levelHeight; h++)
            {
                lastHeight += 1;
                var oobWall = Instantiate(tileOob,
                    new Vector3(levelWidth / 2f + 0.5f, 0, levelHeight / 2f + 0.5f - lastHeight),
                    Quaternion.identity);
                oobWall.gameObject.name = $"{h + 1}";
                oobWall.transform.parent = levelOobPrefab.transform;
            }

            for (var w = 0; w <= levelWidth; w++)
            {
                lastWidth += 1;
                var oobWall = Instantiate(tileOob,
                    new Vector3(levelWidth / 2f + 0.5f - lastWidth, 0, levelHeight / 2f + 0.5f - lastHeight),
                    Quaternion.identity);
                oobWall.gameObject.name = $"{w + 1}";
                oobWall.transform.parent = levelOobPrefab.transform;
            }

            for (var h = 0; h <= levelHeight; h++)
            {
                lastHeight -= 1;
                var oobWall = Instantiate(tileOob,
                    new Vector3(levelWidth / 2f + 0.5f - lastWidth, 0, levelHeight / 2f + 0.5f - lastHeight),
                    Quaternion.identity);
                oobWall.gameObject.name = $"{h + 1}";
                oobWall.transform.parent = levelOobPrefab.transform;
            }

            for (var w = 0; w <= levelWidth; w++)
                if (levelWidth % 2 != 0)
                {
                    if (w + 1 == Mathf.RoundToInt((levelWidth - 1) / 2f) ||
                        w + 1 == Mathf.RoundToInt((levelWidth - 1) / 2f) + 1 ||
                        w + 1 == Mathf.RoundToInt((levelWidth - 1) / 2f) + 2)
                    {
                        lastWidth -= 1;
                        var oobGate = Instantiate(tileOobGateway,
                            new Vector3(levelWidth / 2f + 0.5f - lastWidth, 0, levelHeight / 2f + 0.5f - lastHeight),
                            Quaternion.identity);
                        oobGate.gameObject.name = $"{w + 1}: Gateway";
                        oobGate.transform.parent = levelOobPrefab.transform;
                    }
                    else
                    {
                        lastWidth -= 1;
                        var oobWall = Instantiate(tileOob,
                            new Vector3(levelWidth / 2f + 0.5f - lastWidth, 0, levelHeight / 2f + 0.5f - lastHeight),
                            Quaternion.identity);
                        oobWall.gameObject.name = $"{w + 1}";
                        oobWall.transform.parent = levelOobPrefab.transform;
                    }
                }
                else
                {
                    if (w + 1 == Mathf.RoundToInt((levelWidth - 1) / 2f) ||
                        w + 1 == Mathf.RoundToInt((levelWidth - 1) / 2f) + 1)
                    {
                        lastWidth -= 1;
                        var oobGate = Instantiate(tileOobGateway,
                            new Vector3(levelWidth / 2f + 0.5f - lastWidth, 0, levelHeight / 2f + 0.5f - lastHeight),
                            Quaternion.identity);
                        oobGate.gameObject.name = $"{w + 1}";
                        oobGate.transform.parent = levelOobPrefab.transform;
                    }
                    else
                    {
                        lastWidth -= 1;
                        var oobWall = Instantiate(tileOob,
                            new Vector3(levelWidth / 2f + 0.5f - lastWidth, 0, levelHeight / 2f + 0.5f - lastHeight),
                            Quaternion.identity);
                        oobWall.gameObject.name = $"{w + 1}: Gateway";
                        oobWall.transform.parent = levelOobPrefab.transform;
                    }
                }

            for (var j = 0; j < 8; j++)
            for (var i = 0; i < levelWidth + 2; i++)
            {
                var oobWilderness = Instantiate(tileOob,
                    new Vector3(-(levelWidth / 2f) - 0.5f + i, 0, -(levelHeight / 2f) - 1.5f - j), Quaternion.identity);
                oobWilderness.transform.parent = levelOobosPrefab.transform;
            }

            for (var j = 0; j < 8; j++)
            for (var i = 0; i < levelWidth + 2; i++)
            {
                var oobWilderness = Instantiate(tileOob,
                    new Vector3(levelWidth / 2f + 0.5f - i, 0, levelHeight / 2f + 1.5f + j), Quaternion.identity);
                oobWilderness.transform.parent = levelOobosPrefab.transform;
            }
        }

        public void DestroyCurrentLevel()
        {
            var allGo = FindObjectsOfType(typeof(GameObject));
            foreach (var go in allGo)
            {
                if (go.name != "LevelDesigner(DeleteForBuild)")
                {
                    DestroyImmediate(go);
                }
            }
        }

        public void OptimiseLevelForPlay()
        {
            var children = levelPrefab.gameObject.GetComponentsInChildren<Transform>();

            foreach (var child in children)
                if (child.position.y < 0 && child.name != "FloorOfLevel")
                    DestroyImmediate(child.gameObject);

            optimised = true;
        }

        public void AddHazardsAndEnemies()
        {
            toAdd = levelPrefab.gameObject.GetComponentsInChildren<Transform>();
            
            if(optimised)
            {
                foreach (var optimisedAddition in toAdd)
                {
                    if (optimisedAddition.name == "Enemy Block")
                    {
                        var position = optimisedAddition.transform.position;

                        var temp = Instantiate(optimisedAddition.GetComponent<EnemyPickerScript>().currentEnemy,
                            new Vector3(position.x, 1, position.z), Quaternion.identity);

                        temp.transform.parent = enemyPrefab.transform;

                        DestroyImmediate(optimisedAddition.gameObject);
                    }

                    else if (optimisedAddition.name == "Hazard Block")
                    {
                        var position = optimisedAddition.transform.position;

                        var temp = Instantiate(optimisedAddition.GetComponent<HazardPickerScript>().currentHazard,
                            new Vector3(position.x, 1, position.z), Quaternion.identity);

                        temp.transform.parent = hazardPrefab.transform;

                        DestroyImmediate(optimisedAddition.gameObject);
                    }
                }
            }
            else
            {
                Debug.LogError("ERROR: Level needs to be optimised!");
            }
        }

        public void CreateNavMesh()
        {
            var children = levelPrefab.gameObject.GetComponentsInChildren<NavMeshSurface>();

            foreach (var child in children)
                if (child.gameObject.name == "0, 0" || child.gameObject.name == "0.5, 0" ||
                    child.gameObject.name == "0, 0.5")
                    child.BuildNavMesh();
        }

        public void ClearNavMesh()
        {
            var children = levelPrefab.gameObject.GetComponentsInChildren<NavMeshSurface>();

            foreach (var child in children)
                if (child.gameObject.name == "0, 0" || child.gameObject.name == "0.5, 0" ||
                    child.gameObject.name == "0, 0.5")
                    NavMesh.RemoveAllNavMeshData();
        }
    }
}