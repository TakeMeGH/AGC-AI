using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PACMAN
{
    public class MC_ : MonoBehaviour
    {
        [SerializeField] float _speed;
        [SerializeField] SC_SO_InputReader _inputReader;
        [SerializeField] Camera _camera;
        float _horizontal;
        float _vertical;
        private Rigidbody _rigidBody;


        private void OnEnable()
        {
            _inputReader.MovementEvent += UpdateMovementValue;
        }

        private void OnDisable()
        {
            _inputReader.MovementEvent -= UpdateMovementValue;
        }
        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
            HideAndLockCursor();
        }

        void HideAndLockCursor()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");

            Vector3 horizontalDirection = _horizontal * _camera.transform.right;
            Vector3 verticalDirection = _vertical * _camera.transform.forward;
            horizontalDirection.y = 0;
            verticalDirection.y = 0;

            Vector3 movementDirection = horizontalDirection + verticalDirection;
            _rigidBody.velocity = movementDirection * _speed * Time.fixedDeltaTime;
        }

        void UpdateMovementValue(Vector2 value)
        {
            _horizontal = value.x;
            _vertical = value.y;
        }
    }
}
