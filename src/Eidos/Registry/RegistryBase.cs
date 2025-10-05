// src/Eidos/Registry/RegistryBase.cs
using System.Collections.Immutable;
using Eidos.Abstractions;
using Eidos.Models;

namespace Eidos.Registry
{
    /// <summary>
    /// Base class for registries. Stores an immutable snapshot map: parent -> children[].
    /// </summary>
    public abstract class RegistryBase : EidosBase, IRegistry
    {
        protected readonly ImmutableDictionary<string, ImmutableArray<string>> _map;

        protected RegistryBase(ImmutableDictionary<string, ImmutableArray<string>> map)
        {
            _map = map ?? ImmutableDictionary<string, ImmutableArray<string>>.Empty;
        }

        /// <inheritdoc />
        public ImmutableDictionary<string, ImmutableArray<string>> Snapshot => _map;

        /// <inheritdoc />
        public virtual ImmutableHashSet<string> ResolveIdentifier(string identifier)
        {
            if (string.IsNullOrWhiteSpace(identifier))
                return ImmutableHashSet<string>.Empty;

            if (identifier == "*")
                return _map.SelectMany(kvp => kvp.Value).ToImmutableHashSet(StringComparer.Ordinal);

            if (_map.TryGetValue(identifier, out var children))
                return children.ToImmutableHashSet(StringComparer.Ordinal);

            // If identifier matches a concrete atom (exists inside any children list), return it
            if (_map.Values.Any(arr => arr.Contains(identifier)))
                return ImmutableHashSet.Create(StringComparer.Ordinal, identifier);

            AddDiagnostic(DiagnosticSeverity.Warning, $"Identifier '{identifier}' not found in registry.");
            return ImmutableHashSet<string>.Empty;
        }

        /// <inheritdoc />
        public bool TryGetChildren(string parent, out ImmutableArray<string> children)
        {
            if (_map.TryGetValue(parent, out children)) return true;
            children = ImmutableArray<string>.Empty;
            return false;
        }
    }
}

