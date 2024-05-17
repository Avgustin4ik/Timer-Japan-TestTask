namespace Code.Core.Views
{
    using Abstract;
    using TMPro;
    using UniRx;
    using UnityEngine;
    
    public class LapTimeView : UiView<LapTimeModel>
    {
        public TextMeshProUGUI Index;
        public TextMeshProUGUI Global;
        public TextMeshProUGUI Difference;

        protected override void Initialize(LapTimeModel model)
        {
            model.Index.Subscribe(x => Index.text = "# "+x).AddTo(this);
            model.Global.Subscribe(x => Global.text = x.ToString(@"hh\:mm\:ss\,fff")).AddTo(this);
            model.Difference.Subscribe(x => Difference.text = x.ToString(@"hh\:mm\:ss\,fff")).AddTo(this);
            base.Initialize(model);
        }
    }
}