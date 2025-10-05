using System.Collections.Immutable;
using Eidos.Models;

namespace Eidos.Abstractions
{
    /// <summary>
    /// Parser contract for Eidos DSL expressions.
    /// Implementations should be thread-safe for Parse calls.
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Parse input text into an AST. Implementations should collect diagnostics
        /// instead of throwing for recoverable issues.
        /// </summary>
        /// <param name="input">Source expression.</param>
        /// <returns>Root AST node.</returns>
        AstNode Parse(string input);

        /// <summary>
        /// Diagnostics produced during the last parse (immutable snapshot).
        /// </summary>
        ImmutableArray<Diagnostic> Diagnostics { get; }
    }
}
