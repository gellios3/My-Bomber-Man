using Services;
using Signals;
using UnityEngine;
using UnityEngine.Tilemaps;
using Views.Managers;

namespace Mediators.Managers
{
    public class MapManagerMediator : TargetMediator<MapManagerView>
    {
        /// <summary>
        /// Tilemap service
        /// </summary>
        [Inject]
        public TilemapService TilemapService { get; set; }
        
        /// <summary>
        /// On explode signal
        /// </summary>
        [Inject]
        public OnExplodeSignal OnExplodeSignal { get; set; }
        
        /// <summary>
        /// On explode signal
        /// </summary>
        [Inject]
        public CheckHitExplodePlayerSignal CheckHitExplodePlayerSignal { get; set; }

        /// <summary>
        /// On register mediator
        /// </summary>
        public override void OnRegister()
        {
            OnExplodeSignal.AddListener(Explode);

            TilemapService.Tilemap = View.Tilemap;
        }

        /// <summary>
        /// Explode bomb
        /// </summary>
        /// <param name="worldPos"></param>
        /// <param name="radius"></param>
        public void Explode(Vector2 worldPos, int radius)
        {
            var originCell = View.Tilemap.WorldToCell(worldPos);

            ExplodeCell(originCell);

            for (var i = 1; i < radius + 1; i++)
            {
                if (!ExplodeCell(originCell + new Vector3Int(i, 0, 0)))
                    break;
            }

            for (var i = 1; i < radius + 1; i++)
            {
                if (!ExplodeCell(originCell + new Vector3Int(0, i, 0)))
                    break;
            }

            for (var i = 1; i < radius + 1; i++)
            {
                if (!ExplodeCell(originCell + new Vector3Int(-i, 0, 0)))
                    break;
            }

            for (var i = 1; i < radius + 1; i++)
            {
                if (!ExplodeCell(originCell + new Vector3Int(0, -i, 0)))
                    break;
            }
        }

        /// <summary>
        /// Explode cell
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private bool ExplodeCell(Vector3Int cell)
        {
            var tile = View.Tilemap.GetTile<Tile>(cell);

            if (tile == View.WallTile)
            {
                return false;
            }

            if (tile == View.DestructibleTile)
            {
                View.Tilemap.SetTile(cell, null);
            }
            
            CheckHitExplodePlayerSignal.Dispatch(cell); 
            
            var pos = View.Tilemap.GetCellCenterWorld(cell);
    
            var explosionEffect = Instantiate(View.ExplosionPrefab, pos, Quaternion.identity);

            // Destroy Effect after 2 seconds 
            Destroy(explosionEffect, 2);

            return true;
        }
    }
}