namespace Code.Core.Abstract
{
    using System;
    using UnityEngine;
    using Views;
    using Zenject;

    public class UiView<TModel> : MonoBehaviour where TModel : IModel
    {
        protected CanvasGroup canvasGroup;
        public TModel Model { get; private set; }
        [Inject]
        protected virtual void Initialize(TModel model)
        {
            Model = model;
            if (gameObject.TryGetComponent(typeof(CanvasGroup), out var canvas))
            {
                canvasGroup = (CanvasGroup)canvas;
            }
            else
            {
                canvasGroup = gameObject.AddComponent<CanvasGroup>();
            }
        }
        
        public virtual void Dispose()
        {
            
        }
        
        
        public virtual void Display(bool value)
        {
            canvasGroup.alpha = value ? 1 : 0;
            canvasGroup.blocksRaycasts = value;
            canvasGroup.interactable = value;
        }
        
        public virtual void Destroy()
        {
            Destroy(gameObject);
        }
        
        public virtual void SetParent(Transform parent)
        {
            transform.SetParent(parent);
        }
        
        
    }
}