using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;

        public bool gameStarted { private set; get; }

        [SerializeField] private Button buttonContinued;
        [SerializeField] private Button buttonRestart;
        [SerializeField] private Button buttonStart;
        

        /*
         * 0 - WindowStart
         * 1 - WindowGame
         * 2 - WindowWin
         * 3 - WindowLose
         */
        [SerializeField] private List<GameObject> windowList;

        private void Awake()
        {
            Instance = this;
            buttonStart.onClick.AddListener(StartGame);
            buttonRestart.onClick.AddListener(RestartGame);
            buttonContinued.onClick.AddListener(NextLevel);
            Time.timeScale = 0;
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void NextLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void WinGame()
        {
            gameStarted = false;
            HideAllWindow();
            windowList[2].SetActive(true);
            Time.timeScale = 0;
        }

        public void LoseGame()
        {
            gameStarted = false;
            HideAllWindow();
            windowList[3].SetActive(true);
            Time.timeScale = 0;
        }

        public void StartGame()
        {
            gameStarted = true;
            HideAllWindow();
            windowList[1].SetActive(true);
            Time.timeScale = 1;
        }

        private void HideAllWindow()
        {
            foreach (GameObject window in windowList)
            {
                window.SetActive(false);
            }
        }


    }
}
