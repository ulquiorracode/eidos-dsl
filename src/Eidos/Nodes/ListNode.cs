namespace Eidos.Nodes;

/// <summary>
/// List node: represents a collection of AST nodes (e.g. [a, b, c]).
/// </summary>
public sealed record ListNode(ImmutableArray<AstNode> Items)
    : AstNode(nameof(ListNode));
