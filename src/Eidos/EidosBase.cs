namespace Eidos;

/// <summary>
/// Lightweight base for components that collect diagnostics.
/// Keeps diagnostics in-memory; exposes immutable snapshot through helper.
/// </summary>
public abstract class EidosBase : IEidos
{
    private readonly List<Diagnostic> _diagnostics = [];

    /// <summary>
    /// Protected helper to add a diagnostic.
    /// </summary>
    protected void AddDiagnostic(Diagnostic diagnostic) => _diagnostics.Add(diagnostic);

    /// <summary>
    /// Add by parts.
    /// </summary>
    protected void AddDiagnostic(DiagnosticSeverity severity, string message, int? position = null)
        => _diagnostics.Add(new Diagnostic(severity, message, position));

    /// <summary>
    /// Immutable snapshot of diagnostics collected so far.
    /// </summary>
    public ImmutableArray<Diagnostic> GetDiagnostics() => _diagnostics.ToImmutableArray();
}
