using UnityEditor;
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

            if (GUILayout.Button("Build Default Scene"))
            {
                levelDesignerScript.BuildLevel();
                levelDesignerScript.BuildInBounds();
                levelDesignerScript.BuildOutOfBounds();
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
