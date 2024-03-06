using System;
using ExDi.Runtime.Containers;
using UnityEngine.EventSystems;

namespace ExDi.Runtime.Receivers
{
    public class ExUIBehaviour : UIBehaviour
    {
        //Fields
        DiNodeContainer _diContainer;
        DiNodeContainer DiContainer => _diContainer 
            ? _diContainer 
            : gameObject.GetComponentInParent<DiNodeContainer>();
    
        // Methods
        /*protected override void Awake() 
        => _dependencyContainer = ((Component)this).GetComponentInParent<DiNodeContainer>();*/

        public new T GetComponentInParent<T>() where T : class 
            => DiContainer.Get<T>();
    
        public T GetComponentInParent<T>(Type type) where T : class 
            => DiContainer.Get<T>(type);

        public T GetComponentInParent<T>(string id) where T : class 
            => DiContainer.Get<T>(id);
    }
}