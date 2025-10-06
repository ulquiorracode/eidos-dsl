namespace Eidos.Abstractions;

/// <summary>
/// Common interface for all Eidos components capable of producing diagnostics.
/// </summary>
public interface IEidos
{
    /// <summary>
    /// Returns all diagnostics collected by this component.
    /// </summary>
    ImmutableArray<Diagnostic> GetDiagnostics();
}
