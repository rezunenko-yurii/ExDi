using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ExDi.Runtime.Inject.Attributes;
using ExDi.Runtime.Receivers;

namespace ExDi.Runtime.Inject
{
    public static class ExInjector
    {
        public static void InjectFields(this ExMonoBehaviour mono)
        {
            var fields = mono.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            
            var diFields = fields.Where(x => x.GetCustomAttributes<InjectFromDi>().Any());
            var goFields = fields.Where(x => x.GetCustomAttributes<InjectFromGo>().Any());
            
            SetFromDi(mono, diFields);
            SetFromGo(mono, goFields);
        }

        static void SetFromDi(ExMonoBehaviour monoBehaviour, IEnumerable<FieldInfo> fields)
        {
            foreach (var field in fields)
            {
                var type = field.FieldType;
                var dependency = monoBehaviour.GetComponentInParent<object>(type);
            
                if (!type.IsInstanceOfType(dependency))
                {
                    dependency = Convert.ChangeType(dependency, type);
                }
            
                field.SetValue(monoBehaviour, dependency);
            }
        }
    
        static void SetFromGo(ExMonoBehaviour monoBehaviour, IEnumerable<FieldInfo> fields)
        {
            foreach (var field in fields)
            {
                var dependency = monoBehaviour.GetComponent(field.FieldType);
                field.SetValue(monoBehaviour, dependency);
            }
        }
    }
}