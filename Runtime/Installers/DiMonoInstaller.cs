using ExDi.Runtime.Containers;
using UnityEngine;

namespace ExDi.Runtime.Installers
{
    public abstract class DiMonoInstaller : MonoBehaviour
    {
        protected DiContainer Container { get; private set; }
    
        public virtual void AddContainer(DiContainer container) 
            => Container = container;

        public abstract void AddDependencies();

        public abstract void InitializeDependencies();
    }
}