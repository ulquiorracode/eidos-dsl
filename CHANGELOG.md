# Changelog

## [0.1.0] - Initial Commit
- Project structure initialized
- Added .gitignore, README, LICENSE placeholders
- Defined base folder structure and abstractions plan

## [0.2.0] - Core abstraction scaffolding
- Add interfaces: IParser, IRegistry, IResolver
- Add base diagnostic support (EidosBase)
- Add AST models (IdentNode, ListNode, CompoundNode, NegationNode)
- Add sealed stubs: EidosParser, EidosRegistry (immutable builder style), EidosResolver
- Add GlobalUsings convenience file

## [0.2.1] - Tests and coverage for core scaffolding
- Add parser tests for simple/empty/whitespace cases
- Add registry tests for empty, parent->children, and star-resolution
- Add resolver tests for ident, list, negation, and compound cases