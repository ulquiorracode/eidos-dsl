namespace Eidos.Nodes.Abstractions;

/// <summary>
/// Marker contract for AST nodes.
/// </summary>
public interface INode
{
    /// <summary>
    /// Node kind (informational).
    /// </summary>
    string Kind { get; }
}
