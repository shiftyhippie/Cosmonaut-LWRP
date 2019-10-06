using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyAiController : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private NavMeshAgent myNavMesh;
        
        public float checkRate = 0.01f;
        public float nextCheck;

        public void EnemyUpdate()
        {
            if (Time.time > nextCheck)
            {
                nextCheck = Time.time + checkRate;
                Follow();
            }
        }

        private void Follow()
        {
            myNavMesh.transform.LookAt(playerTransform);
            myNavMesh.destination = playerTransform.position;
        }
    }
}
