namespace Eidos.Nodes;

/// <summary>
/// Base type for all AST nodes produced by the parser.
/// </summary>
public abstract record AstNode(string Kind) : NodeBase(Kind);
