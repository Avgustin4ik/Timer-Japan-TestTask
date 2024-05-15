namespace Code.Core.Abstract
{
    using System;
    using UnityEngine;
    using Views;

    public class UiView<TModel> : MonoBehaviour where TModel : IModel
    {
        public TModel Model { get; private set; }

        protected virtual void Initialize(TModel model)
        {
            Model = model;
        }
        
        public virtual void Dispose()
        {
            
        }
        
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }
        
        public virtual void Hide()
        {
            gameObject.SetActive(false);
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