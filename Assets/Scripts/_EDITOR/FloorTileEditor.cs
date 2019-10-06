using UnityEditor;
using UnityEngine;

namespace _EDITOR
{
    [CustomEditor(typeof(FloorTileScript))]
    public class FloorTileEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var floorTileScript = (FloorTileScript) target;
            
            GUILayout.Space(10);

            if (GUILayout.Button("Make Floor"))
            {
                floorTileScript.MakeFloor();
            }
            
            GUILayout.Space(10);
            
            if (GUILayout.Button("Make Obstacle"))
            {
                floorTileScript.MakeObstacle();
            }
            
            GUILayout.Space(10);
            
            if (GUILayout.Button("Make Water"))
            {
                floorTileScript.MakeWater();
            }
                        
            GUILayout.Space(10);
            
            if (GUILayout.Button("Make Enemy"))
            {
                floorTileScript.MakeEnemy();
            }
                        
            GUILayout.Space(10);
            
            if (GUILayout.Button("Make Hazard"))
            {
                floorTileScript.MakeHazard();
            }
        }
    }
}
