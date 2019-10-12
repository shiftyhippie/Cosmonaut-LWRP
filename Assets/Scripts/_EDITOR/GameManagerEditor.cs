using UnityEditor;
using UnityEngine;

namespace _EDITOR
{
    [CustomEditor(typeof(GameManagerScript))]
    public class GameManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var gameManagerScript = (GameManagerScript) target;

            GUILayout.Space(10);

            if (GUILayout.Button("Setup Game Manager for this Level!"))
            {
                gameManagerScript.SetupGameManager();
            }
        }
    }
}