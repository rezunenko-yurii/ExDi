using System;
using ExDi.Runtime.Containers;
using ExDi.Runtime.Inject.Attributes;
using ExDi.Runtime.Installers;
using ExExtensions.Runtime;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ExDi.Runtime.Starters
{
    public class ProjectDiStarter
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void OnBeforeSceneLoad()
        {
            Debug.Log("ProjectHostStarter OnBeforeSceneLoad");
        
            var go = new GameObject("ProjectDiContainer");
            var container = go.AddComponent<DiContainer>();
            go.tag = "ProjectDiContainer";

            SetDependencies(container);
            Object.DontDestroyOnLoad(go);
        }
    
        static void SetDependencies(DiContainer container)
        {
            Debug.Log("ProjectStarter SetDependencies");
        
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var assembly in assemblies)
            {
                var classes = assembly.FindClassesWithAttribute(typeof(ProjectInstaller));
            
                foreach (var classType in classes)
                {
                    var instance = Activator.CreateInstance(classType);
                    
                    if (instance is DiInstaller installer)
                    {
                        installer.AddContainer(container);
                        installer.AddDependencies();
                        installer.InitializeDependencies();
                    }
                }
            }
        }
    }
}