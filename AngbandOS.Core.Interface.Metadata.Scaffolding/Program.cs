using System.Reflection;
using AngbandOS.Core.Interface.Metadata;
using AngbandOS.Core.Interface.Configuration;
using AngbandOS.Core.Interface.Configuration.Annotations;

if (args.Length != 1)
{
    string currentExecutableName = Path.GetFileNameWithoutExtension(Environment.ProcessPath) ?? "scaffold-metadata";
    Console.Error.WriteLine($"syntax: {currentExecutableName} {{output_folder}}");
    return 1;
}

string outputFolder = Path.GetFullPath(args[0]);

if (File.Exists(outputFolder))
{
    Console.Error.WriteLine($"The output path '{outputFolder}' is a file. The output path must be either nonexistent or an existing directory.");
    return 1;
}

List<string> errors = new();
HashSet<Type> reachableTypes = new();
TraverseGameConfigurationType(typeof(GameConfiguration), reachableTypes, errors);

if (errors.Count > 0)
{
    foreach (string error in errors)
    {
        Console.Error.WriteLine($"error: {error}");
    }

    return 1;
}

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
        Console.Error.WriteLine($"Unable to delete existing output directory '{outputFolder}': {exception.Message}");
        return 1;
    }
}

Directory.CreateDirectory(outputFolder);

foreach (Type configurationType in reachableTypes.OrderBy(x => x.Name, StringComparer.Ordinal))
{
    WriteMetadataClass(outputFolder, configurationType, enumTypes);
}

Console.WriteLine($"Generated {reachableTypes.Count} metadata classes in '{outputFolder}'.");
return 0;

static void TraverseGameConfigurationType(Type configurationType, ISet<Type> reachableTypes, ICollection<string> errors)
{
    if (!reachableTypes.Add(configurationType))
    {
        errors.Add($"Configuration type '{configurationType.FullName}' contains a recursive property relationship.");
        return;
    }

    reachableTypes.Add(configurationType);

    foreach (PropertyInfo property in GetConfigurationProperties(configurationType))
    {
        Type? referencedType = GetNonNullableAndNonArrayBaseType(property.PropertyType);

        if (referencedType != null)
        {
            TraverseGameConfigurationType(referencedType, reachableTypes, errors);
        }

        ConfigurationPropertyAttribute? metadata = property.GetCustomAttribute<ConfigurationPropertyAttribute>(inherit: false);

        if (metadata == null)
        {
            errors.Add($"Property '{configurationType.FullName}.{property.Name}' is not annotated with {nameof(ConfigurationPropertyAttribute)}.");
            continue;
        }

        if (string.IsNullOrWhiteSpace(metadata.Title))
        {
            errors.Add($"Property '{configurationType.FullName}.{property.Name}' has no metadata Title.");
        }

        if (string.IsNullOrWhiteSpace(metadata.Summary))
        {
            errors.Add($"Property '{configurationType.FullName}.{property.Name}' has no metadata Summary.");
        }

        if (string.IsNullOrWhiteSpace(metadata.DataType))
        {
            errors.Add($"Property '{configurationType.FullName}.{property.Name}' has no metadata DataType.");
        }
    }
}

static IEnumerable<PropertyInfo> GetConfigurationProperties(Type gameConfigurationType)
{
    return gameConfigurationType
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

static Type? GetNonNullableAndNonArrayBaseType(Type propertyType)
{
    // Remove the outside nullable wrapper if the property type is nullable.
    Type? unwrappedType = Nullable.GetUnderlyingType(propertyType) ?? propertyType;

    // We need to unwrap nested arrays of arrays.
    while (unwrappedType.IsArray)
    {
        // Remove the array wrapper to get the base element type.
        unwrappedType = unwrappedType.GetElementType();
        if (unwrappedType is null)
        {
            Console.Error.WriteLine($"Unable to determine the element type for '{propertyType}'.");
            Environment.Exit(1);
        }

        // Remove the nullable wrapper if the element type is nullable.
        unwrappedType = Nullable.GetUnderlyingType(unwrappedType) ?? unwrappedType;
    }

    // Check to see if the unwrapped type implements IGetKeyGameConfiguration, if so return it, otherwise return null.
    return typeof(IGetKeyGameConfiguration).IsAssignableFrom(unwrappedType) ? unwrappedType : null;
}

static void WriteMetadataClass(string outputFolder, Type configurationType, IReadOnlyCollection<Type> enumTypes)
{
    // Determine the name of the file to be created.
    string metadataClassName = GetMetadataClassName(configurationType);

    // Add the path to it.
    string outputPath = Path.Combine(outputFolder, $"{metadataClassName}.cs");
    using StreamWriter writer = new(outputPath, false);

    // Determine the namespace for the output generation.
    var propertyMetadataNamespace = typeof(PropertyMetadata).Namespace;

    writer.WriteLine($"// <auto-generated>");
    writer.WriteLine($"// This code was generated by scaffold-metadata.");
    writer.WriteLine($"// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.");
    writer.WriteLine($"// </auto-generated>");
    writer.WriteLine($"namespace {propertyMetadataNamespace};");
    writer.WriteLine($"public static class {metadataClassName}");
    writer.WriteLine($"{{");

    if (configurationType == typeof(GameConfiguration))
    {
        WriteEnumMetadata(writer, enumTypes);
    }

    writer.WriteLine($"    public static {nameof(PropertyMetadata)}[] Metadata");
    writer.WriteLine($"    {{");
    writer.WriteLine($"        get");
    writer.WriteLine($"        {{");
    writer.WriteLine($"            return new {nameof(PropertyMetadata)}[]");
    writer.WriteLine($"            {{");

    foreach (PropertyInfo property in GetConfigurationProperties(configurationType))
    {
        ConfigurationPropertyAttribute? metadata = property.GetCustomAttribute<ConfigurationPropertyAttribute>(inherit: false);
        if (metadata is null)
        {
            Console.Error.WriteLine($"Property '{configurationType.FullName}.{property.Name}' is missing ConfigurationMetadataAttribute.");
            Environment.Exit(1);
        }

        WriteProperty(writer, property, metadata, 4);
    }

    writer.WriteLine($"            }};");
    writer.WriteLine($"        }}");
    writer.WriteLine($"    }}");
    writer.WriteLine($"}}");
}

static void WriteProperty(StreamWriter writer, PropertyInfo property, ConfigurationPropertyAttribute metadata, int indentLevel)
{
    ConfigurationCollectionAttribute? collection = property.GetCustomAttribute<ConfigurationCollectionAttribute>(inherit: true);
    ConfigurationForeignKeyAttribute? foreignCollection = property.GetCustomAttribute<ConfigurationForeignKeyAttribute>(inherit: true);

    // We need to retrieve the data type property from the annotation.  These data types allow this scaffolder to determine the correct underlying data type due to limitations with reflection and nullablility.
    string? annotatedDataType = metadata.DataType?.Trim();
    if (annotatedDataType is null)
    {
        Console.Error.WriteLine($"The property '{property.DeclaringType?.FullName}.{property.Name}' has no DataType.");
        Environment.Exit(1);
    }

    string indentation = new(' ', indentLevel * 4);
    Type propertyType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
    bool isArray = propertyType.IsArray;
    Type? elementType = isArray ? propertyType.GetElementType() : null;
    string metadataType = GetMetadataType(annotatedDataType, property, foreignCollection, collection);

    writer.WriteLine($"{indentation}new {metadataType}(\"{Escape(property.Name)}\")");
    writer.WriteLine($"{indentation}{{");

    if (foreignCollection is not null)
    {
        writer.WriteLine($"{indentation}    ForeignCollectionName = \"{Escape(foreignCollection.CollectionName)}\",");
        writer.WriteLine($"{indentation}    Inline = {foreignCollection.Inline.ToString().ToLowerInvariant()},");
    }

    if (metadataType == nameof(CollectionPropertyMetadata) && collection != null)
    {
        if (elementType is null)
        {
            Console.Error.WriteLine($"Unable to determine the element type for collection property '{property.Name}'.");
            Environment.Exit(1);
        }
        string childMetadataClassName = GetMetadataClassName(elementType);

        writer.WriteLine($"{indentation}    PropertyMetadatas = {childMetadataClassName}.Metadata,");
        writer.WriteLine($"{indentation}    ForeignCollectionName = \"{Escape(collection.CollectionName)}\",");
        writer.WriteLine($"{indentation}    EntityNoun = \"{Escape(collection.EntityNoun ?? string.Empty)}\",");
        writer.WriteLine($"{indentation}    EntityKeyPropertyName = \"GetKey\",");
        writer.WriteLine($"{indentation}    EntityNamePropertyName = \"{Escape(collection.EntityNamePropertyName ?? "GetKey")}\",");
    }

    writer.WriteLine($"{indentation}    Description = \"{Escape(metadata.Summary ?? string.Empty)}\",");
    writer.WriteLine($"{indentation}    LabelIfNullable = {(DataTypeIsNullable(annotatedDataType) ? $"\"{Escape(metadata.LabelIfNullable ?? "Default")}\"" : "null")},");

    if (metadata.Title is not null)
    {
        writer.WriteLine($"{indentation}    Title = \"{Escape(metadata.Title)}\",");
    }

    ConfigurationCategoryAttribute? propertyCategory = property.GetCustomAttribute<ConfigurationCategoryAttribute>(inherit: true);

    writer.WriteLine($"{indentation}    CategoryTitle = \"{Escape(propertyCategory?.Title ?? string.Empty)}\",");

    if (metadataType == nameof(EnumPropertyMetadata))
    {
        Type enumType =GetEnumType(property.PropertyType)
            ?? throw new InvalidOperationException($"Unable to determine the enum type for property '{property.Name}'.");

        writer.WriteLine($"{indentation}    EnumName = \"{Escape(enumType.Name)}\",");
    }

    if (metadataType == nameof(TuplePropertyMetadata))
    {
        WriteTupleTypes(writer, property, annotatedDataType, indentation);
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

static string GetMetadataType(string dataType, PropertyInfo property, ConfigurationForeignKeyAttribute? foreignCollection, ConfigurationCollectionAttribute? collection)
{
    if (IsTuple(dataType))
    {
        return nameof(TuplePropertyMetadata);
    }

    if (foreignCollection != null)
    {
        return IsStringArray(dataType) ? nameof(ForeignKeysPropertyMetadata) : nameof(ForeignKeyPropertyMetadata);
    }

    if (collection != null)
    {
        return nameof(CollectionPropertyMetadata);
    }

    string normalizedType = RemoveNullableAndArraySuffixes(dataType);

    return normalizedType switch
    {
        "bool" => nameof(BooleanPropertyMetadata),
        "char" => nameof(CharacterPropertyMetadata),
        "int" => nameof(IntegerPropertyMetadata),
        "string" when IsArray(dataType) => nameof(StringsPropertyMetadata),
        "string" => nameof(StringPropertyMetadata),
        "ColorEnum" => nameof(ColorPropertyMetadata),
        _ when normalizedType.EndsWith("Enum", StringComparison.Ordinal) => nameof(EnumPropertyMetadata),
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

    return configurationType.Name.Replace("GameConfiguration", "Metadata", StringComparison.Ordinal);
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

static bool DataTypeIsNullable(string dataType)
{
    return dataType.TrimEnd().EndsWith("?", StringComparison.Ordinal);
}

static string RemoveNullableAndArraySuffixes(string dataType)
{
    string result = dataType.Trim();

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

static bool IsStringArray(string dataType)
{
    return IsArray(dataType) && RemoveNullableAndArraySuffixes(dataType).Equals("string", StringComparison.Ordinal);
}

static void WriteTupleTypes(
    StreamWriter writer,
    PropertyInfo property,
    string dataType,
    string indentation)
{
    Type tupleType =
        Nullable.GetUnderlyingType(property.PropertyType)
        ?? property.PropertyType;

    while (tupleType.IsArray)
    {
        tupleType =
            tupleType.GetElementType()
            ?? throw new InvalidOperationException(
                $"Unable to determine the tuple element type for property '{property.Name}'.");
    }

    if (!tupleType.IsGenericType)
    {
        throw new InvalidOperationException(
            $"Unable to determine tuple element types for property '{property.Name}'.");
    }

    Type[] tupleElementTypes =
        tupleType.GetGenericArguments();

    string[] tupleElementDataTypes =
        GetTupleElementDataTypes(dataType);

    ConfigurationTupleItemAttribute[] tupleItems =
        property
            .GetCustomAttributes<ConfigurationTupleItemAttribute>(
                inherit: true)
            .ToArray();

    if (tupleItems.Length != tupleElementTypes.Length ||
        tupleItems.Length != tupleElementDataTypes.Length)
    {
        throw new InvalidOperationException(
            $"Property '{property.DeclaringType?.FullName}.{property.Name}' " +
            "must have one ConfigurationTupleItemAttribute for each tuple element.");
    }

    writer.WriteLine(
        $"{indentation}    Types = new PropertyMetadata[]");

    writer.WriteLine(
        $"{indentation}    {{");

    for (int index = 0; index < tupleItems.Length; index++)
    {
        ConfigurationTupleItemAttribute tupleItem =
            tupleItems[index];

        string tupleItemDataType =
            tupleElementDataTypes[index];

        Type tupleItemType =
            tupleElementTypes[index];

        string metadataType =
            GetTupleItemMetadataType(
                tupleItemDataType,
                tupleItemType,
                tupleItem.ForeignCollectionName != null);

        writer.WriteLine(
            $"{indentation}        new {metadataType}(" +
            $"\"{Escape(tupleItem.Name)}\")");

        writer.WriteLine(
            $"{indentation}        {{");

        if (tupleItem.ForeignCollectionName != null)
        {
            writer.WriteLine(
                $"{indentation}            ForeignCollectionName = " +
                $"\"{Escape(tupleItem.ForeignCollectionName)}\",");

            if (tupleItem.Inline)
            {
                writer.WriteLine(
                    $"{indentation}            Inline = " +
                    $"{tupleItem.Inline.ToString().ToLowerInvariant()},");
            }
        }

        if (tupleItem.Summary != null)
        {
            writer.WriteLine(
                $"{indentation}            Description = " +
                $"\"{Escape(tupleItem.Summary)}\",");
        }

        writer.WriteLine(
            $"{indentation}            LabelIfNullable = " +
            $"{(DataTypeIsNullable(tupleItemDataType) ? "\"Null\"" : "null")},");

        if (tupleItem.Title != null)
        {
            writer.WriteLine(
                $"{indentation}            Title = " +
                $"\"{Escape(tupleItem.Title)}\",");
        }

        writer.WriteLine(
            $"{indentation}            CategoryTitle = \"\",");

        writer.WriteLine(
            $"{indentation}        }},");    }

    writer.WriteLine(
        $"{indentation}    }},");    }

static string GetTupleItemMetadataType(
    string dataType,
    Type propertyType,
    bool isForeignKey)
{
    if (isForeignKey)
    {
        return nameof(ForeignKeyPropertyMetadata);
    }

    string normalizedType =
        RemoveNullableAndArraySuffixes(dataType);

    return normalizedType switch
    {
        "bool" => nameof(BooleanPropertyMetadata),
        "char" => nameof(CharacterPropertyMetadata),
        "int" => nameof(IntegerPropertyMetadata),
        "string" => nameof(StringPropertyMetadata),
        _ when propertyType.IsEnum => nameof(EnumPropertyMetadata),
        _ => throw new InvalidOperationException(
            $"The tuple data type '{dataType}' is not supported.")
    };
}

static string[] GetTupleElementDataTypes(string dataType)
{
    string tupleDataType =
        RemoveNullableAndArraySuffixes(dataType).Trim();

    if (!tupleDataType.StartsWith("(") ||
        !tupleDataType.EndsWith(")"))
    {
        throw new InvalidOperationException(
            $"The data type '{dataType}' is not a tuple type.");
    }

    tupleDataType =
        tupleDataType[1..^1];

    List<string> elementDataTypes = new();
    int nestingDepth = 0;
    int elementStart = 0;

    for (int index = 0; index < tupleDataType.Length; index++)
    {
        char character = tupleDataType[index];

        if (character is '<' or '(' or '[')
        {
            nestingDepth++;
        }
        else if (character is '>' or ')' or ']')
        {
            nestingDepth--;
        }
        else if (character == ',' && nestingDepth == 0)
        {
            elementDataTypes.Add(
                tupleDataType[elementStart..index].Trim());

            elementStart = index + 1;
        }
    }

    elementDataTypes.Add(
        tupleDataType[elementStart..].Trim());

    return elementDataTypes
        .Select(RemoveTupleElementName)
        .ToArray();
}

static string RemoveTupleElementName(string elementDataType)
{
    int separatorIndex =
        elementDataType.LastIndexOf(' ');

    if (separatorIndex < 0)
    {
        return elementDataType;
    }

    string possibleName =
        elementDataType[(separatorIndex + 1)..];

    return possibleName.All(
        character =>
            char.IsLetterOrDigit(character) ||
            character == '_')
        ? elementDataType[..separatorIndex].TrimEnd()
        : elementDataType;
}