using UnityEngine;

namespace Utilities
{
    public class BulletDeath : MonoBehaviour
    {
        private const float Lifetime = 2;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Collider>().CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<Enemy.Enemy>().TakenDamage(50);

                Destroy(gameObject);
            }
            
            Destroy(gameObject, Lifetime);
        }
    }
}
