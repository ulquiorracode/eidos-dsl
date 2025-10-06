# Грамматика Eidos DSL (черновик)

Этот документ описывает развивающуюся грамматику DSL Eidos.

---

## 🧩 Структура выражений

Выражение описывает включение и исключение групп или сущностей.

### Примеры
chat*
chat![admins]
chat[global, team]
chat:!admins

yaml
Копировать код

---

## 🧠 Грамматика (EBNF)
Expression ::= Term { ',' Term } ;
Term ::= Negation | Atom ;
Negation ::= '!' Atom ;
Atom ::= Identifier | List | Compound ;
List ::= '[' Expression { ',' Expression } ']' ;
Compound ::= Identifier (':' | '!') Atom ;
Identifier ::= Letter { Letter | Digit | '_' | '.' } ;

yaml
Копировать код

---

## 🧱 Примечания

- `*` обозначает «все подгруппы пространства имён».
- `!` исключает элементы.
- `[]` группирует выражения.
- Двоеточие (`:`) опционально (`chat!admins` = `chat:!admins`).

---

## 🔮 Будущие расширения
- Макросы.
- Пространства имён (`registry::group`).
- Ленивое разрешение выражений.
