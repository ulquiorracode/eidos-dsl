namespace Eidos.Nodes;

/// <summary>
/// Identifier node: represents a single symbol (e.g. "chat" or "admins").
/// </summary>
public sealed record IdentNode(string Identifier)
    : AstNode(nameof(IdentNode));
