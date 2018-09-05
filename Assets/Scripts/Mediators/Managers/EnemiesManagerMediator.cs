using Signals;
using Views.Managers;

namespace Mediators.Managers
{
    public class EnemiesManagerMediator : TargetMediator<EnemiesManagerView>
    {
        /// <summary>
        /// On hit enemy signal
        /// </summary>
        [Inject]
        public OnEnemyDeathSignal OnEnemyDeathSignal { get; set; }

        /// <summary>
        /// On register mediator
        /// </summary>
        public override void OnRegister()
        {
            OnEnemyDeathSignal.AddListener(view => { view.gameObject.SetActive(false); });
        }
    }
}