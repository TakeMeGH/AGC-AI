using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PACMAN
{
    public class SC_RetreatState : SC_BaseState
    {
        public void EnterState(SC_Enemy enemy)
        {
            enemy.Animator.SetTrigger("Retreating");
        }

        public void ExitState(SC_Enemy enemy)
        {
        }

        public void UpdateState(SC_Enemy enemy)
        {
            if (enemy.Player != null)
            {
                enemy.NavMeshAgent.destination = enemy.transform.position - enemy.Player.transform.position;
            }
        }
    }
}
