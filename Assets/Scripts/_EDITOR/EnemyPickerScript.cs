using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _EDITOR
{
    public class EnemyPickerScript : MonoBehaviour
    {
        public List<GameObject> enemiesLevelOne = new List<GameObject>();
        public List<GameObject> enemiesLevelTwo = new List<GameObject>();

        public GameObject currentEnemy;
        
        [Range(0, 1)] public int level;

        #region Level One
        
        public void MakeEnemyRobotMech()
        {
            foreach (var enemy in enemiesLevelOne.Where(enemy => enemy.gameObject.name == "01EnemyRobotMech"))
            {
                currentEnemy = enemy;
            }
        }

        public void MakeEnemyRobotScientist()
        {
            foreach (var enemy in enemiesLevelOne.Where(enemy => enemy.gameObject.name == "02EnemyRobotMadScientist"))
            {
                currentEnemy = enemy;
            }
        }

        public void MakeEnemyRobotGatlingGun()
        {
            foreach (var enemy in enemiesLevelOne.Where(enemy => enemy.gameObject.name == "03EnemyRobotGatlingRobot"))
            {
                currentEnemy = enemy;
            }
        }

        public void MakeEnemyRobotRocketLauncher()
        {
            foreach (var enemy in enemiesLevelOne.Where(enemy => enemy.gameObject.name == "04EnemyRobotRocketRobot"))
            {
                currentEnemy = enemy;
            }
        }

        public void MakeEnemyRobotSniperRife()
        {
            foreach (var enemy in enemiesLevelOne.Where(enemy => enemy.gameObject.name == "05EnemyRobotSniperRobot"))
            {
                currentEnemy = enemy;
            }
        }

        #endregion
        
        #region Level Two
        
        public void MakeEnemyAlienWorm()
        {
            foreach (var enemy in enemiesLevelTwo.Where(enemy => enemy.gameObject.name == "01EnemyAlienWorm"))
            {
                currentEnemy = enemy;
            }
        }

        public void MakeEnemyAlienGrey()
        {
            foreach (var enemy in enemiesLevelTwo.Where(enemy => enemy.gameObject.name == "02EnemyAlienGrey"))
            {
                currentEnemy = enemy;
            }
        }

        public void MakeEnemyAlienBrute()
        {
            foreach (var enemy in enemiesLevelTwo.Where(enemy => enemy.gameObject.name == "03EnemyAlienBrute"))
            {
                currentEnemy = enemy;
            }
        }

        public void MakeEnemyAlienSlime()
        {
            foreach (var enemy in enemiesLevelTwo.Where(enemy => enemy.gameObject.name == "04EnemyAlienSlime"))
            {
                currentEnemy = enemy;
            }
        }

        public void MakeEnemyAlienBat()
        {
            foreach (var enemy in enemiesLevelTwo.Where(enemy => enemy.gameObject.name == "05EnemyAlienBat"))
            {
                currentEnemy = enemy;
            }
        }

        #endregion
    }
}