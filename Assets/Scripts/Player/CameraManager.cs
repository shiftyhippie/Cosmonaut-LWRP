using UnityEngine;

namespace Player
{
    public class CameraManager : MonoBehaviour
    {
        [Header("Components")]
        public Transform playerTransform;

        private float tempPlayerZ;
    
        public void CameraUpdate()
        {
            tempPlayerZ = playerTransform.position.z;
        
            if (tempPlayerZ <= -6)
            {
                tempPlayerZ = -6;
            }
            else if (tempPlayerZ >= 7)
            {
                tempPlayerZ = 7;
            }
            else
            {
                var tempTransform = transform;
                var tempPosition = tempTransform.position;
            
                tempPosition = new Vector3(tempPosition.x, tempPosition.y, tempPlayerZ);
                tempTransform.position = tempPosition;            
            }
        }
    }
}