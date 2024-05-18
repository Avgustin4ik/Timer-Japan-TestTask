namespace Code.Core.Clock
{
    using Abstract;
    using Models;
    using Panel.View;
    using UnityEngine;
    using Zenject;

    public class ClockScreenView : ScreenView
    {
        [Inject]
        protected override void Initialize(ScreenModel model)
        {
            base.Initialize(model);
        }
    }
}