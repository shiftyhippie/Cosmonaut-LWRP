using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Player
{
    public class PlayerStateManager : MonoBehaviour
    {
        [Header("Components / Integral stats")]
        public bool playerCanChangeLevel = true;

        public float vertical;
        public float horizontal;
        
        public Rigidbody rigidBody;
        public TextMeshProUGUI lifeText;
        public TextMeshProUGUI goldText;
        public TextMeshProUGUI xpText;

        [Header("Character Stats")]
        public float maxLife;
        public float curLife;
        public float gold;
        public float xp;
        public float speed;
    
        [Header("Weapon Stats")]
        public float fireRate = 1.0f;
        public float nextShot = 0.1f;
        public float bulletSpeed = 30.0f;
        
        [Header("Items")]
        public List<int> upgrades;

        public void PlayerUpdate()
        {
            rigidBody.velocity = new Vector3(horizontal * speed, 0, vertical * speed);
        }

        public void UpdatePlayerHealth()
        {
            lifeText.text = $"{curLife} / {maxLife}";
        }

        public void UpdatePlayerGold()
        {
            goldText.text = $"{gold}";
        }
    
        public void UpdatePlayerXp()
        {
            xpText.text = $"{xp}";
        }
    }
}