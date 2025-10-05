// src/Eidos/Models/AstNode.cs
using System.Collections.Immutable;
using Eidos.Models.Abstractions;

namespace Eidos.Models
{
    /// <summary>
    /// Base type for AST nodes produced by the parser.
    /// </summary>
    public abstract record AstNode;

    /// <summary>
    /// Identifier node: "chat" or "admins".
    /// </summary>
    public sealed record IdentNode(string Identifier) : AstNode;

    /// <summary>
    /// List node: [a, b, c]
    /// </summary>
    public sealed record ListNode(ImmutableArray<AstNode> Items) : AstNode;

    /// <summary>
    /// Compound node: parent:child -> represented as Parent + Child node.
    /// </summary>
    public sealed record CompoundNode(string Parent, AstNode Child) : AstNode;

    /// <summary>
    /// Negation/exclusion node: !item
    /// </summary>
    public sealed record NegationNode(AstNode Inner) : AstNode;
}

