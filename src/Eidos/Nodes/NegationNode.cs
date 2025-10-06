namespace Eidos.Nodes;

/// <summary>
/// Negation node: represents an exclusion expression (e.g. !admins).
/// </summary>
public sealed record NegationNode(AstNode Inner)
    : AstNode(nameof(NegationNode));
