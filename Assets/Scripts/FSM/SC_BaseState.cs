using UnityEngine;

namespace PACMAN
{
    public interface SC_BaseState
    {
        public void EnterState(SC_Enemy enemy);
        public void UpdateState(SC_Enemy enemy);
        public void ExitState(SC_Enemy enemy);
    }
}
