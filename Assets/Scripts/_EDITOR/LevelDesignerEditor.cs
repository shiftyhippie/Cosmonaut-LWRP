using System.Runtime.Remoting.Messaging;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace _EDITOR
{
    [CustomEditor(typeof(LevelDesignerScript))]
    public class LevelDesignerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var levelDesignerScript = (LevelDesignerScript) target;

            GUILayout.Space(10);

            if (GUILayout.Button("Find Scene Assets"))
            {
                levelDesignerScript.FindLevelAssets();
            }

            GUILayout.Space(10);

            if (GUILayout.Button("Build Default Scene"))
            {
                levelDesignerScript.BuildLevel();
                levelDesignerScript.BuildInBounds();
                if (levelDesignerScript.hasOutOfBounds)
                {
                    levelDesignerScript.BuildOutOfBounds();
                }
            }

            GUILayout.Space(10);

            if (GUILayout.Button("Delete Current Scene"))
            {
                LevelDesignerScript.DestroyCurrentLevel();
            }
            
            GUILayout.Space(10);

            if (GUILayout.Button("Optimise for Play"))
            {
                levelDesignerScript.OptimiseLevelForPlay();
            }
                        
            GUILayout.Space(10);

            if (GUILayout.Button("Add Hazards And Enemies (Optimise First!)"))
            {
                levelDesignerScript.AddHazardsAndEnemies();
            }      
            
            GUILayout.Space(10);

            if (GUILayout.Button("Add Hazards and Enemies to Manager!"))
            {
                levelDesignerScript.AddEnemiesAndHazardsToLists();
            }      
            
            GUILayout.Space(10);

            if (GUILayout.Button("Build Nav Mesh"))
            {
                levelDesignerScript.CreateNavMesh();
            }
                                    
            GUILayout.Space(10);

            if (GUILayout.Button("Clear Nav Mesh"))
            {
                levelDesignerScript.ClearNavMesh();
            }
            
            GUILayout.Space(10);

            EditorGUILayout.LabelField("Debug fix-y tools");
            if (GUILayout.Button("Debug Fix Door Position"))
            {
                levelDesignerScript.SetDoorPosition();
            }
            
            if (GUILayout.Button("Fix Player if not colliding"))
            {
                levelDesignerScript.DebugFixPlayer();
            }
            
            if (GUILayout.Button("Debug Add Water (Only do just before level ready to use)"))
            {
                levelDesignerScript.DebugAddWater();
            }
            
            if (GUI.changed)
            {
                EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
            }
        }
    }
}
