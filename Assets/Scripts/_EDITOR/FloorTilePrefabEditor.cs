using UnityEditor;
using UnityEngine;

namespace _EDITOR
{
    [CustomEditor(typeof(FloorTilePrefabScript))]
    public class FloorTilePrefabEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var floorTilePrefabScript = (FloorTilePrefabScript) target;
            
            GUILayout.Space(10);

            if (GUILayout.Button("Find Children in Prefab"))
            {
                floorTilePrefabScript.FindBlocks();
            }
            
            GUILayout.Space(10);

            if (GUILayout.Button("Make Floor"))
            {
                floorTilePrefabScript.MakeFloor();
            }
            
            GUILayout.Space(10);
            
            if (GUILayout.Button("Make Obstacle"))
            {
                floorTilePrefabScript.MakeObstacle();
            }
            
            GUILayout.Space(10);
            
            if (GUILayout.Button("Make Water"))
            {
                floorTilePrefabScript.MakeWater();
            }
                        
            GUILayout.Space(10);
            
            if (GUILayout.Button("Make Enemy"))
            {
                floorTilePrefabScript.MakeEnemy();
            }
                        
            GUILayout.Space(10);
            
            if (GUILayout.Button("Make Hazard"))
            {
                floorTilePrefabScript.MakeHazard();
            }
        }
    }
}
