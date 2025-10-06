namespace Eidos.Nodes;

/// <summary>
/// Minimal, lightweight base record for AST nodes.
/// </summary>
public abstract record NodeBase(string Kind) : INode;
