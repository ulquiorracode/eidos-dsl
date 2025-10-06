namespace Eidos.Parser;

/// <summary>
/// Base parser with diagnostic support.
/// </summary>
public abstract class ParserBase : EidosBase, IParser
{
    /// <inheritdoc />
    public abstract AstNode Parse(string input);

    /// <inheritdoc />
    public ImmutableArray<Diagnostic> Diagnostics => GetDiagnostics();
}
