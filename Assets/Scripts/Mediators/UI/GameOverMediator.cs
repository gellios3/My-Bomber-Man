using Signals;
using Views.UI;

namespace Mediators.UI
{
    public class GameOverMediator : TargetMediator<GameOverView>
    {
        /// <summary>
        /// Game over signal
        /// </summary>
        [Inject]
        public GameOverSignal GameOverSignal { get; set; }

        /// <summary>
        /// On register mediator
        /// </summary>
        public override void OnRegister()
        {
            GameOverSignal.AddListener(() => { View.ShowGameOver(); });
        }
    }
}