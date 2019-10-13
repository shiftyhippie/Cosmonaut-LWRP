﻿using UnityEditor;
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
                levelDesignerScript.DestroyCurrentLevel();
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
        }
    }
}
