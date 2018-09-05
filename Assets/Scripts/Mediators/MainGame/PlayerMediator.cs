using Services;
using Signals;
using UnityEngine;
using Views.MainGame;

namespace Mediators.MainGame
{
    public class PlayerMediator : TargetMediator<PlayerView>
    {
        /// <summary>
        /// On explode signal
        /// </summary>
        [Inject]
        public CheckHitExplodePlayerSignal CheckHitExplodePlayerSignal { get; set; }

        /// <summary>
        /// On hit player signal
        /// </summary>
        [Inject]
        public OnHitPlayerSignal OnHitPlayerSignal { get; set; }

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
            PlayerStartsService.Health = View.Health;

            View.OnMove += MovePlayer;

            View.OnSpawnBomb += SpawnBomb;

            CheckHitExplodePlayerSignal.AddListener(pos =>
            {
                var cellPos = TilemapService.Tilemap.WorldToCell(transform.position);
                if (cellPos != pos)
                    return;
                OnHitPlayerSignal.Dispatch();
            });
        }

        /// <summary>
        /// Spawn bomb
        /// </summary>
        private void SpawnBomb()
        {
            var cell = TilemapService.Tilemap.WorldToCell(transform.position);
            var cellCenterPos = TilemapService.Tilemap.GetCellCenterWorld(cell);

            Instantiate(View.BombPrefab, cellCenterPos, Quaternion.identity, View.transform.parent);
        }

        /// <summary>
        /// Move player
        /// </summary>
        private void MovePlayer()
        {
            var moveHorizontal = Input.GetAxis("Horizontal");
            var moveVertical = Input.GetAxis("Vertical");

            var currentVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;

            var newVelocityX = 0f;
            if (moveHorizontal < 0 && currentVelocity.x <= 0)
            {
                newVelocityX = -View.Speed;
            }
            else if (moveHorizontal > 0 && currentVelocity.x >= 0)
            {
                newVelocityX = View.Speed;
            }

            var newVelocityY = 0f;
            if (moveVertical < 0 && currentVelocity.y <= 0)
            {
                newVelocityY = -View.Speed;
            }
            else if (moveVertical > 0 && currentVelocity.y >= 0)
            {
                newVelocityY = View.Speed;
            }

            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(newVelocityX, newVelocityY);
        }
    }
}