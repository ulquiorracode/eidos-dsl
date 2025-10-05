// src/Eidos/Registry/EidosRegistry.cs
using System.Collections.Immutable;
using Eidos.Abstractions;
using Eidos.Models;

namespace Eidos.Registry
{
    /// <summary>
    /// Sealed, immutable registry. Provides simple builder-like helpers that return new instances.
    /// </summary>
    public sealed class EidosRegistry : RegistryBase
    {
        /// <summary>
        /// Construct from existing mapping.
        /// </summary>
        public EidosRegistry(IDictionary<string, IEnumerable<string>> initial)
            : base((initial ?? new Dictionary<string, IEnumerable<string>>())
                   .ToImmutableDictionary(kv => kv.Key,
                                           kv => kv.Value?.ToImmutableArray() ?? ImmutableArray<string>.Empty))
        {
        }

        private EidosRegistry(ImmutableDictionary<string, ImmutableArray<string>> map) : base(map) { }

        /// <summary>
        /// Create empty registry.
        /// </summary>
        public static EidosRegistry Empty() => new EidosRegistry(ImmutableDictionary<string, ImmutableArray<string>>.Empty);

        /// <summary>
        /// Return a new registry with added/overridden parent => children mapping.
        /// Immutable-friendly; does not mutate existing instance.
        /// </summary>
        public EidosRegistry With(string parent, params string[] children)
        {
            var newMap = _map.SetItem(parent, children.ToImmutableArray());
            return new EidosRegistry(newMap);
        }
    }
}

