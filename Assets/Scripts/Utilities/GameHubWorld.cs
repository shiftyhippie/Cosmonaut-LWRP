using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public class GameHubWorld : MonoBehaviour
    {
        [SerializeField] private List<GameObject> listOfLevels = new List<GameObject>();

        [SerializeField] private float approxRotation;

        [SerializeField] private int currentLevel;
        
        private void Awake()
        {
            GetListOfChildren();
            
            OrganisePlanetPositions();
        }

        private void GetListOfChildren()
        {
            foreach (Transform child in transform)
            {
                if (child.CompareTag("Player"))
                {
                    listOfLevels.Add(child.gameObject);
                }
            }
        }
        
        private void OrganisePlanetPositions()
        {
            approxRotation = 360.0f / listOfLevels.Count;

            var count = 0;
            
            foreach (var level in listOfLevels)
            {
                var currentRotation = new Vector3(0, approxRotation * count, 0);
                
                level.transform.eulerAngles = currentRotation;
                
                count++;
            }
        }

        public void NextLevel()
        {
            currentLevel++;
            
            var currentRotation = new Vector3(0, approxRotation * currentLevel, 0);
            transform.eulerAngles = currentRotation;
        }

        public void LastLevel()
        {
            currentLevel--;
            
            var currentRotation = new Vector3(0, approxRotation * currentLevel, 0);
            transform.eulerAngles = currentRotation;
        }
    }
}
