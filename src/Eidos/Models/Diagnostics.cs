// src/Eidos/Models/Diagnostics.cs
namespace Eidos.Models
{
    /// <summary>
    /// Diagnostic severity.
    /// </summary>
    public enum DiagnosticSeverity
    {
        Info,
        Warning,
        Error
    }

    /// <summary>
    /// Diagnostic message produced by parser/resolver/registry.
    /// Immutable record.
    /// </summary>
    public sealed record Diagnostic(DiagnosticSeverity Severity, string Message, int? Position = null);
}

