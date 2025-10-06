namespace Eidos.Parser;

/// <summary>
/// Minimal, sealed parser stub for Eidos DSL.
/// Full parsing logic will be implemented incrementally.
/// </summary>
public sealed class EidosParser : ParserBase
{
    /// <inheritdoc />
    public override AstNode Parse(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            AddDiagnostic(DiagnosticSeverity.Error, "Input is empty.");
            return new ListNode([]);
        }

        // Placeholder behavior: treat entire string as a single identifier (fallback).
        // Real parser: tokenization + EBNF -> AST.
        return new IdentNode(input.Trim());
    }
}
