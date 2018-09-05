using strange.extensions.command.impl;
using Services;
using Signals;
using UnityEngine;
using Views.MainGame;

namespace Commands
{
    public class OnHitEnemyCommand : Command
    {
        /// <summary>
        /// Hit damage value
        /// </summary>
        [Inject]
        public int HitDamage { get; set; }

        /// <summary>
        /// Enemy view
        /// </summary>
        [Inject]
        public EnemyView EnemyView { get; set; }

        /// <summary>
        /// On enemy death signal
        /// </summary>
        [Inject]
        public OnEnemyDeathSignal OnEnemyDeathSignal { get; set; }

        /// <summary>
        /// Execute command
        /// </summary>
        public override void Execute()
        {
            EnemyView.Health -= HitDamage;

            if (EnemyView.Health >= 0)
                return;
            OnEnemyDeathSignal.Dispatch(EnemyView);
        }
    }
}