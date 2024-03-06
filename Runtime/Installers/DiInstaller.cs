using ExDi.Runtime.Containers;

namespace ExDi.Runtime.Installers
{
    public abstract class DiInstaller
    {
        protected DiContainer Container { get; private set; }
    
        public void AddContainer(DiContainer container) 
            => Container = container;

        public abstract void AddDependencies();

        public abstract void InitializeDependencies();
    }
}