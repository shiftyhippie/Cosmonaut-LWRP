using Player;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.WSA.Input;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        public int hpMax;
        public int hpCurrent;
        public int xpDropped;

        public bool isRanged;
        public bool isFlying;

        public NavMeshAgent navMeshAgent;
        public Transform player; 

        public enum State
        {
            IDLE,
            ATTACK,
            MOVE
        }
        
        public void TakenDamage(int damage)
        {
            Debug.Log($"Has Taken {damage}dmg!");

            if (damage >= hpCurrent)
            {
                var difference = Mathf.Abs(hpCurrent - damage);
                hpCurrent -= difference;
                
                Death(xpDropped);
            }
            
            hpCurrent -= damage;
        }

        public virtual void Death(int xp)
        {
            
        }

        public virtual void EnemyAwake()
        {
            hpCurrent = hpMax;
        }
        
        public virtual void EnemyUpdate()
        {
            
        }

        public virtual void EnemyStateMachine()
        {
            
        }

        public virtual void IdleState()
        {
        }

        public virtual void MoveState()
        {
        }
        
        public virtual void AttackState()
        {
        }

        protected void MoveToPlayer()
        {
            navMeshAgent.isStopped = false;

            navMeshAgent.destination = player.position;
        }

        protected void StopToAttack()
        {
            navMeshAgent.isStopped = true;
        }
    }
}