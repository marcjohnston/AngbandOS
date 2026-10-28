//using System.Reflection;
//using AngbandOS.Core.Interface.Configuration;
//using AngbandOS.Core.Interface.Configuration.Annotations;

//namespace AngbandOS.ConfigurationMetadataGenerator;

//internal sealed class MetadataGenerator
//{
//    private readonly Assembly _assembly;
//    private readonly List<string> _errors = [];

//    private readonly Dictionary<string, Type> _entityTypes =
//        new(StringComparer.Ordinal);

//    public MetadataGenerator(Assembly assembly)
//    {
//        _assembly = assembly;
//    }

//    public ConfigurationDocument Generate()
//    {
//        Type[] types =
//            _assembly
//                .GetTypes()
//                .Where(IsConfigurationType)
//                .OrderBy(x => x.Name, StringComparer.Ordinal)
//                .ToArray();

//        BuildEntityIndex(types);

//        List<ConfigurationClassMetadata> classes = [];

//        foreach (Type type in types)
//        {
//            ConfigurationClassMetadata? metadata =
//                GenerateClass(type);

//            if (metadata != null)
//            {
//                classes.Add(metadata);
//            }
//        }

//        if (_errors.Count > 0)
//        {
//            throw new MetadataGenerationException(_errors);
//        }

//        return new ConfigurationDocument
//        {
//            Classes = classes
//        };
//    }

//    private bool IsConfigurationType(Type type)
//    {
//        if (!type.IsClass)
//            return false;

//        if (type.IsAbstract)
//            return false;

//        return typeof(NonCompositeSingletonGameConfiguration)
//            .IsAssignableFrom(type);
//    }

//    private void BuildEntityIndex(IEnumerable<Type> types)
//    {
//        foreach (Type type in types)
//        {
//            ConfigurationEntityAttribute? entity =
//                type.GetCustomAttribute<ConfigurationEntityAttribute>(
//                    inherit: true);

//            if (entity == null)
//            {
//                AddError(
//                    type,
//                    "ConfigurationEntityAttribute is missing.");

//                continue;
//            }

//            if (string.IsNullOrWhiteSpace(entity.Title))
//            {
//                AddError(
//                    type,
//                    "ConfigurationEntityAttribute.Title is required.");
//            }

//            if (string.IsNullOrWhiteSpace(entity.EntityNoun))
//            {
//                AddError(
//                    type,
//                    "ConfigurationEntityAttribute.EntityNoun is required.");
//            }

//            if (!string.IsNullOrWhiteSpace(entity.Title))
//            {
//                if (!_entityTypes.TryAdd(entity.Title, type))
//                {
//                    Type existingType = _entityTypes[entity.Title];

//                    AddError(
//                        type,
//                        $"ConfigurationEntity title '{entity.Title}' is already " +
//                        $"used by '{existingType.FullName}'.");
//                }
//            }
//        }
//    }

//    private ConfigurationClassMetadata? GenerateClass(Type type)
//    {
//        ConfigurationEntityAttribute? entity =
//            type.GetCustomAttribute<ConfigurationEntityAttribute>(
//                inherit: true);

//        if (entity == null)
//            return null;

//        ConfigurationClassMetadata result = new()
//        {
//            Name = type.Name,
//            Title = entity.Title,
//            EntityNoun = entity.EntityNoun
//        };

//        PropertyInfo[] properties =
//            type.GetProperties(
//                BindingFlags.Instance |
//                BindingFlags.Public);

//        foreach (PropertyInfo property in properties
//            .OrderBy(x => x.MetadataToken))
//        {
//            ConfigurationPropertyMetadata? propertyMetadata =
//                GenerateProperty(type, property);

//            if (propertyMetadata != null)
//            {
//                result.Properties.Add(propertyMetadata);
//            }
//        }

//        return result;
//    }

//    private ConfigurationPropertyMetadata? GenerateProperty(
//        Type declaringType,
//        PropertyInfo property)
//    {
//        ConfigurationMetadataAttribute? metadata =
//            property.GetCustomAttribute<ConfigurationMetadataAttribute>(
//                inherit: true);

//        ConfigurationCategoryAttribute? category =
//            property.GetCustomAttribute<ConfigurationCategoryAttribute>(
//                inherit: true);

//        ForeignCollectionAttribute? foreignCollection =
//            property.GetCustomAttribute<ForeignCollectionAttribute>(
//                inherit: true);

//        ConfigurationTupleItemAttribute[] tupleItems =
//            property.GetCustomAttributes<ConfigurationTupleItemAttribute>(
//                inherit: true)
//            .ToArray();

//        if (metadata == null)
//        {
//            AddError(
//                declaringType,
//                property,
//                "ConfigurationMetadataAttribute is missing.");

//            return null;
//        }

//        if (string.IsNullOrWhiteSpace(metadata.DataType))
//        {
//            AddError(
//                declaringType,
//                property,
//                "ConfigurationMetadataAttribute.DataType is required.");
//        }

//        if (foreignCollection != null)
//        {
//            ValidateForeignCollection(
//                declaringType,
//                property,
//                foreignCollection);
//        }

//        TupleInfo? tuple =
//            TryParseTuple(metadata.DataType);

//        if (tuple != null)
//        {
//            ValidateTuple(
//                declaringType,
//                property,
//                tuple,
//                tupleItems);
//        }
//        else if (tupleItems.Length > 0)
//        {
//            AddError(
//                declaringType,
//                property,
//                "ConfigurationTupleItemAttribute was specified, but " +
//                "DataType does not contain a tuple.");
//        }

//        ConfigurationPropertyMetadata result = new()
//        {
//            Name = property.Name,
//            Title = metadata.Title,
//            Summary = metadata.Summary,
//            DataType = metadata.DataType,
//            Category = category?.Title,
//            ForeignCollectionName =
//                foreignCollection?.CollectionName,
//            Inline = foreignCollection?.Inline
//        };

//        foreach (ConfigurationTupleItemAttribute tupleItem in
//            tupleItems.OrderBy(x => x.Name, StringComparer.Ordinal))
//        {
//            result.TupleItems.Add(
//                new ConfigurationTupleItemMetadata
//                {
//                    Name = tupleItem.Name,
//                    Title = tupleItem.Title,
//                    Summary = tupleItem.Summary,
//                    ForeignCollectionName =
//                        tupleItem.ForeignCollectionName
//                });
//        }

//        return result;
//    }

//    private void ValidateForeignCollection(
//        Type declaringType,
//        PropertyInfo property,
//        ForeignCollectionAttribute foreignCollection)
//    {
//        string collectionName =
//            foreignCollection.CollectionName;

//        if (!_entityTypes.TryGetValue(
//            collectionName,
//            out Type? entityType))
//        {
//            AddError(
//                declaringType,
//                property,
//                $"Foreign collection '{collectionName}' does not " +
//                $"have a corresponding ConfigurationEntity.");

//            return;
//        }

//        ConfigurationEntityAttribute? entity =
//            entityType.GetCustomAttribute<ConfigurationEntityAttribute>(
//                inherit: true);

//        if (entity == null)
//        {
//            AddError(
//                declaringType,
//                property,
//                $"Foreign collection '{collectionName}' resolves to " +
//                $"'{entityType.FullName}', but that class does not have " +
//                $"ConfigurationEntityAttribute.");

//            return;
//        }

//        if (string.IsNullOrWhiteSpace(entity.Title))
//        {
//            AddError(
//                declaringType,
//                property,
//                $"Foreign collection '{collectionName}' resolves to " +
//                $"'{entityType.FullName}', but ConfigurationEntity.Title " +
//                $"is missing.");
//        }

//        if (string.IsNullOrWhiteSpace(entity.EntityNoun))
//        {
//            AddError(
//                declaringType,
//                property,
//                $"Foreign collection '{collectionName}' resolves to " +
//                $"'{entityType.FullName}', but ConfigurationEntity.EntityNoun " +
//                $"is missing.");
//        }
//    }

//    private void ValidateTuple(
//        Type declaringType,
//        PropertyInfo property,
//        TupleInfo tuple,
//        ConfigurationTupleItemAttribute[] attributes)
//    {
//        HashSet<string> tupleNames =
//            tuple.Items
//                .Select(x => x.Name)
//                .ToHashSet(StringComparer.Ordinal);

//        HashSet<string> attributeNames =
//            attributes
//                .Select(x => x.Name)
//                .ToHashSet(StringComparer.Ordinal);

//        foreach (string tupleName in tupleNames)
//        {
//            if (!attributeNames.Contains(tupleName))
//            {
//                AddError(
//                    declaringType,
//                    property,
//                    $"Tuple item '{tupleName}' is missing " +
//                    $"ConfigurationTupleItemAttribute.");
//            }
//        }

//        foreach (string attributeName in attributeNames)
//        {
//            if (!tupleNames.Contains(attributeName))
//            {
//                AddError(
//                    declaringType,
//                    property,
//                    $"ConfigurationTupleItemAttribute '{attributeName}' " +
//                    $"does not correspond to a tuple item in DataType.");
//            }
//        }
//    }

//    private static TupleInfo? TryParseTuple(string? dataType)
//    {
//        if (string.IsNullOrWhiteSpace(dataType))
//            return null;

//        string type =
//            dataType.Trim();

//        // Remove nullable/array suffixes until we reach
//        // the underlying tuple declaration.
//        while (type.EndsWith("?", StringComparison.Ordinal) ||
//               type.EndsWith("[]", StringComparison.Ordinal))
//        {
//            if (type.EndsWith("[]", StringComparison.Ordinal))
//            {
//                type = type[..^2].Trim();
//            }
//            else
//            {
//                type = type[..^1].Trim();
//            }
//        }

//        if (!type.StartsWith("(") ||
//            !type.EndsWith(")"))
//        {
//            return null;
//        }

//        string contents =
//            type[1..^1];

//        List<string> parts =
//            SplitTopLevel(contents, ',');

//        List<TupleItemInfo> items = [];

//        foreach (string part in parts)
//        {
//            string item =
//                part.Trim();

//            if (item.Length == 0)
//                continue;

//            string? name =
//                GetTupleItemName(item);

//            if (name == null)
//            {
//                // A tuple without named elements cannot be associated
//                // with ConfigurationTupleItem metadata.
//                return new TupleInfo(items);
//            }

//            items.Add(
//                new TupleItemInfo(name));
//        }

//        return new TupleInfo(items);
//    }

//    private static string? GetTupleItemName(string item)
//    {
//        int squareDepth = 0;
//        int angleDepth = 0;
//        int parenDepth = 0;

//        for (int i = item.Length - 1; i >= 0; i--)
//        {
//            char character = item[i];

//            switch (character)
//            {
//                case ']':
//                    squareDepth++;
//                    break;

//                case '[':
//                    squareDepth--;
//                    break;

//                case '>':
//                    angleDepth++;
//                    break;

//                case '<':
//                    angleDepth--;
//                    break;

//                case ')':
//                    parenDepth++;
//                    break;

//                case '(':
//                    parenDepth--;
//                    break;

//                case ' ' when
//                    squareDepth == 0 &&
//                    angleDepth == 0 &&
//                    parenDepth == 0:

//                    string candidate =
//                        item[(i + 1)..].Trim();

//                    if (IsIdentifier(candidate))
//                        return candidate;

//                    break;
//            }
//        }

//        return null;
//    }

//    private static bool IsIdentifier(string value)
//    {
//        if (string.IsNullOrWhiteSpace(value))
//            return false;

//        if (!char.IsLetter(value[0]) &&
//            value[0] != '_')
//        {
//            return false;
//        }

//        for (int i = 1; i < value.Length; i++)
//        {
//            if (!char.IsLetterOrDigit(value[i]) &&
//                value[i] != '_')
//            {
//                return false;
//            }
//        }

//        return true;
//    }

//    private static List<string> SplitTopLevel(
//        string value,
//        char separator)
//    {
//        List<string> result = [];

//        int start = 0;
//        int parenthesisDepth = 0;
//        int squareDepth = 0;
//        int angleDepth = 0;

//        for (int i = 0; i < value.Length; i++)
//        {
//            switch (value[i])
//            {
//                case '(':
//                    parenthesisDepth++;
//                    break;

//                case ')':
//                    parenthesisDepth--;
//                    break;

//                case '[':
//                    squareDepth++;
//                    break;

//                case ']':
//                    squareDepth--;
//                    break;

//                case '<':
//                    angleDepth++;
//                    break;

//                case '>':
//                    angleDepth--;
//                    break;

//                default:
//                    if (value[i] == separator &&
//                        parenthesisDepth == 0 &&
//                        squareDepth == 0 &&
//                        angleDepth == 0)
//                    {
//                        result.Add(
//                            value[start..i].Trim());

//                        start = i + 1;
//                    }

//                    break;
//            }
//        }

//        result.Add(
//            value[start..].Trim());

//        return result;
//    }

//    private void AddError(Type type, string message)
//    {
//        _errors.Add(
//            $"{type.FullName}: {message}");
//    }

//    private void AddError(
//        Type type,
//        PropertyInfo property,
//        string message)
//    {
//        _errors.Add(
//            $"{type.FullName}.{property.Name}: {message}");
//    }
//}
