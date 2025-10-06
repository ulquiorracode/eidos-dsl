namespace Eidos.Diagnostics;

/// <summary>
/// Diagnostic message produced by parser/resolver/registry.
/// Immutable record.
/// </summary>
public sealed record Diagnostic(DiagnosticSeverity Severity, string Message, int? Position = null);
