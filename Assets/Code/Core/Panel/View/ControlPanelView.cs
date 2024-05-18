namespace Code.Core.Panel.View
{
    using System;
    using Abstract;
    using Clock;
    using UniRx;
    using UnityEngine;
    using UnityEngine.UI;
    using Views;
    using Zenject;

    [Serializable]
    public struct PairButtonScreen
    {
        public Button Button;
        public ScreenView Screen;
    }
    public class ControlPanelView : UiView<ControlPanelModel>
    {
        [SerializeField] private PairButtonScreen[] PairButtonScreens;
        [SerializeField] private ScreenView mainScreen;
        public void InitialState()
        {
            DisplayScreen(mainScreen);
        }
        protected override void Initialize(ControlPanelModel model)
        {
            foreach (var pairButtonScreen in PairButtonScreens)
            {
                pairButtonScreen.Button.OnClickAsObservable().Subscribe(x=>DisplayScreen(pairButtonScreen.Screen));
            }
            base.Initialize(model);
        }

        private void Awake()
        {
            InitialState();
        }

        private void DisplayScreen(ScreenView screen)
        {
            foreach (var pairButtonScreen in PairButtonScreens)
            {
                pairButtonScreen.Screen.Display(pairButtonScreen.Screen == screen);
            }
        }
    }
}