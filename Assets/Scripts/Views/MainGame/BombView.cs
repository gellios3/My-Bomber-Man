using System;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Views.MainGame
{
    public class BombView : EventView
    {
        /// <summary>
        /// Bomb count down
        /// </summary>
        [SerializeField] private float _countdown = 2f;

        /// <summary>
        /// Bomb explosion radius in tile 
        /// </summary>
        [SerializeField] private int _radius = 2;

        public int Radius => _radius;

        /// <summary>
        /// On move player
        /// </summary>
        public event Action OnExplode;

        private void Update()
        {
            _countdown -= Time.deltaTime;

            if (!(_countdown <= 0f))
                return;
            OnExplode?.Invoke();
            Destroy(gameObject);
        }
    }
}