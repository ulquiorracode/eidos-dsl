namespace Eidos.Resolver.Abstractions;

/// <summary>
/// Resolver flattens an AST into a deterministic set of atom strings,
/// using a registry as the source of truth.
/// </summary>
public interface IResolver
{
    /// <summary>
    /// Flatten AST into atomic identifiers. Returns resulting set and outputs diagnostics.
    /// </summary>
    /// <param name="root">Root AST node.</param>
    /// <param name="registry">Registry snapshot used to resolve namespaces.</param>
    /// <param name="diagnostics">Collected diagnostics (warnings/errors).</param>
    ImmutableHashSet<string> Flatten(AstNode root, IRegistry registry, out ImmutableArray<Diagnostic> diagnostics);
}
