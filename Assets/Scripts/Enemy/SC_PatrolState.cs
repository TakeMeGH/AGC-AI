using UnityEngine;

namespace PACMAN
{
    public class SC_PatrolState : SC_BaseState
    {
        bool _isMoving;
        Vector3 _destination;
        public void EnterState(SC_Enemy enemy)
        {
            _isMoving = false;
        }

        public void ExitState(SC_Enemy enemy)
        {
        }

        public void UpdateState(SC_Enemy enemy)
        {
            if (Vector3.Distance(enemy.transform.position, enemy.Player.transform.position) < enemy.ChaseDistance)
            {
                enemy.SwitchState(enemy.ChaseState);
            }

            if (!_isMoving)
            {
                _isMoving = true;
                int index = Random.Range(0, enemy.Waypoints.Count);
                _destination = enemy.Waypoints[index].transform.position;
                enemy.NavMeshAgent.destination = _destination;
            }
            else
            {
                if (Vector3.Distance(_destination, enemy.transform.position) <= 0.1)
                {
                    _isMoving = false;
                }
            }
        }
    }
}
