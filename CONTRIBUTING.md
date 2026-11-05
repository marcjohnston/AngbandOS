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
- Remove the property's XML `<summary>` when replaced with `ConfigurationMetadataAttribute`.
- Remove old `<foreign-collection-name>` XML annotations when replaced.

### 3. DataType rules

- `DataType` must exactly reflect the source-level C# type, including nullable annotations, arrays, tuple element names and nullability, and generic syntax.
- Do not include default values in `DataType`.

### 4. Title and Summary

- `Title` is a human-readable transformation of the PascalCase property name.
- `Summary` should use existing XML summary documentation when present, otherwise be short and accurate.

### 5. Tuple properties

- Add one `ConfigurationTupleItemAttribute` for each tuple element before `ConfigurationMetadataAttribute`.
- Use `Item1`, `Item2`, etc. for unnamed elements.
- Specify tuple-item foreign keys and explicit `Inline` values when applicable.

### 6. Ordering

- Order attributes as entity attribute, class declaration; tuple-item attributes, metadata attribute, property; or metadata attribute, property for normal properties.

### 7. Preserve semantics

- Do not rename classes or properties, change types, defaults, access modifiers, or implementations.
- Do not annotate methods, constructors, helpers, or infrastructure methods unless they are actual configuration properties.
- Do not annotate `CompositeKeys` unless user-configurable.

### 8. GameConfiguration special case

- Annotate only actual configuration properties.
- Preserve the exact `...GameConfiguration[]?` collection `DataType` syntax.

### 9. Configuration foreign keys

- Add foreign-key metadata for entity collection references.
- Use explicit `Inline = false` by default, except `ItemEnhancements`, which uses `Inline = true`.
- Preserve foreign-key array behavior and scaffolding output requirements.

### 10. Output and verification

- When asked to annotate a class, return the complete class source file content without placeholders.
- Verify annotations, exact `DataType`, tuple items, XML removal, defaults, properties, and methods.
- Regenerate scaffolded metadata after annotation or scaffolding changes and verify generated metadata.

### 11. Example rules and enforcement

- Preserve nullable reference-type distinctions and tuple element names and nullable types.

---

These guidelines will be applied by the assistant when asked to annotate files.

# C# Coding Standards

## Formatting

- Use four spaces, never tabs.
- Use Allman braces.
- One statement per line.
- Separate logical sections with blank lines.
- Preserve readable multiline chains and break long expressions at meaningful boundaries.
- Use file-scoped namespaces and top-level statements when consistent with the project.

## Naming

- Use PascalCase for types and members, `I` prefix for interfaces, and camelCase for parameters and locals.
- Use descriptive names and avoid unnecessary acronyms.

## Types and declarations

- Enable and respect nullable reference types.
- Preserve nullable annotations in declarations and APIs.
- Prefer explicit local types when they clarify a contract; use `var` when the type is immediately obvious.
- Use target-typed `new()` only when the declared type remains clear.
- Prefer clear pattern matching and `const` for meaningful compile-time constants.

## Control flow

- Always use braces.
- Prefer early returns when they reduce nesting.
- Separate validation, primary work, and output/error handling.
- Use clear switch expressions for finite mappings.
- Do not compress important branching.

## Methods and expressions

- Keep methods focused.
- Prefer block bodies for multi-step or non-obvious methods.
- Use named arguments when they clarify non-obvious Boolean or configuration values.
- Do not use `+` for string concatenation.

## Comments and documentation

- Comments explain intent, constraints, or algorithms, not obvious syntax.
- Preserve required metadata and annotation conventions.

## Errors and resources

- Validate at operation boundaries.
- Use exceptions for exceptional conditions.
- Include relevant context in errors without secrets.
- Dispose owned resources deterministically.
- Preserve original exceptions when rethrowing.

## Readability review

- Verify indentation, visible types/nullability, meaningful line breaks, intentional comments, and consistency with surrounding code