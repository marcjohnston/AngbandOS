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
- Set `Inline` to indicate whether the referenced foreign object's properties should be rendered inline.
- The metadata scaffolding program must copy `CollectionName` to `ForeignCollectionName` and `Inline` to the generated metadata.
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

### 11. Example rules and enforcement

- Preserve nullable reference-type distinctions (e.g. `string` vs `string?`).
- Preserve tuple element names and nullable tuple element types.

---

These guidelines will be applied by the assistant when you ask to annotate files. If you want these saved as an `.editorconfig` entry instead, request that specifically.