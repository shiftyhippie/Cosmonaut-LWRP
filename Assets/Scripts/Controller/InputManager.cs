using System;
using Player;
using UnityEngine;

namespace Controller
{
    public class InputManager : MonoBehaviour
    {
        [Header("Components")]
        public PlayerStateManager playerStateManager;
        [SerializeField] private GameObject bullet;
        [SerializeField] private Vector3 enemyPosition;

        [Header("Inputs")]
        public VariableJoystick variableJoystick;
    
        public void PlayerUpdate()
        {
            GetJoystickInput();

            if (AnyJoystickInput())
            {
                return;
            }

            GetKeyboardInput();
        }

        private void GetKeyboardInput()
        {
            var v = Input.GetAxis($"Vertical");
            var h = Input.GetAxis($"Horizontal");

            playerStateManager.vertical = v;
            playerStateManager.horizontal = h;
        }

        private void GetJoystickInput()
        {
            var v = variableJoystick.Vertical;
            var h = variableJoystick.Horizontal;

            playerStateManager.vertical = v;
            playerStateManager.horizontal = h;
        }
    
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag($"Enemy"))
            {
                var enemies = GameObject.FindGameObjectsWithTag("Enemy");
    
                var distance = Mathf.Infinity;
                var position = transform.position;

                foreach(var enemy in enemies)
                {
                    var difference = enemy.transform.position - position;

                    var currentDistance = difference.sqrMagnitude;

                    if(currentDistance < distance)
                    {
                        var closest = enemy;
                        distance = currentDistance;
                        enemyPosition = closest.transform.position;
                    }
                }

                if (!AnyKeyboardInput() && !AnyJoystickInput())
                {
                    ShootNearbyEnemy();
                }
            }
        }
    
        private void ShootNearbyEnemy()
        {
            if (Time.time > playerStateManager.nextShot)
            {
                playerStateManager.nextShot = Time.time + playerStateManager.fireRate;
                var projectile = Instantiate(bullet);
                var position = transform.position;
        
                projectile.transform.position = position;
                var rb = projectile.GetComponent<Rigidbody>();
                
                rb.velocity = playerStateManager.bulletSpeed * (enemyPosition - position).normalized;
            }
        }

        private static bool AnyKeyboardInput()
        {
            return Math.Abs(Input.GetAxisRaw($"Vertical")) > 0 || Math.Abs(Input.GetAxisRaw($"Horizontal")) > 0;
        }
    
        private bool AnyJoystickInput()
        {
            return Math.Abs(variableJoystick.Vertical) > 0.1f || Math.Abs(variableJoystick.Horizontal) > 0.1f;
        }
    }
}
