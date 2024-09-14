using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;

namespace PACMAN
{
    [CreateAssetMenu(fileName = "Input Reader", menuName = "Player Input")]
    public class SC_SO_InputReader : ScriptableObject, IA_MCInput.IGameplayActions
    {
        public UnityAction<Vector2> MovementEvent;
        public UnityAction InteractPerformed;

        IA_MCInput _input;
        private void OnEnable()
        {
            if (_input == null)
            {
                _input = new IA_MCInput();
                _input.Gameplay.SetCallbacks(this);
            }

            _input.Gameplay.Enable();
        }

        private void OnDisable()
        {
            if (_input != null) _input.Gameplay.Disable();
        }
        public void OnIntreract(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                InteractPerformed?.Invoke();
            }
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            MovementEvent?.Invoke(context.ReadValue<Vector2>());
        }
    }
}
