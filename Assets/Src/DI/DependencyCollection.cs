using System;
using System.Collections.Generic;

namespace DI
{
    public class DependenciesCollection
    {
        private Dictionary<Type, Dependency> _dependencies = new();

        public void Add(Dependency dependency)
        {
            if (!_dependencies.ContainsKey(dependency.Type))
            {
                _dependencies.Add(dependency.Type, dependency);
            }
            
            _dependencies[dependency.Type] = dependency;
        }
        
        public object Get(System.Type type)
        {
            if (!_dependencies.ContainsKey(type))
            {
                throw new ArgumentException("No dependency");
            }

            return _dependencies[type].Factory();
        }

        public T Get<T>()
        {
            return (T) Get(typeof(T));
        }
    }

    public class Dependency
    {
        public Type Type { get; }
        public Func<object> Factory { get; }

        public Dependency(Type type, Func<object> factory)
        {
            Type = type;
            Factory = factory;
        }
    }
}