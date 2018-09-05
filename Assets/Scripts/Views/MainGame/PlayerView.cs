using System;
using strange.extensions.mediation.impl;
using Services;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Views.MainGame
{
    public class PlayerView : EventView
    {
        /// <summary>
        /// Bomb prefab
        /// </summary>
        [SerializeField] private GameObject _bombPrefab;

        public GameObject BombPrefab => _bombPrefab;

        /// <summary>
        /// Player health
        /// </summary>
        [SerializeField] private int _health;

        public int Health => _health;

        /// <summary>
        /// Player  hit damage
        /// </summary>
        [SerializeField] private int _damage;

        public int Damage => _damage;

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