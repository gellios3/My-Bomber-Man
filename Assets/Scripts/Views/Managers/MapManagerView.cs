using System;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Views.Managers
{
    public class MapManagerView : EventView
    {
        /// <summary>
        /// Game play tilemap
        /// </summary>
        [SerializeField] private Tilemap _tilemap;
        
        public Tilemap Tilemap => _tilemap;

        /// <summary>
        /// Wall tile
        /// </summary>
        [SerializeField] private Tile _wallTile;
        
        public Tile WallTile => _wallTile;

        /// <summary>
        /// Destruct tile
        /// </summary>
        [SerializeField] private Tile _destructibleTile;
        
        public Tile DestructibleTile => _destructibleTile;

        /// <summary>
        /// Explosion prefab
        /// </summary>
        [SerializeField] private GameObject _explosionPrefab;
        
        public GameObject ExplosionPrefab => _explosionPrefab;
      
    }
}