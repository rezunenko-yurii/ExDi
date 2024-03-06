using System;
using ExExtensions.Runtime;
using UnityEngine;

namespace ExDi.Runtime.Containers
{
    public class DiNodeContainer : DiContainer
    {
        DiContainer _parent;
    
        void  Awake()
        {
            SetDiParent();
            Debug.Log($"DiNodeContainer Awake / onObj={gameObject.name} / parent={_parent?.name}");
        }

        // --- Di Parent ---

        void SetDiParent() 
            => _parent = this.HasParent() ? GetContainerInParent() : GetProjectContainer();

        DiContainer GetContainerInParent() 
            => transform.parent.GetComponentInParent<DiNodeContainer>();

        DiContainer GetProjectContainer() =>
            GameObject.FindWithTag("ProjectDiContainer").GetComponent<DiContainer>();
    
        // --- Get ---

        public override T Get<T>(string id) where T : class 
            => Contains(id) ? base.Get<T>(id) : _parent?.Get<T>(id);
    
        public override T Get<T>(Type type) where T : class 
            => Contains(type) ? base.Get<T>(type) : _parent?.Get<T>(type);
    }
}