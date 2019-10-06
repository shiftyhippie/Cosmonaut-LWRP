using UnityEngine;

namespace Utilities
{
    public class BulletDeath : MonoBehaviour
    {
        [SerializeField] private float lifetime = 3;
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Collider>().CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }
        
            Destroy(gameObject, lifetime);
        }
    }
}
