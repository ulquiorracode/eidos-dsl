# Eidos DSL Grammar (Draft)

This document describes the evolving grammar for Eidos DSL.

---

## 🧩 Expression structure

An expression describes inclusion and exclusion of groups or entities.

### Examples

chat*
chat![admins]
chat[global, team]
chat:!admins


---

## 🧠 Grammar (EBNF-style)


Expression ::= Term { ',' Term } ;
Term ::= Negation | Atom ;
Negation ::= '!' Atom ;
Atom ::= Identifier | List | Compound ;
List ::= '[' Expression { ',' Expression } ']' ;
Compound ::= Identifier (':' | '!') Atom ;
Identifier ::= Letter { Letter | Digit | '_' | '.' } ;


---

## 🧱 Notes

- `*` denotes “all children under this namespace”.
- `!` negates or excludes sub-elements.
- `[]` groups expressions into lists.
- Colons (`:`) are optional and may be omitted (`chat!admins` = `chat:!admins`).

---

## 🔮 Future extensions
- Support for macro expansion.
- Namespaced registry references (`registry::group`).
- Partial evaluation with lazy evaluation.
