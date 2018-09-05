using Services;
using Signals;
using UnityEngine;
using Views.MainGame;

namespace Mediators.MainGame
{
    public class EnemyMediator : TargetMediator<EnemyView>
    {
        /// <summary>
        /// On hit enemy signal
        /// </summary>
        [Inject]
        public OnHitEnemySignal OnHitEnemySignal { get; set; }

        /// <summary>
        /// On check explode signal
        /// </summary>
        [Inject]
        public CheckHitExplodeSignal CheckHitExplodeSignal { get; set; }

        /// <summary>
        /// Player starts service
        /// </summary>
        [Inject]
        public PlayerStartsService PlayerStartsService { get; set; }

        /// <summary>
        /// Tilemap service
        /// </summary>
        [Inject]
        public TilemapService TilemapService { get; set; }

        /// <summary>
        /// On register mediator
        /// </summary>
        public override void OnRegister()
        {
           
            CheckHitExplodeSignal.AddListener(pos =>
            {
                var cellPos = TilemapService.Tilemap.WorldToCell(transform.position);
                if (cellPos != pos)
                    return;
                OnHitEnemySignal.Dispatch(View, PlayerStartsService.Damage);
            });
        }
    }
}