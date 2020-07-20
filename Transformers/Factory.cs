using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace areyesram
{
    internal static class Factory
    {
        private static readonly List<RegistryEntry> _registry;

        static Factory()
        {
            _registry = File.ReadAllLines("registry.ini")
                .Select(o =>
                {
                    var a = o.Split('=');
                    var b = a[1].Split(',');
                    return new RegistryEntry
                    {
                        Name = a[0],
                        AssemblyName = b[0],
                        ClassName = b[1]
                    };
                }).ToList();
        }

        private static readonly Dictionary<string, Assembly> _assemblies = new Dictionary<string, Assembly>();
        private static readonly Dictionary<string, ITransformer> _transformers = new Dictionary<string, ITransformer>();

        internal static ITransformer GetTransformer(string name)
        {
            if (_transformers.ContainsKey(name))
                return _transformers[name];
            var entry = _registry.FirstOrDefault(o => o.Name.Equals(name));
            var assembly = _assemblies.ContainsKey(entry.AssemblyName)
                ? _assemblies[entry.AssemblyName]
                : Assembly.LoadFile(Path.Combine(Environment.CurrentDirectory,
                    Path.Combine("Filters", entry.AssemblyName)));
            _transformers[name] = assembly.CreateInstance(entry.ClassName) as ITransformer;
            return _transformers[name];
        }

        internal class RegistryEntry
        {
            public string Name { get; set; }
            public string AssemblyName { get; set; }
            public string ClassName { get; set; }
        }
    }
}