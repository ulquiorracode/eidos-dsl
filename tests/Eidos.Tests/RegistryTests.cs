using Eidos.Registry;

namespace Eidos.Tests
{
    public class RegistryTests
    {
        [Fact]
        public void Registry_Empty_ShouldResolveNothing()
        {
            var reg = EidosRegistry.Empty();
            var set = reg.ResolveIdentifier("chat");
            Assert.Empty(set);
        }

        [Fact]
        public void Registry_WithChildren_ShouldResolveParentToChildren()
        {
            var reg = EidosRegistry.Empty()
                .With("chat", "chat.global", "chat.team", "chat.admins");

            var set = reg.ResolveIdentifier("chat");
            Assert.Contains("chat.global", set);
            Assert.Contains("chat.team", set);
            Assert.Contains("chat.admins", set);
        }

        [Fact]
        public void Registry_ShouldResolveStarToAllAtoms()
        {
            var reg = EidosRegistry.Empty()
                .With("chat", "chat.global")
                .With("mail", "mail.inbox", "mail.sent");

            var set = reg.ResolveIdentifier("*");
            Assert.Contains("chat.global", set);
            Assert.Contains("mail.inbox", set);
            Assert.Contains("mail.sent", set);
        }
    }
}


