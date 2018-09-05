using UnityEngine;
using Views.MainGame;

namespace Mediators.MainGame
{
    public class PlayerMediator : TargetMediator<PlayerView>
    {
        /// <summary>
        /// On register mediator
        /// </summary>
        public override void OnRegister()
        {
            View.OnMove += MovePlayer;

            View.OnSpawnBomb += SpawnBomb;
        }

        /// <summary>
        /// Spawn bomb
        /// </summary>
        private void SpawnBomb()
        {
            var cell = View.Tilemap.WorldToCell(transform.position);
            var cellCenterPos = View.Tilemap.GetCellCenterWorld(cell);

            Instantiate(View.BombPrefab, cellCenterPos, Quaternion.identity);
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