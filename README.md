# Eidos DSL

**Eidos DSL** is a lightweight declarative language designed to flatten hierarchical data structures into compact, human-readable expressions.  
Originally built for access policies (Polity), it has evolved into a general-purpose DSL engine for composable configuration and registry-driven resolution.

---

## Status

**Version:** `0.2.1`  
**Stage:** Core functional — stable registry and resolver, parser stub implemented.  
This release establishes the core abstraction layer and provides a working example of the DSL pipeline.

---

## Example

```csharp
using Eidos.Parser;
using Eidos.Resolver;
using Eidos.Registry;
using Eidos.Models;

// Build registry
var registry = EidosRegistry.Empty()
    .With("chat", "chat.global", "chat.team", "chat.admins");

// Parse expression
var parser = new EidosParser();
var resolver = new EidosResolver();

var ast = parser.Parse("chat![admins]");
var result = resolver.Flatten(ast, registry, out var diagnostics);

// result = ["chat.global", "chat.team"]
```

## Design goals
- Declarative minimalism — short syntax, deep meaning
- Immutable core — thread-safe and predictable
- Registry-first design — pre-registered components drive resolution
- Composable architecture — Parser, Registry, and Resolver work independently or together

## Roadmap
- Core abstractions and models
- Registry and Resolver
- Parser stub
- Unit tests for core modules
- Full tokenizer and grammar parser
- Attribute-based registry registration
- CLI & runtime integration
- Source Generator (Roslyn) integration
- DSL diagnostics visualizer

## Development

Build the project:

```bash
dotnet build
```

Run all tests:

```bash
dotnet test
```

Project targets .NET 10 (C# 14.0) and follows modern conventions:
- implicit usings
- file-scoped namespaces
- collection expressions
- immutable models

## License
Licensed under the GNU GPL v3.0.
See [LICENSE](LICENSE) for details.

## Maintainer
Developed by ulquiorracode.
Contributions, discussions, and experimental ideas are welcome.