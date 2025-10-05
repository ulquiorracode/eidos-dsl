// src/Eidos/Resolver/ResolverBase.cs
using System.Collections.Immutable;
using Eidos.Abstractions;
using Eidos.Models;

namespace Eidos.Resolver
{
    /// <summary>
    /// Base resolver implementing the primary flattening algorithm.
    /// Behavior:
    ///  - IdentNode -> registry.ResolveIdentifier
    ///  - ListNode -> union of children
    ///  - CompoundNode(parent, child) -> resolve parent -> expand child relative to each parent
    ///  - NegationNode -> remove inner items from current result
    /// </summary>
    public abstract class ResolverBase : EidosBase, IResolver
    {
        public virtual ImmutableHashSet<string> Flatten(AstNode root, IRegistry registry, out ImmutableArray<Diagnostic> diagnostics)
        {
            var resultBuilder = ImmutableHashSet.CreateBuilder<string>(StringComparer.Ordinal);
            Recurse(root, registry, resultBuilder);
            diagnostics = GetDiagnostics();
            return resultBuilder.ToImmutable();
        }

        protected virtual void Recurse(AstNode node, IRegistry registry, ImmutableHashSet<string>.Builder result)
        {
            switch (node)
            {
                case IdentNode id:
                    {
                        var resolved = registry.ResolveIdentifier(id.Identifier);
                        foreach (var item in resolved) result.Add(item);
                        break;
                    }
                case ListNode list:
                    {
                        foreach (var child in list.Items)
                            Recurse(child, registry, result);
                        break;
                    }
                case CompoundNode c:
                    {
                        // Resolve parent first
                        var parents = registry.ResolveIdentifier(c.Parent);
                        if (parents.IsEmpty)
                        {
                            AddDiagnostic(DiagnosticSeverity.Warning, $"Parent '{c.Parent}' not found during compound resolution.");
                        }

                        // For each parent, resolve child (optimistic simple strategy)
                        foreach (var p in parents)
                        {
                            switch (c.Child)
                            {
                                case IdentNode childIdent:
                                    {
                                        // try direct fully-qualified: p + "." + child
                                        var fq = $"{p}.{childIdent.Identifier}";
                                        var resolved = registry.ResolveIdentifier(fq);
                                        if (!resolved.IsEmpty)
                                        {
                                            foreach (var r in resolved) result.Add(r);
                                        }
                                        else
                                        {
                                            // fallback: search parent's children for suffix match
                                            if (registry.TryGetChildren(c.Parent, out var kids))
                                            {
                                                foreach (var k in kids)
                                                {
                                                    if (k.EndsWith($".{childIdent.Identifier}", StringComparison.Ordinal))
                                                        result.Add(k);
                                                }
                                            }
                                        }

                                        break;
                                    }
                                default:
                                    {
                                        // for complex child nodes — flatten child and prefix with parent
                                        var innerBuilder = ImmutableHashSet.CreateBuilder<string>(StringComparer.Ordinal);
                                        Recurse(c.Child, registry, innerBuilder);
                                        foreach (var item in innerBuilder)
                                        {
                                            // if child already contains parent prefix, keep it
                                            if (item.StartsWith(p + ".", StringComparison.Ordinal))
                                                result.Add(item);
                                            else
                                                result.Add($"{p}.{item}");
                                        }

                                        break;
                                    }
                            }
                        }

                        break;
                    }
                case NegationNode neg:
                    {
                        var remBuilder = ImmutableHashSet.CreateBuilder<string>(StringComparer.Ordinal);
                        Recurse(neg.Inner, registry, remBuilder);
                        foreach (var rem in remBuilder)
                            result.Remove(rem);

                        break;
                    }
                default:
                    AddDiagnostic(DiagnosticSeverity.Warning, $"Unsupported AST node type '{node?.GetType().Name ?? "null"}'.");
                    break;
            }
        }
    }
}

