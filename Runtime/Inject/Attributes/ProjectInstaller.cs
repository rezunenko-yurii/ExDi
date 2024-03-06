using System;

namespace ExDi.Runtime.Inject.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class ProjectInstaller : Attribute { }
}