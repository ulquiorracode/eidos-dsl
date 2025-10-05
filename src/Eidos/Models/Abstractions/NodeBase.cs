// src/Eidos/Models/Abstractions/NodeBase.cs
namespace Eidos.Models.Abstractions
{
    /// <summary>
    /// Minimal, lightweight base record for AST nodes.
    /// </summary>
    public abstract record NodeBase(string Kind) : INode;
}

