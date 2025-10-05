// src/Eidos/Abstractions/IRegistry.cs
using System.Collections.Immutable;
using Eidos.Models;

namespace Eidos.Abstractions
{
    /// <summary>
    /// Registry contract for pre-registered components used during resolution.
    /// Registry must be immutable (or present an immutable snapshot) for deterministic resolution.
    /// </summary>
    public interface IRegistry
    {
        /// <summary>
        /// Resolve an identifier into a set of atom names.
        /// Example: "chat" -> { "chat.global", "chat.team", ... } or "chat.admins" -> { "chat.admins" }.
        /// </summary>
        /// <param name="identifier">Identifier to resolve.</param>
        /// <returns>Immutable set of resolved atom identifiers.</returns>
        ImmutableHashSet<string> ResolveIdentifier(string identifier);

        /// <summary>
        /// A snapshot of the registry mapping (namespace -> children array).
        /// Implementations should expose an immutable snapshot for reproducibility.
        /// </summary>
        ImmutableDictionary<string, ImmutableArray<string>> Snapshot { get; }

        /// <summary>
        /// Try get direct children for a parent key.
        /// </summary>
        bool TryGetChildren(string parent, out ImmutableArray<string> children);
    }
}

