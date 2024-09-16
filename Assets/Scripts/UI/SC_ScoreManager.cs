using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PACMAN
{
    public class SC_ScoreManager : MonoBehaviour
    {
        [SerializeField] TMP_Text _scoreText;
        int _score;
        int _maxScore;

        private void Awake()
        {
            _score = 0;
            _maxScore = 0;
        }

        private void Start()
        {
            UpdateUI();
        }
        public void UpdateUI()
        {
            _scoreText.text = "Score: " + _score + " / " + _maxScore;
        }

        public void SetMaxScore(int value)
        {
            _maxScore = value;
            UpdateUI();
        }

        public void AddScore(int value)
        {
            _score += value;
            UpdateUI();
        }
    }
}
