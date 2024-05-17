namespace Code.Core.Views
{
    using Abstract;
    using UnityEngine;
    using UnityEngine.UI;

    public class TimerScreenView : UiView<TimerScreenModel>
    {
        [SerializeField] private Button setTimerButton;
        [SerializeField] private SetterTimerView setter;
        protected override void Initialize(TimerScreenModel model)
        {
            setTimerButton.onClick.AddListener(() => setter.gameObject.SetActive(true));
            
            base.Initialize(model);
        }
    }

    public class TimerScreenModel : IModel
    {
        
    }
}