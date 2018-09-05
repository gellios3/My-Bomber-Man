using strange.extensions.command.impl;
using Services;
using Signals;
using UnityEngine;

namespace Commands
{
    public class OnHitPlayerCommand : Command
    {
        /// <summary>
        /// Player starts service
        /// </summary>
        [Inject]
        public PlayerStartsService PlayerStartsService { get; set; }

        /// <summary>
        /// Game over signal
        /// </summary>
        [Inject]
        public GameOverSignal GameOverSignal { get; set; }

        /// <summary>
        /// Execute command
        /// </summary>
        public override void Execute()
        {
            if (PlayerStartsService.Health > 0)
            {
                PlayerStartsService.Health--;
            }
            // Check if is game over
            if (PlayerStartsService.Health > 0)
                return;
            PlayerStartsService.HasGameOver = true;
            GameOverSignal.Dispatch();
        }
    }
}