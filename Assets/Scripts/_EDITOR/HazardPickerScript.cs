using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _EDITOR
{
    public class HazardPickerScript : MonoBehaviour
    {
        public List<GameObject> hazardsLevelOne = new List<GameObject>();
        public List<GameObject> hazardsLevelTwo = new List<GameObject>();

        public GameObject currentHazard;
        
        [Range(0, 1)] public int level;

        #region Level One
        
        public void MakeHazardSpaceshipSpikes()
        {
            foreach (var hazard in hazardsLevelOne.Where(hazard => hazard.gameObject.name == "01HazardSpaceshipSpikes"))
            {
                currentHazard = hazard;
            }
        }

        public void MakeHazardSpaceshipSawBlade()
        {
            foreach (var hazard in hazardsLevelOne.Where(hazard => hazard.gameObject.name == "02HazardSpaceshipSawBlade"))
            {
                currentHazard = hazard;
            }
        }

        public void MakeHazardSpaceshipAcidPool()
        {
            foreach (var hazard in hazardsLevelOne.Where(hazard => hazard.gameObject.name == "03HazardSpaceshipAcidPool"))
            {
                currentHazard = hazard;
            }
        }

        public void MakeHazardSpaceshipFire()
        {
            foreach (var hazard in hazardsLevelOne.Where(hazard => hazard.gameObject.name == "04HazardSpaceshipFire"))
            {
                currentHazard = hazard;
            }
        }

        #endregion
        
        #region Level Two
        
        public void MakeHazardAlpheriaSpikes()
        {
            foreach (var hazard in hazardsLevelTwo.Where(hazard => hazard.gameObject.name == "01HazardAlpheriaSpikes"))
            {
                currentHazard = hazard;
            }
        }

        public void MakeHazardAlpheriaSawBlade()
        {
            foreach (var hazard in hazardsLevelTwo.Where(hazard => hazard.gameObject.name == "02HazardAlpheriaSawBlade"))
            {
                currentHazard = hazard;
            }
        }

        public void MakeHazardAlpheriaAcidPool()
        {
            foreach (var hazard in hazardsLevelTwo.Where(hazard => hazard.gameObject.name == "03HazardAlpheriaAcidPool"))
            {
                currentHazard = hazard;
            }
        }

        public void MakeHazardAlpheriaGasCloud()
        {
            foreach (var hazard in hazardsLevelTwo.Where(hazard => hazard.gameObject.name == "04HazardAlpheriaGasCloud"))
            {
                currentHazard = hazard;
            }
        }

        #endregion
    }
}