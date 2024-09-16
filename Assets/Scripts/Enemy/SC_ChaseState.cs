using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PACMAN
{
    public class SC_ChaseState : SC_BaseState
    {
        public void EnterState(SC_Enemy enemy)
        {
            enemy.Animator.SetTrigger("Chasing");
        }

        public void ExitState(SC_Enemy enemy)
        {
        }

        public void UpdateState(SC_Enemy enemy)
        {
            if (enemy.Player != null)
            {
                enemy.NavMeshAgent.destination = enemy.Player.transform.position;

                if (Vector3.Distance(enemy.transform.position, enemy.Player.transform.position) > enemy.ChaseDistance)
                {
                    enemy.SwitchState(enemy.PatrolState);
                }
            }
        }
    }
}
