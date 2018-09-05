using Signals;
using UnityEngine;
using Views.MainGame;

namespace Mediators.MainGame
{
    public class BombMediator : TargetMediator<BombView>
    {
        /// <summary>
        /// On explode signal
        /// </summary>
        [Inject]
        public OnExplodeSignal OnExplodeSignal { get; set; }

        /// <summary>
        /// On register mediator
        /// </summary>
        public override void OnRegister()
        {
            View.OnExplode += () =>
            {
                OnExplodeSignal.Dispatch(View.transform.position, View.Radius);
            };
        }
    }
}