using UnityEngine;
using UnityEditor;

namespace _EDITOR
{
    [CustomEditor(typeof(EnemyPickerScript))]
    public class EnemyPickerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var enemyPickerScript = (EnemyPickerScript) target;
            
            GUILayout.Space(10);

            switch (enemyPickerScript.level)
            {
                case 0:
                {
                    if (GUILayout.Button("Set as Mech"))
                    {
                        enemyPickerScript.MakeEnemyRobotMech();
                    }
                    
                    GUILayout.Space(10);
                    
                    if (GUILayout.Button("Set as Mad Scientist"))
                    {
                        enemyPickerScript.MakeEnemyRobotScientist();
                    }
                                        
                    GUILayout.Space(10);
                    
                    if (GUILayout.Button("Set as Gatling Robot"))
                    {
                        enemyPickerScript.MakeEnemyRobotGatlingGun();
                    }
                                        
                    GUILayout.Space(10);
                    
                    if (GUILayout.Button("Set as Rocket Robot"))
                    {
                        enemyPickerScript.MakeEnemyRobotRocketLauncher();
                    }
                                        
                    GUILayout.Space(10);
                    
                    if (GUILayout.Button("Set as Sniper Robot"))
                    {
                        enemyPickerScript.MakeEnemyRobotSniperRife();
                    }
                    
                    break;
                }
                case 1:
                    if (GUILayout.Button("Set as Worm"))
                    {
                        enemyPickerScript.MakeEnemyAlienWorm();
                    }
                    
                    GUILayout.Space(10);
                    
                    if (GUILayout.Button("Set as Grey"))
                    {
                        enemyPickerScript.MakeEnemyAlienGrey();
                    }
                                        
                    GUILayout.Space(10);
                    
                    if (GUILayout.Button("Set as Alien Brute"))
                    {
                        enemyPickerScript.MakeEnemyAlienBrute();
                    }
                                        
                    GUILayout.Space(10);
                    
                    if (GUILayout.Button("Set as Alien Slime"))
                    {
                        enemyPickerScript.MakeEnemyAlienSlime();
                    }
                                        
                    GUILayout.Space(10);
                    
                    if (GUILayout.Button("Set as Laser Bat"))
                    {
                        enemyPickerScript.MakeEnemyAlienBat();
                    }
                    
                    break;
            }
        }
    }
}