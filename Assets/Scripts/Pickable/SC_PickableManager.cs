using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PACMAN
{
    public class SC_PickableManager : MonoBehaviour
    {
        [SerializeField] MC_Controller _player;
        [SerializeField] SC_ScoreManager _scoreManager;
        List<SC_Pickable> _pickableList = new List<SC_Pickable>();

        private void Start()
        {
            InitPickableList();
        }
        void InitPickableList()
        {
            SC_Pickable[] pickableObjects = FindObjectsOfType<SC_Pickable>();
            for (int i = 0; i < pickableObjects.Length; i++)
            {
                _pickableList.Add(pickableObjects[i]);
                pickableObjects[i].OnPicked += OnPickablePicked;
            }
            if (_scoreManager != null)
            {
                _scoreManager.SetMaxScore(_pickableList.Count);
            }
        }

        void OnPickablePicked(SC_Pickable pickable)
        {
            _pickableList.Remove(pickable);

            if (_scoreManager != null)
            {
                _scoreManager.AddScore(1);
            }

            if (pickable.PickableType == Enum_PickableType.PowerUp)
            {
                _player?.PickPowerUp();
            }
            if (_pickableList.Count <= 0)
            {
                SceneManager.LoadScene("WinMenu");
            }
        }
    }
}
