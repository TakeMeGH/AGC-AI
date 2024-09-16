using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PACMAN
{
    public class SC_GameOverManager : MonoBehaviour
    {

        void Start()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        public void Retry()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void MainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
