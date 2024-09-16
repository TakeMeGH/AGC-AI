using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PACMAN
{
    public class SC_MainMenuManager : MonoBehaviour
    {
        public void Play()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}
