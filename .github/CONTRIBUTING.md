# Contributing to Eidos DSL

Thank you for your interest in contributing to Eidos DSL. We welcome improvements, ideas, and constructive discussions.

---

## Development model

- Main branch: `main` — stable releases only.
- Development branch: `dev` — active development and feature integration.
- Create a separate branch for each change:
  - `feature/parser-grammar`
  - `fix/registry-resolution`
  - `docs/roadmap`
- When the work is complete, submit a Pull Request to `dev`.

---

## Workflow

1. Fork and clone the repository.
2. Create a feature branch from `dev`.
3. Make changes with appropriate tests and documentation updates.
4. Run the full test suite locally and ensure it passes.
5. Open a Pull Request targeting `dev`, referencing related issues if applicable.

---

## Testing

Run the full test suite before committing:
```bash
dotnet test
```

Unit tests are located in `/tests/Eidos.Tests`.

---

## Code style

- Target: C# 14.0 on .NET 10.
- Use file-scoped namespaces.
- Prefer `sealed` implementations where applicable and `record` for immutable models.
- Prefer immutable collections and enable implicit usings.
- Document all public APIs using English XML comments.

---

## Commit messages

Follow Conventional Commits. Examples:

- `feat(parser): implement grammar-based tokenizer`
- `fix(resolver): handle negation correctly`
- `docs(readme): update usage example`
- `test(registry): add unit tests for With() builder`
- `chore(ci): add GitHub Actions workflow`

---

## Licensing

By contributing, you agree that your contributions will be licensed under the GNU GPL v3.0.
