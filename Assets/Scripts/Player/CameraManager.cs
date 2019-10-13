using UnityEngine;

namespace Player
{
    public class CameraManager : MonoBehaviour
    {
        [Header("Components")]
        public Transform playerTransform;
        public float minCameraZ;
        public float maxCameraZ;

        private float tempPlayerZ;
    
        public void CameraUpdate()
        {
            tempPlayerZ = playerTransform.position.z;
        
            if (tempPlayerZ <= minCameraZ)
            {
                tempPlayerZ = minCameraZ;
            }
            else if (tempPlayerZ >= maxCameraZ - 9)
            {
                tempPlayerZ = maxCameraZ;
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