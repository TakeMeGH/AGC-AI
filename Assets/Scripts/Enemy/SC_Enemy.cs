using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace PACMAN
{
    public class SC_Enemy : MonoBehaviour
    {
        public List<Transform> Waypoints = new List<Transform>();
        public float ChaseDistance;
        public MC_Controller Player;
        SC_BaseState _currentState;
        [HideInInspector] public SC_PatrolState PatrolState = new SC_PatrolState();
        [HideInInspector] public SC_ChaseState ChaseState = new SC_ChaseState();
        [HideInInspector] public SC_RetreatState RetreatState = new SC_RetreatState();
        [HideInInspector] public NavMeshAgent NavMeshAgent;

        private void Start()
        {
            _currentState = PatrolState;
            _currentState.EnterState(this);
            NavMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (_currentState != null)
            {
                _currentState.UpdateState(this);
            }
        }


        public void SwitchState(SC_BaseState NextState)
        {
            _currentState.ExitState(this);
            _currentState = NextState;
            _currentState.EnterState(this);
        }

    }
}
