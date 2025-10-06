namespace Eidos.Nodes;

/// <summary>
/// Compound node: represents a parent-child relationship (e.g. chat:admins).
/// </summary>
public sealed record CompoundNode(string Parent, AstNode Child)
    : AstNode(nameof(CompoundNode));
