namespace Code.Core.Clock
{
    using Abstract;
    using Models;
    using UnityEngine;
    using Zenject;

    public class ClockScreenView : UiView<ClockScreenModel>
    {
        [SerializeField] private ClockModel clock;
        [Inject]
        protected override void Initialize(ClockScreenModel model)
        {
            base.Initialize(model);
        }
    }
}