namespace Eidos.Token;

/// <summary>
/// Token value container.
/// </summary>
public readonly record struct Token(Abstractions.TokenKind Kind, string Lexeme, int Position);
