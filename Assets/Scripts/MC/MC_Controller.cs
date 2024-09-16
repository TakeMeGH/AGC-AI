using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace PACMAN
{
    public class MC_Controller : MonoBehaviour
    {
        public UnityAction OnPowerUpStart;
        public UnityAction OnPowerUpEnd;
        [SerializeField] float _speed;
        [SerializeField] int _health;
        [SerializeField] SC_SO_InputReader _inputReader;
        [SerializeField] Camera _camera;
        [SerializeField] float _powerUpDuration;
        [SerializeField] Transform _respawnPoint;
        [SerializeField] TMP_Text _healthText;
        float _horizontal;
        float _vertical;
        Rigidbody _rigidBody;
        Coroutine _powerUpCourutine;
        bool _isPowerUpActive = false;


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
            UpdateUI();
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

        public void PickPowerUp()
        {
            if (_powerUpCourutine != null)
            {
                StopCoroutine(_powerUpCourutine);
            }

            _powerUpCourutine = StartCoroutine(StartPowerUp());

        }

        IEnumerator StartPowerUp()
        {
            OnPowerUpStart?.Invoke();
            _isPowerUpActive = true;
            yield return new WaitForSeconds(_powerUpDuration);
            _isPowerUpActive = false;
            OnPowerUpEnd?.Invoke();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (_isPowerUpActive)
            {
                if (other.gameObject.CompareTag("Enemy"))
                {
                    other.gameObject.GetComponent<SC_Enemy>().Dead();
                }
            }
        }

        public void Dead()
        {
            _health -= 1;
            if (_health > 0)
            {
                transform.position = _respawnPoint.position;
            }
            else
            {
                _health = 0;
                SceneManager.LoadScene("LoseMenu");
            }
            UpdateUI();

        }

        public void UpdateUI()
        {
            _healthText.text = "Health: " + _health;
        }
    }
}
