// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Reflection;

namespace AngbandOS.Core;

internal class GameStateBag
{
    private readonly Dictionary<string, object?> _data = new();

    public void Set<T>(string key, T value)
    {
        _data[key] = value;
    }

    public T Get<T>(string key, T defaultValue = default!)
    {
        if (_data.TryGetValue(key, out var value) && value is T typed)
            return typed;

        return defaultValue;
    }

    /// <summary>
    /// Enumerates the fields in the provided by the <paramref name="entity"/> parameter that are marked with the <see cref="nameof(GameSerializable)"/> attribute and automatically stores the value in the bag.
    /// </summary>
    /// <param name="entity"></param>
    public void Serialize(object entity)
    {
        IEnumerable<FieldInfo> gameSerializableFields = entity.GetType().GetFields().Where(p => System.Attribute.IsDefined(p, typeof(GameSerializableAttribute)));

        foreach (FieldInfo propertyInfo in gameSerializableFields)
        {
            object? value = propertyInfo.GetValue(entity);
            Set(propertyInfo.Name, value);
        }
    }

    public void Deserialize(object entity)
    {
        IEnumerable<PropertyInfo> gameSerializableProperties = entity.GetType().GetProperties().Where(p => System.Attribute.IsDefined(p, typeof(GameSerializableAttribute)));

        foreach (PropertyInfo propertyInfo in gameSerializableProperties)
        {
            var attr = propertyInfo.GetCustomAttributes(typeof(GameSerializableAttribute), false).First() as GameSerializableAttribute;
            if (_data.TryGetValue(propertyInfo.Name, out object value))
            {
                propertyInfo.SetValue(entity, value);
            }
            else
            {
                throw new Exception("Invalid game state.");
            }
        }
    }
}
