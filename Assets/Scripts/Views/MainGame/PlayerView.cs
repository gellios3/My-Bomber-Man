using System;
using strange.extensions.mediation.impl;
using Services;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Views.MainGame
{
    public class PlayerView : EventView
    {
        [Inject] public PlayerStartsService PlayerStartsService { get; set; }

     

        /// <summary>
        /// Game play tilemap
        /// </summary>
        [SerializeField] private Tilemap _tilemap;
        
        public Tilemap Tilemap => _tilemap;

        /// <summary>
        /// Bomb prefab
        /// </summary>
        [SerializeField] private GameObject _bombPrefab;
        
        public GameObject BombPrefab => _bombPrefab;

        /// <summary>
        /// Player health
        /// </summary>
        [SerializeField] private int _health;

        /// <summary>
        /// Player speed
        /// </summary>
        [SerializeField] private float _speed;
        
        public float Speed => _speed;

        /// <summary>
        /// On move player
        /// </summary>
        public event Action OnMove; 
        
        /// <summary>
        /// On move player
        /// </summary>
        public event Action OnSpawnBomb;

        protected override void Start()
        {
            PlayerStartsService.Health = _health;
        }

        private void Update()
        {
            OnMove?.Invoke();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnSpawnBomb?.Invoke();
            }
        }
 
    }
}