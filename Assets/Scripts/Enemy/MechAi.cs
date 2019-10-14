using Controller;
using Player;
using UnityEngine;

namespace Enemy
{
    public class MechAi : Enemy
    {
        public State currentState = State.IDLE;

        public override void EnemyAwake()
        {
            hpCurrent = hpMax;

            InvokeRepeating("EnemyStateMachine", startTime, thoughtRate);
        }

        public override void EnemyStateMachine()
        {
            switch (currentState)
            {
                case State.IDLE:
                    IdleState();
                    break;
                case State.MOVE:
                    MoveState();
                    break;
                case State.ATTACK:
                    AttackState();
                    break;
            }
        }

        public override void Death(int xp)
        {
            Debug.Log($"Dropped {xp}xp/gold!");
            player.gameObject.GetComponent<PlayerStateManager>().ChangeLevel();

            var gm = GameObject.Find("Game Manager").GetComponent<CompleteManager>();
            gm.enemies.Remove(GetComponent<MechAi>());
            player.gameObject.GetComponent<InputManager>().UpdateEnemyList();

            gm.numOfEnemies--;
            if (gm.numOfEnemies <= 0)
            {
                player.gameObject.GetComponent<PlayerStateManager>().ChangeLevel();
            }
                
            Destroy(transform.parent.gameObject);
        }

        public override void IdleState()
        { 
            player = GameObject.Find("Player").transform;
            
            currentState = State.MOVE;
        }

        public override void MoveState()
        {
            MoveToPlayer();
            
            currentState = State.ATTACK;
        }
        
        public override void AttackState()
        {
            StopToAttack();
            
            currentState = State.MOVE;
        }
    }
}
