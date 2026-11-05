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
    WriteMetadataClassFile(outputFolder, configurationType, enumTypes);
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

        ConfigurationPropertyAttribute? metadata = property.GetCustomAttribute<ConfigurationPropertyAttribute>();

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

static void WriteMetadataClassFile(string outputFolder, Type configurationType, IReadOnlyCollection<Type> enumTypes)
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

    string indentation = new(' ', 4 * 4);

    foreach (PropertyInfo property in GetConfigurationProperties(configurationType))
    {
        // We use the property name from reflection but that is it.
        string propertyName = property.Name;

        // Retrieve the ConfigurationPropertyAttribute metadata for the property.
        ConfigurationPropertyAttribute? configurationPropertyAttribute = property.GetCustomAttribute<ConfigurationPropertyAttribute>();

        if (configurationPropertyAttribute is null)
        {
            Console.Error.WriteLine($"Property '{configurationType.FullName}.{propertyName}' is missing ConfigurationMetadataAttribute.");
            Environment.Exit(1);
        }

        // There are additional annotations we need to check.
        ConfigurationCollectionAttribute? configurationCollectionAttribute = property.GetCustomAttribute<ConfigurationCollectionAttribute>();
        ConfigurationForeignKeyAttribute? configurationForeignCollectionAttribute = property.GetCustomAttribute<ConfigurationForeignKeyAttribute>();

        // Retrieve the annotated data type.
        string? annotatedDataType = configurationPropertyAttribute.DataType?.Trim();
        if (annotatedDataType is null)
        {
            Console.Error.WriteLine($"The property '{configurationType.Name}.{propertyName}' has no DataType.");
            Environment.Exit(1);
        }

        string metadataType = GetMetadataType(annotatedDataType, propertyName, configurationForeignCollectionAttribute, configurationCollectionAttribute);
        writer.WriteLine($"{indentation}new {metadataType}(\"{Escape(propertyName)}\")");
        writer.WriteLine($"{indentation}{{");

        if (configurationForeignCollectionAttribute is not null)
        {
            writer.WriteLine($"{indentation}    ForeignCollectionName = \"{Escape(configurationForeignCollectionAttribute.CollectionName)}\",");
            writer.WriteLine($"{indentation}    Inline = {configurationForeignCollectionAttribute.Inline.ToString().ToLowerInvariant()},");
        }

        if (metadataType == nameof(CollectionPropertyMetadata) && configurationCollectionAttribute != null)
        {
            string elementDataType = annotatedDataType.Trim().TrimEnd('?');

            if (!elementDataType.EndsWith("[]", StringComparison.Ordinal))
            {
                Console.Error.WriteLine($"DataType '{annotatedDataType}' is not an array.");
                Environment.Exit(1);
            }

            elementDataType = elementDataType[..^2].Trim();
            Type elementType = GetAnnotatedType(elementDataType);

            string childMetadataClassName = GetMetadataClassName(elementType);

            writer.WriteLine($"{indentation}    PropertyMetadatas = {childMetadataClassName}.Metadata,");
            writer.WriteLine($"{indentation}    ForeignCollectionName = \"{Escape(configurationCollectionAttribute.CollectionName)}\",");
            writer.WriteLine($"{indentation}    EntityNoun = \"{Escape(configurationCollectionAttribute.EntityNoun ?? string.Empty)}\",");
            writer.WriteLine($"{indentation}    EntityKeyPropertyName = \"GetKey\",");
            writer.WriteLine($"{indentation}    EntityNamePropertyName = \"{Escape(configurationCollectionAttribute.EntityNamePropertyName ?? "GetKey")}\",");
        }

        writer.WriteLine($"{indentation}    Description = \"{Escape(configurationPropertyAttribute.Summary ?? string.Empty)}\",");
        writer.WriteLine($"{indentation}    LabelIfNullable = {(DataTypeIsNullable(annotatedDataType) ? $"\"{Escape(configurationPropertyAttribute.LabelIfNullable ?? "Default")}\"" : "null")},");

        if (configurationPropertyAttribute.Title is not null)
        {
            writer.WriteLine($"{indentation}    Title = \"{Escape(configurationPropertyAttribute.Title)}\",");
        }

        ConfigurationCategoryAttribute? propertyCategory = property.GetCustomAttribute<ConfigurationCategoryAttribute>();

        writer.WriteLine($"{indentation}    CategoryTitle = \"{Escape(propertyCategory?.Title ?? string.Empty)}\",");

        if (metadataType == nameof(EnumPropertyMetadata))
        {
            Type enumType = GetAnnotatedType(annotatedDataType);
            writer.WriteLine($"{indentation}    EnumName = \"{Escape(enumType.Name)}\",");
        }

        if (metadataType == nameof(TuplePropertyMetadata))
        {
            string[] tupleElementDataTypes = GetTupleElementDataTypes(annotatedDataType);
            ConfigurationTupleItemAttribute[] tupleItems = property.GetCustomAttributes<ConfigurationTupleItemAttribute>().ToArray();

            if (tupleItems.Length != tupleElementDataTypes.Length)
            {
                Console.Error.WriteLine($"Property '{configurationType.Name}.{propertyName}' must have one ConfigurationTupleItemAttribute for each tuple element.");
                Environment.Exit(1);
            }

            writer.WriteLine($"{indentation}    Types = new PropertyMetadata[]");
            writer.WriteLine($"{indentation}    {{");

            for (int index = 0; index < tupleItems.Length; index++)
            {
                ConfigurationTupleItemAttribute tupleItem = tupleItems[index];
                string tupleItemDataType = tupleElementDataTypes[index];

                Type tupleItemType = GetAnnotatedType(tupleItemDataType);

                string tupleMetadataType = GetTupleItemMetadataType(
                    tupleItemDataType,
                    tupleItemType,
                    tupleItem.ForeignCollectionName != null);

                writer.WriteLine($"{indentation}        new {tupleMetadataType}(\"{Escape(tupleItem.Name)}\")");
                writer.WriteLine($"{indentation}        {{");

                if (tupleItem.ForeignCollectionName != null)
                {
                    writer.WriteLine($"{indentation}            ForeignCollectionName = \"{Escape(tupleItem.ForeignCollectionName)}\",");

                    if (tupleItem.Inline)
                    {
                        writer.WriteLine($"{indentation}            Inline = {tupleItem.Inline.ToString().ToLowerInvariant()},");
                    }
                }

                if (tupleItem.Summary != null)
                {
                    writer.WriteLine($"{indentation}            Description = \"{Escape(tupleItem.Summary)}\",");
                }

                writer.WriteLine($"{indentation}            LabelIfNullable = {(DataTypeIsNullable(tupleItemDataType) ? "\"Null\"" : "null")},");

                if (tupleItem.Title != null)
                {
                    writer.WriteLine($"{indentation}            Title = \"{Escape(tupleItem.Title)}\",");
                }

                writer.WriteLine($"{indentation}            CategoryTitle = \"\",");
                writer.WriteLine($"{indentation}        }},");
            }

            writer.WriteLine($"{indentation}    }},");
        }

        writer.WriteLine($"{indentation}}},");
    }

    writer.WriteLine($"            }};");
    writer.WriteLine($"        }}");
    writer.WriteLine($"    }}");
    writer.WriteLine($"}}");
}

static Type GetAnnotatedType(string annotatedDataType)
{
    string typeName = annotatedDataType.Trim();

    // Remove nullable and array annotations.
    while (true)
    {
        if (typeName.EndsWith("?", StringComparison.Ordinal))
        {
            typeName = typeName[..^1].Trim();
        }
        else if (typeName.EndsWith("[]", StringComparison.Ordinal))
        {
            typeName = typeName[..^2].Trim();
        }
        else
        {
            break;
        }
    }

    Type? type = typeName switch
    {
        "bool" => typeof(bool),
        "byte" => typeof(byte),
        "sbyte" => typeof(sbyte),
        "short" => typeof(short),
        "ushort" => typeof(ushort),
        "int" => typeof(int),
        "uint" => typeof(uint),
        "long" => typeof(long),
        "ulong" => typeof(ulong),
        "float" => typeof(float),
        "double" => typeof(double),
        "decimal" => typeof(decimal),
        "char" => typeof(char),
        "string" => typeof(string),
        "object" => typeof(object),
        _ => null
    };

    if (type is not null)
    {
        return type;
    }

    type = Type.GetType(typeName, false, true);

    if (type is not null)
    {
        return type;
    }

    foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
    {
        type = assembly.GetType(typeName, false, true);

        if (type is not null)
        {
            return type;
        }

        type = assembly.GetTypes().FirstOrDefault(t => string.Equals(t.Name, typeName, StringComparison.Ordinal));

        if (type is not null)
        {
            return type;
        }
    }

    throw new Exception($"Unable to resolve annotated DataType '{annotatedDataType}'.");
}

static void WriteEnumMetadata(StreamWriter writer, IReadOnlyCollection<Type> enumTypes)
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

static string GetMetadataType(string annotatedDataType, string propertyName, ConfigurationForeignKeyAttribute? configurationForeignCollectionAttribute, ConfigurationCollectionAttribute? configurationCollectionAttribute)
{
    if (IsTuple(annotatedDataType))
    {
        return nameof(TuplePropertyMetadata);
    }

    if (configurationForeignCollectionAttribute != null)
    {
        return IsStringArray(annotatedDataType) ? nameof(ForeignKeysPropertyMetadata) : nameof(ForeignKeyPropertyMetadata);
    }

    if (configurationCollectionAttribute != null)
    {
        return nameof(CollectionPropertyMetadata);
    }

    string normalizedType = RemoveNullableAndArraySuffixes(annotatedDataType);

    return normalizedType switch
    {
        "bool" => nameof(BooleanPropertyMetadata),
        "char" => nameof(CharacterPropertyMetadata),
        "int" => nameof(IntegerPropertyMetadata),
        "string" when IsArray(annotatedDataType) => nameof(StringsPropertyMetadata),
        "string" => nameof(StringPropertyMetadata),
        "ColorEnum" => nameof(ColorPropertyMetadata),
        _ when normalizedType.EndsWith("Enum", StringComparison.Ordinal) => nameof(EnumPropertyMetadata),
        _ => throw new InvalidOperationException(
            $"The data type '{annotatedDataType}' is not supported for property '{propertyName}'.")
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
    return RemoveNullableAndArraySuffixes(dataType).TrimStart() .StartsWith("(");
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
    return value.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\r", "\\r").Replace("\n", "\\n");
}

static Type? GetEnumType(Type propertyType)
{
    Type unwrappedType = Nullable.GetUnderlyingType(propertyType) ?? propertyType;
    return unwrappedType.IsEnum ? unwrappedType : null;
}

static bool IsStringArray(string dataType)
{
    return IsArray(dataType) && RemoveNullableAndArraySuffixes(dataType).Equals("string", StringComparison.Ordinal);
}

static string GetTupleItemMetadataType(string dataType, Type propertyType, bool isForeignKey)
{
    if (isForeignKey)
    {
        return nameof(ForeignKeyPropertyMetadata);
    }

    string normalizedType = RemoveNullableAndArraySuffixes(dataType);

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
    string tupleDataType = RemoveNullableAndArraySuffixes(dataType).Trim();

    if (!tupleDataType.StartsWith("(") || !tupleDataType.EndsWith(")"))
    {
        Console.Error.WriteLine($"The data type '{dataType}' is not a tuple type.");
        Environment.Exit(1);
    }

    tupleDataType = tupleDataType[1..^1];
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
            elementDataTypes.Add(tupleDataType[elementStart..index].Trim());
            elementStart = index + 1;
        }
    }

    elementDataTypes.Add(tupleDataType[elementStart..].Trim());

    return elementDataTypes.Select(RemoveTupleElementName).ToArray();
}

static string RemoveTupleElementName(string elementDataType)
{
    int separatorIndex = elementDataType.LastIndexOf(' ');

    if (separatorIndex < 0)
    {
        return elementDataType;
    }

    string possibleName = elementDataType[(separatorIndex + 1)..];

    if (possibleName.All(character => char.IsLetterOrDigit(character) || character == '_'))
    {
        return elementDataType[..separatorIndex].TrimEnd();
    }
    else
    {
        return elementDataType;
    }
}