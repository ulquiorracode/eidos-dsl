# Eidos DSL

**Eidos DSL** is a declarative language designed for defining and flattening hierarchical sets.
It provides a compact syntax for expressing inclusion, exclusion, and wildcard expansion.

## Features
- Compact syntax (`chat![admins]`, `api[read,write]`)
- Pre-registered registry model
- Extensible architecture

## Example
```csharp
var registry = new EidosRegistry()
    .Namespace("chat", ["team", "admins", "global"]);

var expr = EidosParser.Parse("chat![admins]");
var result = EidosResolver.Flatten(expr, registry);
// result: ["chat.team", "chat.global"]
```