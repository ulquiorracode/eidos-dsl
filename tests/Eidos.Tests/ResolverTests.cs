using Eidos.Nodes;
using Eidos.Registry;
using Eidos.Resolver;

namespace Eidos.Tests;
public class ResolverTests
{
    [Fact]
    public void Resolver_ShouldFlatten_IdentNode()
    {
        var reg = EidosRegistry.Empty().With("chat", "chat.global", "chat.team");
        var resolver = new EidosResolver();

        var set = resolver.Flatten(new IdentNode("chat"), reg, out var diags);

        Assert.Contains("chat.global", set);
        Assert.Contains("chat.team", set);
        Assert.Empty(diags);
    }

    [Fact]
    public void Resolver_ShouldFlatten_ListNode()
    {
        var reg = EidosRegistry.Empty()
            .With("chat", "chat.global")
            .With("mail", "mail.inbox");

        var resolver = new EidosResolver();
        var list = new ListNode([new IdentNode("chat"), new IdentNode("mail")]);

        var set = resolver.Flatten(list, reg, out var diags);
        Assert.Contains("chat.global", set);
        Assert.Contains("mail.inbox", set);
        Assert.Empty(diags);
    }

    [Fact]
    public void Resolver_ShouldApply_NegationNode()
    {
        var reg = EidosRegistry.Empty().With("chat", "chat.global", "chat.team");
        var resolver = new EidosResolver();

        var list = new ListNode([
            new IdentNode("chat"),
            new NegationNode(new IdentNode("chat.team"))
        ]);

        var set = resolver.Flatten(list, reg, out var diags);
        Assert.Contains("chat.global", set);
        Assert.DoesNotContain("chat.team", set);
        Assert.Empty(diags);
    }

    [Fact]
    public void Resolver_ShouldExpand_Compound_ParentChild()
    {
        var reg = EidosRegistry.Empty().With("chat", "chat.global", "chat.team", "chat.admins");
        var resolver = new EidosResolver();

        var compound = new CompoundNode("chat", new IdentNode("admins"));
        var set = resolver.Flatten(compound, reg, out var diags);

        Assert.Contains("chat.admins", set);
        Assert.Empty(diags);
    }
}
