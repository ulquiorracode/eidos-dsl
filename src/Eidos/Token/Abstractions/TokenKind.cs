namespace Eidos.Token.Abstractions;

/// <summary>
/// A minimal set of token kinds used by the parser.
/// </summary>
public enum TokenKind
{
    Identifier,
    Asterisk,
    Bang,
    LBracket,
    RBracket,
    Colon,
    Comma,
    End
}
