// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Text;

namespace AngbandOS.Core;

internal class SummationEffectiveAttributeValue : EffectiveAttributeValue
{
    /// <summary>
    /// Represents the modifiers that are combined to create the effective value.
    /// </summary>
    protected readonly List<(string Key, int Modifier)> _attributeModifiers = new List<(string, int)>();
    public SummationEffectiveAttributeValue(Game game, Attribute attribute) : base(game, attribute) { }
    public SummationEffectiveAttributeValue(Game game, RestoreGameState restoreGameState) : base(game, restoreGameState)
    {
        (string, int)[] modifiers = restoreGameState.GetByKey(nameof(_attributeModifiers)).GetTuples<string, int>(
            _restoreGameState => _restoreGameState.GetString(), 
            _restoreGameState => _restoreGameState.GetInt());
        _attributeModifiers.AddRange(modifiers);
    }
    public override DictionaryGameStateBag? Serialize(SaveGameState saveGameState)
    {
        return new DictionaryGameStateBag(base.Serialize(saveGameState),
            (nameof(_attributeModifiers), saveGameState.CreateTuplesGameStateBag<string, int>(_attributeModifiers.ToArray(), _key => saveGameState.CreateGameStateBag(_key), _modifier => saveGameState.CreateGameStateBag(_modifier)))
        );
    }
    public override EffectiveAttributeValue Clone()
    {
        SummationEffectiveAttributeValue clone = new SummationEffectiveAttributeValue(Game, Attribute);
        clone._attributeModifiers.AddRange(_attributeModifiers);
        return (EffectiveAttributeValue)clone;
    }
    public override string[] RenderForItemIdentification => new string[] { Get().ToString() };
    public override ReadOnlyAttributeValue ToReadOnly() => new IntReadOnlyAttributeValue(Get());

    public override bool HasKeyedItemEnhancements(string key)
    {
        foreach ((string itemKey, int modifier) in _attributeModifiers)
        {
            if (itemKey == key)
            {
                return true;
            }
        }
        return false;
    }

    public int Get()
    {
        int value = 0;
        foreach ((string Key, int Modifier) in _attributeModifiers)
        {
            value = value + Modifier;
        }
        return value;
    }

    public int Get(string key)
    {
        int value = 0;
        foreach ((string Key, int Modifier) in _attributeModifiers)
        {
            if (Key == key)
            {
                value = value + Modifier;
            }
        }
        return value;
    }

    public override void Merge(AttributeValue value)
    {
        IntReadOnlyAttributeValue additionEffectiveAttributeValue = (IntReadOnlyAttributeValue)value;
        _attributeModifiers.Add(("", additionEffectiveAttributeValue.Value));
    }

    public override void Merge(string key, AttributeValue value)
    {
        if (String.IsNullOrEmpty(key))
        {
            throw new ArgumentException("Invalid key specified for enhancements.");
        }
        IntReadOnlyAttributeValue additionEffectiveAttributeValue = (IntReadOnlyAttributeValue)value;
        _attributeModifiers.Add((key, additionEffectiveAttributeValue.Value));
    }

    public override void RemoveModifiers(string key)
    {
        if (String.IsNullOrEmpty(key))
        {
            throw new Exception($"Cannot specify a blank or null key for {nameof(RemoveModifiers)}");
        }
        _attributeModifiers.RemoveAll((item) => item.Key == key);
    }

    /// <summary>
    /// Appends a modifier to the effective value.
    /// </summary>
    /// <param name="value"></param>
    public void Append(int value)
    {
        _attributeModifiers.Add(("", value));
    }

    /// <summary>
    /// Removes all of the modifiers from the effective value, effectively resetting it to 0.
    /// </summary>
    /// <param name="value"></param>
    public void Reset()
    {
        _attributeModifiers.Clear();
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append($"{Attribute.Key}: ");
        string delimiter = "";
        foreach ((string key, int modifier) in _attributeModifiers)
        {
            stringBuilder.Append(delimiter);
            delimiter = "; ";
            if (key != "")
            {
                stringBuilder.Append($"{key}: ");
            }
            stringBuilder.Append($"{modifier}");
        }
        return stringBuilder.ToString();
    }
}
