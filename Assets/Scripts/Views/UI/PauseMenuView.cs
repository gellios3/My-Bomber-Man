using strange.extensions.mediation.impl;
using Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Views.UI
{
    public class PauseMenuView : EventView
    {
        /// <summary>
        /// Pause menu content
        /// </summary>
        [SerializeField] private GameObject _pauseMenuContent;

        /// <summary>
        /// Continue button
        /// </summary>
        [SerializeField] private Button _continueBtn;

        /// <summary>
        /// Retry button
        /// </summary>
        [SerializeField] private Button _retryBtn;

        /// <summary>
        /// Menu button
        /// </summary>
        [SerializeField] private Button _menuBtn;

        /// <summary>
        /// Player starts service
        /// </summary>
        [Inject]
        public PlayerStartsService PlayerStartsService { get; set; }

        protected override void Start()
        {
            _continueBtn.onClick.AddListener(HidePauseMenu);

            _retryBtn.onClick.AddListener(() =>
            {
                // return normal time
                Time.timeScale = 1;
                // reload scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            });

            _menuBtn.onClick.AddListener(() => { Debug.Log("Go to Menu!"); });
        }


        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.P) && !Input.GetKeyDown(KeyCode.Escape))
                return;
            if (!PlayerStartsService.HasPaused)
            {
                ShowPauseMenu();
            }
            else
            {
                HidePauseMenu();
            }
        }

        /// <summary>
        /// Hide pause menu
        /// </summary>
        private void HidePauseMenu()
        {
            PlayerStartsService.HasPaused = false;
            _pauseMenuContent.SetActive(false);
            // return normal time
            Time.timeScale = 1;
        }

        /// <summary>
        /// Show game over content
        /// </summary>
        private void ShowPauseMenu()
        {
            PlayerStartsService.HasPaused = true;
            _pauseMenuContent.SetActive(true);
            // Pause time
            Time.timeScale = 0;
        }
    }
}