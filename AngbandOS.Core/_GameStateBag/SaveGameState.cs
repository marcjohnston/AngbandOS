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

internal class SaveGameState
{
    private Dictionary<object, int> ObjectToIdDictionary = new Dictionary<object, int>();

    public SaveGameState()
    {
    }

    public ObjectGameStateBag CreateObjectGameStateBag(object obj, DictionaryGameStateBag? dictionaryGameStateBag)
    {
        int objectId = ObjectToIdDictionary.Count + 1;
        ObjectToIdDictionary.Add(obj, objectId);
        return new ObjectGameStateBag(objectId, dictionaryGameStateBag?.Values);
    }
    public GameStateBag CreateDictionaryGameStateBag(params (string, GameStateBag)[] fieldNamesAndGameStateBags)
    {
        Dictionary<string, GameStateBag> fieldNameAndGameStateBagDictionary = fieldNamesAndGameStateBags.ToDictionary(_fieldNameAndGameStateBag => _fieldNameAndGameStateBag.Item1, _fieldNameAndGameStateBag => _fieldNameAndGameStateBag.Item2);
        return new DictionaryGameStateBag(fieldNameAndGameStateBagDictionary);
    }

    public static FieldInfo[] GetAllFields(Type? type)
    {
        List<FieldInfo> fieldInfoList = new List<FieldInfo>();
        while (type != null)
        {
            foreach (FieldInfo field in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                fieldInfoList.Add(field);
            }

            type = type.BaseType;
        }
        return fieldInfoList.ToArray();
    }

    /// <summary>
    /// Returns the state of a type.  The return object type is dependent on the type of data being serialized.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="_objectToId"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public GameStateBag SerializeViaReflection(object? value, string parent = "")
    {
        // Handle null values.
        if (value is null)
        {
            return new NullValueGameStateBag();
        }

        if (value is DateTime dateTimeValue)
        {
            return new DateTimeValueGameStateBag(dateTimeValue);
        }

        if (value is TimeSpan timeSpanValue)
        {
            return new TimeSpanValueGameStateBag(timeSpanValue);
        }

        if (value is string stringValue)
        {
            return new StringValueGameStateBag(stringValue);
        }

        if (value is byte byteValue)
        {
            return new ByteValueGameStateBag(byteValue);
        }

        if (value is char charValue)
        {
            return new CharValueGameStateBag(charValue);
        }

        if (value is decimal decimalValue)
        {
            return new DecimalValueGameStateBag(decimalValue);
        }

        if (value is int intValue)
        {
            return new IntValueGameStateBag(intValue);
        }

        if (value is bool boolValue)
        {
            return new BoolValueGameStateBag(boolValue);
        }

        if (value is ColorEnum colorEnumValue)
        {
            return new ColorEnumValueGameStateBag(colorEnumValue);
        }

        Type type = value.GetType();

        // Object identity--game objects only
        if (type.Assembly == typeof(GameStateBag).Assembly)
        {
            // already seen?
            if (ObjectToIdDictionary.TryGetValue(value, out int existingId))
            {
                return new ReferenceGameStateBag(existingId);
            }

            // This is the first time seeing this object, register it.
            int id = ObjectToIdDictionary.Count + 1;
            ObjectToIdDictionary.Add(value, id);

            // Retrieve all of the fields to be preserved.  We exclude property backing fields and fields marked as [NonSerialized].
            FieldInfo[] allFields = GetAllFields(type);
            IEnumerable<FieldInfo> serializableFields = allFields.Where(p => !p.IsDefined(typeof(CompilerGeneratedAttribute), true) && !System.Attribute.IsDefined(p, typeof(NonSerializedAttribute)));
            var objectValue = new Dictionary<string, GameStateBag>();

            foreach (FieldInfo childFieldInfo in serializableFields)
            {
                // Get the key and value and type of the field.
                string key = childFieldInfo.Name;
                object? fieldValue = childFieldInfo.GetValue(value);
                objectValue[key] = SerializeViaReflection(fieldValue, StringLibrary.DelimitIf(parent, ".", $"{type.Name}.{key}"));
            }

            return new ObjectGameStateBag(id, objectValue);
        }

        // Dictionaries
        if (value is IDictionary dictionary)
        {
            var result = new Dictionary<string, GameStateBag>();

            foreach (DictionaryEntry entry in dictionary)
            {
                string key = entry.Key.ToString()!; // Dictionary keys can never be null.
                result[key] = SerializeViaReflection(entry.Value, StringLibrary.DelimitIf(parent, ".", key));
            }

            return new DictionaryGameStateBag(result);
        }

        // Tuples
        if (type.Namespace == "System" && (type.Name.StartsWith("ValueTuple`") || type.Name.StartsWith("Tuple`")))
        {
            var values = new List<GameStateBag>();

            var fields = type.GetFields();

            foreach (var field in fields)
            {
                values.Add(SerializeViaReflection(field.GetValue(value), StringLibrary.DelimitIf(parent, ".", field.Name)));
            }

            return new TupleGameStateBag(type.Name, values.ToArray());
        }

        // Char[]
        if (value is char[] charArray)
        {
            return new CharArrayGameStateBag(charArray);
        }

        // Byte[]
        if (value is byte[] byteArray)
        {
            return new ByteArrayGameStateBag(byteArray);
        }


        // Queue<string>
        if (value is Queue<string> queueOfString)
        {
            return new QueueOfStringGameStateBag(queueOfString.ToArray());
        }

        // Collections
        if (value is IEnumerable enumerable && value is not string)
        {
            var list = new List<GameStateBag>();

            int index = 0;
            foreach (var item in enumerable)
            {
                list.Add(SerializeViaReflection(item, $"{parent}[{index}]"));
                index++;
            }

            return new ListGameStateBag(list.ToArray());
        }

        throw new Exception($"{type.Name} serialization not supported on field {parent}.");
    }
}
