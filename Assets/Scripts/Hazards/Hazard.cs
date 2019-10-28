using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hazards
{
    public class Hazard : MonoBehaviour
    {
        public float tickStart;
        public float tickRepeat = 1f;

        public GameObject player;
        
        public List<Enemy.Enemy> enemiesCurrentlyAffected = new List<Enemy.Enemy>();
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                player = other.gameObject;
            }

            if (other.gameObject.CompareTag("Enemy"))
            {
                enemiesCurrentlyAffected.Add(other.gameObject.GetComponent<Enemy.Enemy>());
            }
            
            InvokeRepeating(nameof(AffectPlayer), tickStart, tickRepeat);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                player = null;
            }

            if (other.gameObject.CompareTag("Enemy"))
            {
                enemiesCurrentlyAffected.Remove(other.gameObject.GetComponent<Enemy.Enemy>());
            }
            
            CancelInvoke(nameof(AffectPlayer));
        }

        protected virtual void AffectPlayer()
        {
            
        }
    }
}