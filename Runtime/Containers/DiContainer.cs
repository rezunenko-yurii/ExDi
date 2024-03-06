using System;
using System.Collections.Generic;
using UnityEngine;

namespace ExDi.Runtime.Containers
{
    [DefaultExecutionOrder(-100)]
    public class DiContainer : MonoBehaviour
    {
        readonly Dictionary<string, object> _ids = new();
        readonly Dictionary<Type, object> _types = new();
    
        // --- Add ---
    
        public void Add(string id, object obj) 
            => _ids.Add(id, obj);

        public void Add(Type type, object obj) 
            => _types.Add(type, obj);
    
        public void Add(object obj)
            => Add(obj.GetType(), obj);
    
        // --- Contains ---
    
        public bool Contains(string id)
            => _ids.ContainsKey(id);

        public bool Contains(Type type) 
            => _types.ContainsKey(type);

        // --- Get ---
    
        public T Get<T>() where T : class 
            => Get<T>(typeof(T));
    
        public virtual T Get<T>(string id) where T : class 
            => _ids[id] as T;

        public virtual T Get<T>(Type t) where T : class 
            => _types[t] as T;
    
        // --- Get If Contains ---
    
        public T GetIfContains<T>() where T : class 
            => GetIfContains<T>(typeof(T));
    
        public T GetIfContains<T>(Type t) where T : class 
            => Contains(typeof(T)) ? Get<T>() : null;
    
        public T GetIfContains<T>(string id) where T : class 
            => Contains(id) ? Get<T>(id) : null;
    
        // --- Debug ---
    
        [ContextMenu("Log Ids")]
        public void LogIds()
        {
            foreach (var key in _ids.Keys) Debug.Log(key);
        }
    
        [ContextMenu("Log Types")]
        public void LogTypes()
        {
            foreach (var type in _types.Keys) Debug.Log(type);
        }
    }
}