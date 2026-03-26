// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AngbandOS.Core;

internal class GameStateBag
{
    private readonly Dictionary<string, object?> DataDictionary = new();
    private readonly Dictionary<object, int> _objectToId;

#if DEBUG
    private readonly HashSet<object> _seenNonGameObjects = new HashSet<object>(ReferenceEqualityComparer.Instance);
#endif
    public GameStateBag(Dictionary<object, int> objectToId)
    {
        _objectToId = objectToId;
    }

    public GameStateBag()
    {
        _objectToId = new Dictionary<object, int>(ReferenceEqualityComparer.Instance);
    }

    private string DelimitIf(string prefix, string delimiter, string suffix)
    {
        return !String.IsNullOrEmpty(prefix) && !String.IsNullOrEmpty(suffix) ? $"{prefix}{delimiter}{suffix}" : $"{prefix}{suffix}";
    }

    public object? Serialize(object? value, string parent = "")
    {
        // Handle null values.
        if (value == null)
        {
            return value;
        }

        Type type = value.GetType();

        // Primitive data types
        if (type.IsPrimitive || value is string || value is decimal || type.IsEnum || type == typeof(DateTime) || type == typeof(TimeSpan))
        {
            return value;
        }

        // Object identity--game objects only
        if (type.Assembly == GetType().Assembly)
        {
            // already seen?
            if (_objectToId.TryGetValue(value, out int existingId))
            {
                return new Dictionary<string, object?>
                {
                    ["$type"] = "ref",
                    ["$ref"] = existingId
                };
            }

            // first time seeing this object
            int id = _objectToId.Count + 1;
            _objectToId[value] = id;

            // Retrieve all of the fields to be preserved.  We exclude property backing fields and fields marked as [NonSerialized].
            IEnumerable<FieldInfo> serializableFields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Where(p => !p.IsDefined(typeof(CompilerGeneratedAttribute), true) && !System.Attribute.IsDefined(p, typeof(NonSerializedAttribute)));
            var objectValue = new Dictionary<string, object?>();

            foreach (FieldInfo propertyInfo in serializableFields)
            {
                // Get the key and value and type of the field.
                string key = propertyInfo.Name;
                object? fieldValue = propertyInfo.GetValue(value);
                objectValue[key] = Serialize(fieldValue, DelimitIf(parent, ".", $"{type.Name}.{key}"));
            }

            return new Dictionary<string, object?>
            {
                ["$type"] = "object",
                ["$id"] = id,
                ["$basetype"] = type.Name,
                ["$value"] = objectValue
            };
        }

        // Detect shared references for non-game objects in debug mode only.
#if DEBUG
        if (!type.IsValueType && type.Assembly != GetType().Assembly)
        {
            if (!_seenNonGameObjects.Add(value))
            {
                throw new Exception($"Shared reference detected for non-game type: {DelimitIf(parent, ".", type.Name)} is not supported.");
            }
        }
#endif

        // Dictionaries
        if (value is IDictionary dictionary)
        {
            var result = new Dictionary<string, object?>();

            foreach (DictionaryEntry entry in dictionary)
            {
                string key = entry.Key.ToString()!; // Dictionary keys can never be null.
                result[key] = Serialize(entry.Value, DelimitIf(parent, ".", key));
            }

            return result;
        }

        // Tuples
        if (type.Name.StartsWith("System.ValueTuple") || type.Name.StartsWith("System.Tuple"))
        {
            var values = new List<object?>();

            var fields = type.GetFields();

            foreach (var field in fields)
            {
                values.Add(Serialize(field.GetValue(value), DelimitIf(parent, ".", field.Name)));
            }

            return new Dictionary<string, object?>
            {
                ["$type"] = "tuple",
                ["$basetype"] = type.Name,
                ["$values"] = values
            };
        }
        
        // Collections
        if (value is IEnumerable enumerable && value is not string)
        {
            var list = new List<object?>();

            int index = 0;
            foreach (var item in enumerable)
            {
                list.Add(Serialize(item, $"{parent}[{index}]"));
                index++;
            }

            return list;
        }

        throw new Exception($"{type.Name} serialization not supported on field {parent}.");
    }

    public void Deserialize(object entity)
    {
        IEnumerable<FieldInfo> serializableFields = entity.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Where(p => !System.Attribute.IsDefined(p, typeof(NonSerializedAttribute)));

        foreach (FieldInfo fieldInfo in serializableFields)
        {
            if (DataDictionary.TryGetValue(fieldInfo.Name, out object? value))
            {
                fieldInfo.SetValue(entity, value);
            }
            else
            {
                throw new Exception("Invalid game state.");
            }
        }
    }
}
