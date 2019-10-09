using UnityEngine;
using UnityEditor;

namespace _EDITOR
{
    [CustomEditor(typeof(HazardPickerScript))]
    public class HazardPickerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var hazardPickerScript = (HazardPickerScript) target;

            GUILayout.Space(10);

            switch (hazardPickerScript.level)
            {
                case 0:
                {
                    if (GUILayout.Button("Set as Spikes"))
                    {
                        hazardPickerScript.MakeHazardSpaceshipSpikes();
                    }

                    GUILayout.Space(10);

                    if (GUILayout.Button("Set as Saw Blade"))
                    {
                        hazardPickerScript.MakeHazardSpaceshipSawBlade();
                    }

                    GUILayout.Space(10);

                    if (GUILayout.Button("Set as Acid Pool"))
                    {
                        hazardPickerScript.MakeHazardSpaceshipAcidPool();
                    }

                    GUILayout.Space(10);

                    if (GUILayout.Button("Set as Fire"))
                    {
                        hazardPickerScript.MakeHazardSpaceshipFire();
                    }

                    GUILayout.Space(10);

                    break;
                }
                
                case 1:
                    if (GUILayout.Button("Set as Spikes"))
                    {
                        hazardPickerScript.MakeHazardAlpheriaSpikes();
                    }

                    GUILayout.Space(10);

                    if (GUILayout.Button("Set as Saw Blade"))
                    {
                        hazardPickerScript.MakeHazardAlpheriaSawBlade();
                    }

                    GUILayout.Space(10);

                    if (GUILayout.Button("Set as Acid Pool"))
                    {
                        hazardPickerScript.MakeHazardAlpheriaAcidPool();
                    }

                    GUILayout.Space(10);

                    if (GUILayout.Button("Set as Gas Cloud"))
                    {
                        hazardPickerScript.MakeHazardAlpheriaGasCloud();
                    }

                    GUILayout.Space(10);

                    break;
            }
        }
    }
}