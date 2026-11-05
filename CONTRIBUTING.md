# CONTRIBUTING.md

## AngbandOS Configuration Annotation Guidelines

These guidelines define the project-wide standard for annotating configuration classes with the custom metadata attributes located in the `AngbandOS.Core.Interface.Configuration.Annotations` project.

Follow these rules exactly when adding or updating annotations. The metadata is used by reflection to generate configuration documentation, UI and schema information.

### 1. Class-level Entity Attribute

- Add a `ConfigurationEntityAttribute` to every configuration class that represents an entity.
- Syntax:
  ```csharp
  [ConfigurationEntityAttribute(
      Title = "<Human-Readable Title>",
      EntityNoun = "<CanonicalEntityNoun>")]
  public class ...
  {
  }
  ```
- `Title` is singular, human readable.
- `EntityNoun` is the canonical noun matching the class name (remove trailing `GameConfiguration`). Do not pluralize.

### 2. Property-level Metadata Attribute

- Every configurable property must have a `ConfigurationMetadataAttribute` placed immediately above the property.
- The attribute MUST include `Title`, `Summary`, and `DataType` fields.
- Example:
  ```csharp
  [ConfigurationMetadataAttribute(
      Title = "Name",
      Summary = "Returns the name of the activation.",
      DataType = "string")]
  public virtual string Name { get; set; }
  ```
- Remove the property's XML `<summary>` when you replace it with `ConfigurationMetadataAttribute`.
- Remove any old `<foreign-collection-name>` XML annotations when replaced.

### 3. DataType rules (explicit)

- `DataType` must be supplied manually and must exactly reflect the source-level C# type, including:
  - nullable reference types (e.g. `string?`)
  - nullable value types (e.g. `int?`)
  - arrays (e.g. `string[]`, `int[][]`, `string[]?`, `string?[]`)
  - tuple types (preserve element names and nullability in the DataType string)
  - generic types where used (preserve full generic syntax)

- Do NOT include default values in `DataType`.

### 4. Title and Summary

- `Title` is a human-readable transformation of the PascalCase property name.
- `Summary` should be taken from existing XML `<summary>` documentation when present. If none exists, write a short, accurate description based on the property name and type.

### 5. Tuple properties

- A tuple property receives one `ConfigurationTupleItemAttribute` for each element of the tuple, immediately above the property, followed by the `ConfigurationMetadataAttribute`.
- The `ConfigurationTupleItemAttribute` constructor requires the tuple element name (use `Item1`, `Item2` etc. for unnamed elements).
- Tuple-item foreign keys must specify `ForeignCollectionName` and `Inline` when applicable.
- `ConfigurationTupleItemAttribute.Inline` must be declared as `bool`, not `bool?`; nullable value types are invalid attribute parameter types.
- Example for named tuple elements:
  ```csharp
  [ConfigurationTupleItemAttribute(
      "AttributeKey",
      Title = "Attribute Key")]
  [ConfigurationTupleItemAttribute(
      "DesiredValue",
      Title = "Desired Value")]
  [ConfigurationMetadataAttribute(
      Title = "Bitwise Or Attribute Filter Bindings",
      Summary = "...",
      DataType = "(string AttributeKey, bool DesiredValue)[]?")]
  public virtual (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings { get; set; }
  ```

### 6. Ordering

- Class: `ConfigurationEntityAttribute` then `class` declaration.
- Tuple properties: `ConfigurationTupleItemAttribute` lines first, then `ConfigurationMetadataAttribute`, then the property.
- Normal properties: `ConfigurationMetadataAttribute` then property.

### 7. Preserve semantics

- Do not rename classes, properties, change types, defaults, access modifiers, or implementations.
- Do not annotate methods, constructors, implementation helpers, or infrastructure methods (e.g., `MergeAllSingletonsFromAssembly`, `LoadFromAssembly`, `GetCompositeKey`) unless they are actual configuration properties.
- Do not annotate `CompositeKeys` on `CompositeSingletonGameConfiguration` classes unless user-configurable.

### 8. GameConfiguration special case

- `GameConfiguration` may contain collections, tables and implementation code. Annotate only the actual configuration properties (collections and global values). Do not annotate methods or implementation details.
- DataType for collections should use the `...GameConfiguration[]?` syntax exactly as declared.

### 9. Configuration foreign keys

- Add `ConfigurationForeignKeyAttribute` to a configurable property that references an entity collection.
- Set the constructor argument to the referenced collection name.
- Set `Inline = false` by default when annotating a foreign key.
- The only exception is a foreign key referencing the `ItemEnhancements` collection; set `Inline = true` for that collection.
- Apply the same default to tuple-item foreign keys: use `Inline = false` unless the tuple item references `ItemEnhancements`, in which case use `Inline = true`.
- Always specify `Inline` explicitly; do not rely on the attribute's default value.
- The metadata scaffolding program must copy `CollectionName` to `ForeignCollectionName` and `Inline` to the generated metadata.
- For tuple properties, the scaffolder must emit `Types` on `TuplePropertyMetadata` and populate each tuple-item metadata entry with its `ForeignCollectionName` and `Inline` values when specified.
- A foreign-key property whose `DataType` is an array of strings, such as `string[]?`, must generate `ForeignKeysPropertyMetadata`.
- Any other foreign-key property type, including a non-array string property, must generate `ForeignKeyPropertyMetadata`.
- The scaffolding decision must be based on the property type and exact `DataType`; arrays of types other than `string` must not be treated as foreign-key arrays.
- Example:
  ```csharp
  [ConfigurationMetadata(
      Title = "Spell Names",
      Summary = "Specifies the spell binding keys available to the monster race.",
      DataType = "string[]?")]
  [ConfigurationForeignKey("Spells", Inline = false)]
  public virtual string[]? SpellNames { get; set; }
  ```

### 10. Output and verification

- When asked to annotate a class, return the COMPLETE class source file content (copy/pasteable). Do not use `...` placeholders.
- Verify the final class against the checklist (attributes present, DataType exact, tuple items present, XML removed, defaults preserved, no omitted properties or methods).
- After changing configuration annotations or scaffolding behavior, regenerate the scaffolded metadata and verify the generated foreign-key metadata type, collection name, and `Inline` value.
- For tuple properties, verify that the generated `TuplePropertyMetadata` includes `Types`, `ForeignCollectionName`, and `Inline` where applicable.

### 11. Example rules and enforcement

- Preserve nullable reference-type distinctions (e.g. `string` vs `string?`).
- Preserve tuple element names and nullable tuple element types.

---

These guidelines will be applied by the assistant when you ask to annotate files. If you want these saved as an `.editorconfig` entry instead, request that specifically.

# C# Coding Standards

## Purpose

These standards define the project-wide C# style. The primary goal is readable, maintainable code. Formatting must preserve the visual structure of control flow and make intent apparent without requiring readers to mentally reformat the code.

## Formatting

- Use four spaces for indentation. Do not use tabs.
- Use Allman braces: opening braces appear on their own line for namespaces, types, methods, properties, control-flow statements, and object initializers.
- Place one statement on each line.
- Insert a blank line between logical sections of a method and between related groups of declarations.
- Keep closely related expressions together, but break long expressions at meaningful boundaries.
- Preserve multiline method chains when they improve scanability. Indent each chained operation consistently.
- Do not use aggressive formatter settings that collapse readable multiline code into dense one-line expressions.
- Keep line lengths reasonable when a line becomes difficult to scan; break at operators, arguments, or fluent-method boundaries.
- Use file-scoped namespaces when consistent with the containing project.
- Use top-level statements for small executable entry points when they make the program easier to follow.

## Naming

- Use `PascalCase` for namespaces, classes, structs, records, interfaces, enums, methods, properties, events, and constants.
- Prefix interface names with `I`.
- Use `camelCase` for parameters and local variables.
- Use descriptive names. Avoid single-letter names except for genuinely local iteration variables where the meaning is obvious.
- Use names that communicate the domain concept rather than implementation details.

## Types and declarations

- Enable and respect nullable reference types.
- Preserve nullable annotations in declarations and public APIs.
- Prefer explicit local variable types when the type communicates intent, documents an important contract, or improves readability.
- Use `var` when the type is immediately obvious from the right-hand side and repeating the type would add noise.
- Do not use `var` merely to shorten a declaration when the type is not clear at the point of use.
- Use target-typed `new()` only when the declared type remains immediately clear.
- Prefer pattern matching such as `is null`, `is not null`, and type patterns when it makes the condition clearer.
- Use `const` for values that are compile-time constants and have meaningful names.

## Control flow

- Always use braces for control-flow statements, including single-statement branches.
- Prefer early returns for validation and failure paths when they reduce nesting.
- Keep validation, primary work, and output/error handling in visually distinct sections.
- Use `switch` expressions when they make a finite mapping clearer; use a statement-based `switch` when multiple operations or side effects are involved.
- Do not compress nested conditions or important branching into dense expressions.

## Methods and expressions

- Keep methods focused on one responsibility.
- Prefer ordinary block-bodied methods when the body contains multiple steps, validation, logging, or non-obvious behavior.
- Use expression-bodied members only when the expression is short and remains immediately readable.
- Break long argument lists and chained calls at semantic boundaries.
- Use named arguments when they clarify a non-obvious argument, especially for Boolean or configuration values.
- Avoid unnecessary string interpolation for strings that contain no interpolation.

## Comments and documentation

- Write comments to explain why code exists, a non-obvious constraint, or an algorithmic decision.
- Do not write comments that merely restate the next line of code.
- Keep comments near the code they explain.
- Use XML documentation for public APIs when the project contract requires it.
- Preserve required metadata and annotation conventions defined elsewhere in `CONTRIBUTING.md`.

## Errors and resources

- Validate inputs at the boundary of a method or operation.
- Use exceptions for exceptional conditions, not ordinary control flow.
- Include relevant context in error messages without exposing secrets.
- Dispose owned disposable resources deterministically, using `using` declarations or statements as appropriate.
- Preserve the original exception when rethrowing unless additional context requires an intentional exception translation.

## Readability review

Before committing C# code, verify that:

- Control flow can be understood from indentation and whitespace alone.
- Important types and nullability are visible at the declaration site.
- Long expressions are broken at meaningful boundaries.
- Comments explain intent rather than syntax.
- Formatting changes did not make the code denser or harder to scan.
- The code follows the existing style of the surrounding file.