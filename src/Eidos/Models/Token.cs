// src/Eidos/Models/Token.cs
namespace Eidos.Models
{
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

    /// <summary>
    /// Token value container.
    /// </summary>
    public readonly record struct Token(TokenKind Kind, string Lexeme, int Position);
}

