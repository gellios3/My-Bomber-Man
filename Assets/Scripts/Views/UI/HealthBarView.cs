using strange.extensions.mediation.impl;
using Services;
using UnityEngine;

namespace Views.UI
{
    public class HealthBarView : EventView
    {
        /// <summary>
        /// Health prefab
        /// </summary>
        [SerializeField] private GameObject _healthPrefab;

        /// <summary>
        /// Player starts service
        /// </summary>
        [Inject]
        public PlayerStartsService PlayerStartsService { get; set; }

        private int _currentHealth;

        protected override void Start()
        {
            _currentHealth = PlayerStartsService.Health;

            ShowHealth();
        }

        private void Update()
        {
            if (PlayerStartsService.Health >= _currentHealth)
                return;
            _currentHealth = PlayerStartsService.Health;
            Destroy(transform.GetChild(transform.childCount - 1).gameObject);
        }

        /// <summary>
        /// Show health
        /// </summary>
        private void ShowHealth()
        {
            for (var i = 0; i < _currentHealth; i++)
            {
                Instantiate(_healthPrefab, transform.position, Quaternion.identity, transform);
            }
        }
    }
}