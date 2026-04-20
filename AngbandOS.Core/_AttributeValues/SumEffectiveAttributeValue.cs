// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class SumEffectiveAttributeValue : EffectiveAttributeValue
{
    /// <summary>
    /// Represents the modifiers that are combined to create the effective value.
    /// </summary>
    protected readonly List<(string Key, int Modifier)> _attributeModifiers = new List<(string, int)>();
    public override DictionaryGameStateBag? Serialize(SaveGameState saveGameState)
    {
        // Serialize the tuples.
        GameStateBag[] tupleGameStateBags = _attributeModifiers.Select(_attributeModifier => new DictionaryGameStateBag(
                (nameof(_attributeModifier.Key), saveGameState.CreateGameStateBag(_attributeModifier.Key)),
                (nameof(_attributeModifier.Modifier), saveGameState.CreateGameStateBag(_attributeModifier.Modifier))
        )).ToArray();

        // Put the tuples into a list.
        GameStateBag listOfTuplesGameStateBag = new ListGameStateBag(tupleGameStateBags);

        // Return the dictionary of the values.
        return new DictionaryGameStateBag(base.Serialize(saveGameState),
            (nameof(_attributeModifiers), listOfTuplesGameStateBag)
        );
    }
    public SumEffectiveAttributeValue(Game game, Attribute attribute) : base(game, attribute) { }
    public override EffectiveAttributeValue Clone()
    {
        SumEffectiveAttributeValue clone = new SumEffectiveAttributeValue(Game, Attribute);
        clone._attributeModifiers.AddRange(_attributeModifiers);
        return (EffectiveAttributeValue)clone;
    }
    public override string RenderForItemIdentification => Get().ToString();
    public override AttributeValue ToReadOnly() => new IntReadOnlyAttributeValue(Get());

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
    /// Computes a value to append to the modifiers so that the effective value equals the specified value.
    /// </summary>
    /// <param name="value"></param>
    public void Set(int value)
    {
        _attributeModifiers.Add(("", Get() - value));
    }

    public void Set(int? value)
    {
        if (value.HasValue)
        {
            Set(value.Value);
        }
    }

    public void Set(Expression? value)
    {
        if (value is not null)
        {
            int intValue = Game.ComputeIntegerExpression(value).Value;
            Set(intValue);
        }
    }
}
