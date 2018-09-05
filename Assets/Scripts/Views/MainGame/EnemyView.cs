using strange.extensions.mediation.impl;
using UnityEngine;

namespace Views.MainGame
{
    public class EnemyView : EventView
    {
        
        /// <summary>
        /// Player health
        /// </summary>
        [SerializeField] private int _health;

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
    }
}