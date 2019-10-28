using Player;
using UnityEngine;

namespace Hazards
{
    public sealed class HazardSpikes : Hazard
    {
        protected override void AffectPlayer()
        {
            if (player != null)
            {
                Debug.Log("Player Damaged");
                player.GetComponent<PlayerStateManager>().curLife -= 10;

                if (player.GetComponent<PlayerStateManager>().curLife <= 0)
                {
                    Debug.Log("Game Over");
                }
            }

            if (enemiesCurrentlyAffected != null)
            {
                foreach (var enemy in enemiesCurrentlyAffected)
                {
                    Debug.Log("Enemy Damaged");
                }
            }
        }
    }
}