using System.Reflection;
using AngbandOS.Core.Interface;
using AngbandOS.Core.Interface.Configuration;
using AngbandOS.Core.Interface.Configuration.Annotations;

if (args.Length != 1)
{
    Console.Error.WriteLine(
        "syntax: scaffold-metadata {output_folder}");

    return 1;
}

string outputFolder = Path.GetFullPath(args[0]);

if (File.Exists(outputFolder))
{
    Console.Error.WriteLine(
        $"The output path '{outputFolder}' is a file. " +
        "The output path must be either nonexistent or an existing directory.");

    return 1;
}

List<string> errors = new();

HashSet<Type> reachableTypes = new();
HashSet<Type> activeTypes = new();
HashSet<Type> completedTypes = new();

VisitConfigurationType(
    typeof(GameConfiguration),
    reachableTypes,
    activeTypes,
    completedTypes,
    errors);

if (errors.Count > 0)
{
    foreach (string error in errors)
    {
        Console.Error.WriteLine($"error: {error}");
    }

    return 1;
}

Dictionary<Type, ConfigurationEntityAttribute> entities =
    reachableTypes
        .Select(
            type =>
                (
                    Type: type,
                    Entity: type.GetCustomAttribute<ConfigurationEntityAttribute>(
                        inherit: true)))
        .Where(x => x.Entity != null)
        .ToDictionary(
            x => x.Type,
            x => x.Entity!);

HashSet<Type> enumTypes =
    reachableTypes
        .SelectMany(type => GetConfigurationProperties(type))
        .Select(property => GetEnumType(property.PropertyType))
        .Where(enumType => enumType != null)
        .Select(enumType => enumType!)
        .ToHashSet();

if (Directory.Exists(outputFolder))
{
    try
    {
        Directory.Delete(outputFolder, recursive: true);
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine(
            $"Unable to delete existing output directory '{outputFolder}': {exception.Message}");

        return 1;
    }
}

Directory.CreateDirectory(outputFolder);

foreach (Type configurationType in reachableTypes
    .OrderBy(x => x.Name, StringComparer.Ordinal))
{
    WriteMetadataClass(
        outputFolder,
        configurationType,
        entities,
        enumTypes);
}

Console.WriteLine(
    $"Generated {reachableTypes.Count} metadata classes in '{outputFolder}'.");

return 0;

static bool IsConfigurationType(Type type)
{
    return type.IsClass &&
        !type.IsAbstract &&
        (
            type == typeof(GameConfiguration) ||
            typeof(NonCompositeSingletonGameConfiguration)
                .IsAssignableFrom(type) ||
            typeof(IGetKeyGameConfiguration)
                .IsAssignableFrom(type) ||
            type.GetCustomAttribute<ConfigurationEntityAttribute>(
                inherit: true) != null);
}

static void VisitConfigurationType(
    Type configurationType,
    ISet<Type> reachableTypes,
    ISet<Type> activeTypes,
    ISet<Type> completedTypes,
    ICollection<string> errors)
{
    if (completedTypes.Contains(configurationType))
    {
        return;
    }

    if (!activeTypes.Add(configurationType))
    {
        errors.Add(
            $"Configuration type '{configurationType.FullName}' contains a recursive property relationship.");

        return;
    }

    reachableTypes.Add(configurationType);

    if (configurationType.GetCustomAttribute<ConfigurationEntityAttribute>(
            inherit: true) == null)
    {
        errors.Add(
            $"Configuration type '{configurationType.FullName}' is missing ConfigurationEntityAttribute.");
    }

    foreach (PropertyInfo property in GetConfigurationProperties(configurationType))
    {
        Type? referencedType =
            GetReferencedConfigurationType(property.PropertyType);

        if (referencedType != null)
        {
            VisitConfigurationType(
                referencedType,
                reachableTypes,
                activeTypes,
                completedTypes,
                errors);
        }

        ConfigurationMetadataAttribute? metadata =
            property.GetCustomAttribute<ConfigurationMetadataAttribute>(
                inherit: false);

        if (metadata == null)
        {
            errors.Add(
                $"Property '{configurationType.FullName}.{property.Name}' is not annotated with ConfigurationMetadataAttribute.");

            continue;
        }

        if (string.IsNullOrWhiteSpace(metadata.Title))
        {
            errors.Add(
                $"Property '{configurationType.FullName}.{property.Name}' has no metadata Title.");
        }

        if (string.IsNullOrWhiteSpace(metadata.Summary))
        {
            errors.Add(
                $"Property '{configurationType.FullName}.{property.Name}' has no metadata Summary.");
        }

        if (string.IsNullOrWhiteSpace(metadata.DataType))
        {
            errors.Add(
                $"Property '{configurationType.FullName}.{property.Name}' has no metadata DataType.");
        }
    }

    activeTypes.Remove(configurationType);
    completedTypes.Add(configurationType);
}

static IEnumerable<PropertyInfo> GetConfigurationProperties(
    Type configurationType)
{
    return configurationType
        .GetProperties(
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.DeclaredOnly)
        .Where(x =>
            x.GetIndexParameters().Length == 0 &&
            x.GetMethod?.IsPublic == true &&
            x.SetMethod?.IsPublic == true)
        .OrderBy(x => x.MetadataToken);
}

static Type? GetReferencedConfigurationType(Type propertyType)
{
    Type unwrappedType =
        Nullable.GetUnderlyingType(propertyType)
        ?? propertyType;

    while (unwrappedType.IsArray)
    {
        unwrappedType =
            unwrappedType.GetElementType()
            ?? throw new InvalidOperationException(
                $"Unable to determine the element type for '{propertyType}'.");

        unwrappedType =
            Nullable.GetUnderlyingType(unwrappedType)
            ?? unwrappedType;
    }

    return IsConfigurationType(unwrappedType)
        ? unwrappedType
        : null;
}

static void WriteMetadataClass(
    string outputFolder,
    Type configurationType,
    IReadOnlyDictionary<Type, ConfigurationEntityAttribute> entities,
    IReadOnlyCollection<Type> enumTypes)
{
    string metadataClassName =
        GetMetadataClassName(configurationType);

    string outputPath =
        Path.Combine(outputFolder, $"{metadataClassName}.cs");

    using StreamWriter writer = new(outputPath, false);

    writer.WriteLine("// <auto-generated>");
    writer.WriteLine("// This code was generated by scaffold-metadata.");
    writer.WriteLine("// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.");
    writer.WriteLine("// </auto-generated>");
    writer.WriteLine("namespace AngbandOS.Core.Interface.Metadata;");
    writer.WriteLine();
    writer.WriteLine($"public static class {metadataClassName}");
    writer.WriteLine("{");

    if (configurationType == typeof(GameConfiguration))
    {
        WriteEnumMetadata(
            writer,
            enumTypes);
    }

    writer.WriteLine("    public static PropertyMetadata[] Metadata");
    writer.WriteLine("    {");
    writer.WriteLine("        get");
    writer.WriteLine("        {");
    writer.WriteLine("            return new PropertyMetadata[]");
    writer.WriteLine("            {");

    foreach (PropertyInfo property in GetConfigurationProperties(configurationType))
    {
        ConfigurationMetadataAttribute metadata =
            property.GetCustomAttribute<ConfigurationMetadataAttribute>(
                inherit: false)
            ?? throw new InvalidOperationException(
                $"Property '{configurationType.FullName}.{property.Name}' is missing ConfigurationMetadataAttribute.");

        WriteProperty(
            writer,
            property,
            metadata,
            entities,
            4);
    }

    writer.WriteLine("            };");
    writer.WriteLine("        }");
    writer.WriteLine("    }");
    writer.WriteLine("}");
}

static void WriteProperty(
    StreamWriter writer,
    PropertyInfo property,
    ConfigurationMetadataAttribute metadata,
    IReadOnlyDictionary<Type, ConfigurationEntityAttribute> entities,
    int indentLevel)
{
    ConfigurationForeignKeyAttribute? foreignCollection =
        property.GetCustomAttribute<ConfigurationForeignKeyAttribute>(
            inherit: true);

    string dataType =
        metadata.DataType?.Trim()
        ?? throw new InvalidOperationException(
            $"The property '{property.DeclaringType?.FullName}.{property.Name}' has no DataType.");

    string indentation =
        new(' ', indentLevel * 4);

    Type propertyType =
        Nullable.GetUnderlyingType(property.PropertyType)
        ?? property.PropertyType;

    bool isArray =
        propertyType.IsArray;

    Type? elementType =
        isArray
            ? propertyType.GetElementType()
            : null;

    string metadataType =
        GetMetadataType(
            dataType,
            propertyType,
            elementType,
            property,
            foreignCollection,
            entities);

    writer.WriteLine(
        $"{indentation}new {metadataType}(\"{Escape(property.Name)}\")");

    writer.WriteLine($"{indentation}{{");

    if (foreignCollection != null)
    {
        writer.WriteLine(
            $"{indentation}    ForeignCollectionName = " +
            $"\"{Escape(foreignCollection.CollectionName)}\",");
    }

    if (metadataType == nameof(CollectionPropertyMetadata) &&
        elementType != null &&
        entities.TryGetValue(
            elementType,
            out ConfigurationEntityAttribute? entity))
    {
        string childMetadataClassName =
            GetMetadataClassName(elementType);

        writer.WriteLine(
            $"{indentation}    PropertyMetadatas = " +
            $"{childMetadataClassName}.Metadata,");

        writer.WriteLine(
            $"{indentation}    EntityNoun = " +
            $"\"{Escape(entity.EntityNoun ?? string.Empty)}\",");

        writer.WriteLine(
            $"{indentation}    EntityNounTitle = " +
            $"\"{Escape(entity.Title ?? string.Empty)}\",");

        writer.WriteLine(
            $"{indentation}    EntityKeyPropertyName = " +
            $"\"GetKey\",");

        writer.WriteLine(
            $"{indentation}    EntityNamePropertyName = " +
            $"\"GetKey\",");
    }

    writer.WriteLine(
        $"{indentation}    Description = " +
        $"\"{Escape(metadata.Summary ?? string.Empty)}\",");

    writer.WriteLine(
        $"{indentation}    IsNullable = " +
        $"{IsNullable(dataType).ToString().ToLowerInvariant()},");

    if (metadata.Title != null)
    {
        writer.WriteLine(
            $"{indentation}    Title = " +
            $"\"{Escape(metadata.Title)}\",");
    }

    ConfigurationCategoryAttribute? propertyCategory =
        property.GetCustomAttribute<ConfigurationCategoryAttribute>(
            inherit: true);

    writer.WriteLine(
        $"{indentation}    CategoryTitle = " +
        $"\"{Escape(propertyCategory?.Title ?? string.Empty)}\",");

    if (metadataType == nameof(EnumPropertyMetadata))
    {
        Type enumType =
            GetEnumType(property.PropertyType)
            ?? throw new InvalidOperationException(
                $"Unable to determine the enum type for property '{property.Name}'.");

        writer.WriteLine(
            $"{indentation}    EnumName = " +
            $"\"{Escape(enumType.Name)}\",");
    }

    writer.WriteLine($"{indentation}}},");
}

static void WriteEnumMetadata(
    StreamWriter writer,
    IReadOnlyCollection<Type> enumTypes)
{
    writer.WriteLine("    public static EnumMetadata[] Enums");
    writer.WriteLine("    {");
    writer.WriteLine("        get");
    writer.WriteLine("        {");
    writer.WriteLine("            return new EnumMetadata[]");
    writer.WriteLine("            {");

    foreach (Type enumType in enumTypes
        .OrderBy(x => x.Name, StringComparer.Ordinal))
    {
        writer.WriteLine(
            $"                new EnumMetadata(" +
            $"\"{Escape(enumType.Name)}\", " +
            "new EnumOptionMetadata[]");
        writer.WriteLine("                {");

        foreach (string enumName in Enum.GetNames(enumType))
        {
            long enumValue =
                Convert.ToInt64(
                    Enum.Parse(
                        enumType,
                        enumName));

            writer.WriteLine(
                $"                    new EnumOptionMetadata(" +
                $"\"{Escape(enumName)}\", {enumValue}),");
        }

        writer.WriteLine("                }),");
    }

    writer.WriteLine("            };");
    writer.WriteLine("        }");
    writer.WriteLine("    }");
    writer.WriteLine();
}

static string GetMetadataType(
    string dataType,
    Type propertyType,
    Type? elementType,
    PropertyInfo property,
    ConfigurationForeignKeyAttribute? foreignCollection,
    IReadOnlyDictionary<Type, ConfigurationEntityAttribute> entities)
{
    if (IsTuple(dataType))
    {
        return nameof(TuplePropertyMetadata);
    }

    if (foreignCollection != null)
    {
        return elementType == null
            ? nameof(ForeignKeyPropertyMetadata)
            : nameof(ForeignKeysPropertyMetadata);
    }

    if (elementType != null &&
        entities.ContainsKey(elementType))
    {
        return nameof(CollectionPropertyMetadata);
    }

    string normalizedType =
        RemoveNullableAndArraySuffixes(dataType);

    return normalizedType switch
    {
        "bool" => nameof(BooleanPropertyMetadata),
        "char" => nameof(CharacterPropertyMetadata),
        "int" => nameof(IntegerPropertyMetadata),
        "string" when IsArray(dataType) => nameof(StringsPropertyMetadata),
        "string" => nameof(StringPropertyMetadata),
        "ColorEnum" => nameof(ColorPropertyMetadata),
        _ when propertyType.IsEnum => nameof(EnumPropertyMetadata),
        _ => throw new InvalidOperationException(
            $"The data type '{dataType}' is not supported in " +
            $"file '{property.DeclaringType?.Name}.cs' for property '{property.Name}'.")
    };
}

static string GetMetadataClassName(Type configurationType)
{
    if (configurationType == typeof(GameConfiguration))
    {
        return "GameConfigurationMetadata";
    }

    return configurationType.Name.Replace(
        "GameConfiguration",
        "Metadata",
        StringComparison.Ordinal);
}

static bool IsTuple(string dataType)
{
    return RemoveNullableAndArraySuffixes(dataType)
        .TrimStart()
        .StartsWith("(");
}

static bool IsArray(string dataType)
{
    return dataType.Contains("[]", StringComparison.Ordinal);
}

static bool IsNullable(string dataType)
{
    return dataType.TrimEnd().EndsWith(
        "?",
        StringComparison.Ordinal);
}

static string RemoveNullableAndArraySuffixes(string dataType)
{
    string result =
        dataType.Trim();

    bool changed;

    do
    {
        changed = false;

        if (result.EndsWith("?", StringComparison.Ordinal))
        {
            result = result[..^1].TrimEnd();
            changed = true;
        }

        if (result.EndsWith("[]", StringComparison.Ordinal))
        {
            result = result[..^2].TrimEnd();
            changed = true;
        }
    }
    while (changed);

    return result;
}


static string Escape(string value)
{
    return value
        .Replace("\\", "\\\\", StringComparison.Ordinal)
        .Replace("\"", "\\\"", StringComparison.Ordinal)
        .Replace("\r", "\\r", StringComparison.Ordinal)
        .Replace("\n", "\\n", StringComparison.Ordinal);
}

static Type? GetEnumType(Type propertyType)
{
    Type unwrappedType =
        Nullable.GetUnderlyingType(propertyType)
        ?? propertyType;

    return unwrappedType.IsEnum
        ? unwrappedType
        : null;
}