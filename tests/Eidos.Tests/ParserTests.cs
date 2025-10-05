using Eidos.Parser;
using Eidos.Models;

namespace Eidos.Tests
{
    public class ParserTests
    {
        [Fact]
        public void Parser_ShouldReturnIdentNode_ForSimpleInput()
        {
            var parser = new EidosParser();
            var node = parser.Parse("chat");

            Assert.IsType<IdentNode>(node);
            var ident = Assert.IsType<IdentNode>(node);
            Assert.Equal("chat", ident.Identifier);
            Assert.Empty(parser.Diagnostics);
        }

        [Fact]
        public void Parser_ShouldEmitDiagnostic_ForEmptyInput()
        {
            var parser = new EidosParser();
            var node = parser.Parse("");

            Assert.IsType<ListNode>(node);
            Assert.Single(parser.Diagnostics);
            Assert.Equal(DiagnosticSeverity.Error, parser.Diagnostics[0].Severity);
        }

        [Fact]
        public void Parser_ShouldTrimWhitespace()
        {
            var parser = new EidosParser();
            var node = parser.Parse("  admins  ");

            var ident = Assert.IsType<IdentNode>(node);
            Assert.Equal("admins", ident.Identifier);
            Assert.Empty(parser.Diagnostics);
        }
    }
}


