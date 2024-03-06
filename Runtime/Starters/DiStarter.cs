using ExDi.Runtime.Containers;
using ExDi.Runtime.Installers;
using ExExtensions.Runtime;
using UnityEngine;

namespace ExDi.Runtime.Starters
{
    [RequireComponent(typeof(DiNodeContainer)), DefaultExecutionOrder(-99)]
    public class DiStarter : MonoBehaviour
    {
        [SerializeField] DiMonoInstaller[] _installers = {};
        DiContainer _diContainer;

        protected virtual void  Awake()
        {
            Debug.Log($"DiStarter Awake / onObj={transform.GetHierarchyPath()}");
            _diContainer = GetComponent<DiNodeContainer>();
            
            AddContainer();
            AddDependencies();
            InitializeDependencies();
        }

        void AddContainer()
        {
            foreach (var installer in _installers) installer.AddContainer(_diContainer);
        }

        void AddDependencies()
        {
            foreach (var installer in _installers) installer.AddDependencies();
        }
        
        void InitializeDependencies()
        {
            foreach (var installer in _installers) installer.InitializeDependencies();
        }
    }
}