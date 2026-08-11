// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Text;

namespace AngbandOS.Core;

internal class EffectiveAttributeSet : IGameSerialize
{
    #region State Data
    private readonly EffectiveAttributeValue[] _effectiveAttributeValues;
    #endregion

    #region Constructors
    /// <summary>
    /// Instantiates all of the effective attribute values.
    /// </summary>
    /// <param name="game"></param>
    public EffectiveAttributeSet(Game game)
    {
        Game = game;
        Attribute[] cachedAttributes = Game.CachedAttributes;

        // Allocate the array.
        _effectiveAttributeValues = new EffectiveAttributeValue[cachedAttributes.Length];

        // Loop through all of the configured attributes.
        foreach (Attribute attribute in cachedAttributes)
        {
            // Generate the attribute value.
            EffectiveAttributeValue effectiveAttributeValue = attribute.CreateEffectiveAttributeValue();

            // Assign it to the array index.
            _effectiveAttributeValues[attribute.Index] = effectiveAttributeValue;
        }
    }

    public EffectiveAttributeSet(Game game, RestoreGameState restoreGameState)
    {
        Game = game;
        Attribute[] cachedAttributes = Game.CachedAttributes;

        _effectiveAttributeValues = restoreGameState.GetByKey(nameof(_effectiveAttributeValues)).GetDerivedReferences<EffectiveAttributeValue>(
            (RestoreGameState restoreGameState) => new ActivationEffectiveAttributeValue(Game, restoreGameState),
            (RestoreGameState restoreGameState) => new ArtifactBiasEffectiveAttributeValue(Game, restoreGameState),
            (RestoreGameState restoreGameState) => new FriendlyNameEffectiveAttributeValue(Game, restoreGameState),
            (RestoreGameState restoreGameState) => new BitwiseOrEffectiveAttributeValue(Game, restoreGameState),
            (RestoreGameState restoreGameState) => new SummationEffectiveAttributeValue(Game, restoreGameState));
    }
    #endregion

    public GameStateBag? Serialize(SaveGameState saveGameState)
    {
        return new DictionaryGameStateBag(
            (nameof(_effectiveAttributeValues), saveGameState.CreateDerivedGameStateBag(_effectiveAttributeValues, typeof(ActivationEffectiveAttributeValue), typeof(ArtifactBiasEffectiveAttributeValue), typeof(FriendlyNameEffectiveAttributeValue), typeof(BitwiseOrEffectiveAttributeValue), typeof(SummationEffectiveAttributeValue)))
        );
    }

    /// <summary>
    /// Returns a readable representation for debugging purposes.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        Attribute[] cachedAttributes = Game.CachedAttributes;
        StringBuilder stringBuilder = new StringBuilder();
        string delimiter = "";
        foreach (Attribute attribute in cachedAttributes)
        {
            ReadOnlyAttributeValue value = _effectiveAttributeValues[attribute.Index].ToReadOnly();
            if (!value.IsDefault)
            {
                stringBuilder.Append($"{delimiter}{attribute.Key.Replace("Attribute", "")}: {value.ToString()}");
                delimiter = "; ";
            }
        }
        return stringBuilder.ToString();
    }

    private Game Game { get; }

    public void RemoveKeyedEnhancements(string key)
    {
        foreach (EffectiveAttributeValue effectiveAttributeValue in _effectiveAttributeValues)
        {
            effectiveAttributeValue.RemoveModifiers(key);
        }
    }

    /// <summary>
    /// Merge a set of read-only attribute values with a specific key.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void MergeAttributeSet(ReadOnlyAttributeSet readOnlyPropertySet)
    {
        foreach (Attribute attribute in Game.CachedAttributes)
        {
            _effectiveAttributeValues[attribute.Index].Merge(readOnlyPropertySet[attribute.Index]);
        }
    }

    /// <summary>
    /// Merge a set of read-only attribute values with a specific key.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void MergeAttributeSet(string key, ReadOnlyAttributeSet readOnlyPropertySet)
    {
        if (String.IsNullOrEmpty(key))
        {
            throw new ArgumentException("Invalid key specified for enhancements.");
        }
        foreach (Attribute attribute in Game.CachedAttributes)
        {
            _effectiveAttributeValues[attribute.Index].Merge(key, readOnlyPropertySet[attribute.Index]);
        }
    }

    public ReadOnlyAttributeSet ToReadOnly()
    {
        Attribute[] cachedAttributes = Game.CachedAttributes;
        ReadOnlyAttributeValue[] attributeModifiers = new ReadOnlyAttributeValue[cachedAttributes.Length];
        foreach (Attribute attribute in cachedAttributes)
        {
            attributeModifiers[attribute.Index] = _effectiveAttributeValues[attribute.Index].ToReadOnly();
        }
        return new ReadOnlyAttributeSet(Game, attributeModifiers);
    }

    /// <summary>
    /// Returns true if any of the effective attribute values have keyed item enhancements for the specified key.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public bool HasKeyedItemEnhancements(string key)
    {
        foreach (EffectiveAttributeValue attributeLedger in _effectiveAttributeValues)
        {
            if (attributeLedger.HasKeyedItemEnhancements(key))
            {
                return true;
            }
        }
        return false;
    }
    public bool GetBool(string attributeName)
    {
        return Get<BitwiseOrEffectiveAttributeValue>(attributeName).Get();
    }
    public int GetSum(string attributeName)
    {
        return Get<SummationEffectiveAttributeValue>(attributeName).Get();
    }

    /// <summary>
    /// Retrieves the effective attribute value associated with the specified attribute and casts it to the specified type T.
    /// </summary>
    /// <typeparam name="T">The type of the effective attribute value to return. Must inherit from EffectiveAttributeValue.</typeparam>
    /// <param name="attribute">The attribute for which to retrieve the effective value.</param>
    /// <returns>The effective attribute value of type T corresponding to the specified attribute.</returns>
    [Obsolete("Use Get<T>(Attribute attribute) instead to avoid unnecessary lookups of the Attribute by name.")]
    public T Get<T>(string attributeName) where T : EffectiveAttributeValue
    {
        Attribute attribute = Game.SingletonRepository.Get<Attribute>(attributeName);
        int index = attribute.Index;
        return (T)_effectiveAttributeValues[index];
    }

    public T Get<T>(Attribute attribute) where T : EffectiveAttributeValue
    {
        int index = attribute.Index;
        return (T)_effectiveAttributeValues[index];
    }

    public EffectiveAttributeValue Get(Attribute attribute)
    {
        int index = attribute.Index;
        return _effectiveAttributeValues[index];
    }

    /// <summary>
    /// Creates a new instance of <see cref="EffectiveAttributeSet"/> that is a deep copy of the current set and its attribute values.
    /// </summary>
    /// <remarks>
    /// The cloned set is independent of the original; changes to attribute values in the clone do not affect the original set, and vice versa.
    /// </remarks>
    /// <returns>
    /// A new <see cref="EffectiveAttributeSet"/> containing copies of all effective attribute values from the current set.
    /// </returns>
    public EffectiveAttributeSet Clone()
    {
        EffectiveAttributeSet clone = new EffectiveAttributeSet(Game);
        foreach (Attribute attribute in Game.CachedAttributes)
        {
            clone._effectiveAttributeValues[attribute.Index] = _effectiveAttributeValues[attribute.Index].Clone();
        }
        return clone;
    }

    #region Properties
    public int MeleeToHit
    {
        get
        {
            return Get<SummationEffectiveAttributeValue>(nameof(MeleeToHitAttribute)).Get();
        }
        set
        {
            Get<SummationEffectiveAttributeValue>(nameof(MeleeToHitAttribute)).Append(value);
        }
    }
    public int BonusArmorClass
    {
        get
        {
            return Get<SummationEffectiveAttributeValue>(nameof(BonusArmorClassAttribute)).Get();
        }
        set
        {
            Get<SummationEffectiveAttributeValue>(nameof(BonusArmorClassAttribute)).Append(value);
        }
    }
    public int ToDamage
    {
        get
        {
            return Get<SummationEffectiveAttributeValue>(nameof(ToDamageAttribute)).Get();
        }
        set
        {
            Get<SummationEffectiveAttributeValue>(nameof(ToDamageAttribute)).Append(value);
        }
    }
    public int Strength
    {
        get
        {
            return Get<SummationEffectiveAttributeValue>(nameof(BonusStrengthAttribute)).Get();
        }
        set
        {
            Get<SummationEffectiveAttributeValue>(nameof(BonusStrengthAttribute)).Append(value);
        }
    }
    public int Intelligence
    {
        get
        {
            return Get<SummationEffectiveAttributeValue>(nameof(BonusIntelligenceAttribute)).Get();
        }
        set
        {
            Get<SummationEffectiveAttributeValue>(nameof(BonusIntelligenceAttribute)).Append(value);
        }
    }
    public int Wisdom
    {
        get
        {
            return Get<SummationEffectiveAttributeValue>(nameof(BonusWisdomAttribute)).Get();
        }
        set
        {
            Get<SummationEffectiveAttributeValue>(nameof(BonusWisdomAttribute)).Append(value);
        }
    }
    public int Dexterity
    {
        get
        {
            return Get<SummationEffectiveAttributeValue>(nameof(BonusDexterityAttribute)).Get();
        }
        set
        {
            Get<SummationEffectiveAttributeValue>(nameof(BonusDexterityAttribute)).Append(value);
        }
    }
    public int Constitution
    {
        get
        {
            return Get<SummationEffectiveAttributeValue>(nameof(BonusConstitutionAttribute)).Get();
        }
        set
        {
            Get<SummationEffectiveAttributeValue>(nameof(BonusConstitutionAttribute)).Append(value);
        }
    }
    public int Charisma
    {
        get
        {
            return Get<SummationEffectiveAttributeValue>(nameof(BonusCharismaAttribute)).Get();
        }
        set
        {
            Get<SummationEffectiveAttributeValue>(nameof(BonusCharismaAttribute)).Append(value);
        }
    }
    public int Stealth
    {
        get
        {
            return Get<SummationEffectiveAttributeValue>(nameof(StealthAttribute)).Get();
        }
        set
        {
            Get<SummationEffectiveAttributeValue>(nameof(StealthAttribute)).Append(value);
        }
    }
    public int Search
    {
        get
        {
            return Get<SummationEffectiveAttributeValue>(nameof(SearchAttribute)).Get();
        }
        set
        {
            Get<SummationEffectiveAttributeValue>(nameof(SearchAttribute)).Append(value);
        }
    }
    public int Infravision
    {
        get
        {
            return Get<SummationEffectiveAttributeValue>(nameof(InfraVisionAttribute)).Get();
        }
        set
        {
            Get<SummationEffectiveAttributeValue>(nameof(InfraVisionAttribute)).Append(value);
        }
    }
    public int Tunnel
    {
        get
        {
            return Get<SummationEffectiveAttributeValue>(nameof(TunnelAttribute)).Get();
        }
        set
        {
            Get<SummationEffectiveAttributeValue>(nameof(TunnelAttribute)).Append(value);
        }
    }
    public int Attacks
    {
        get
        {
            return Get<SummationEffectiveAttributeValue>(nameof(AttacksAttribute)).Get();
        }
        set
        {
            Get<SummationEffectiveAttributeValue>(nameof(AttacksAttribute)).Append(value);
        }
    }
    public int Speed
    {
        get
        {
            return Get<SummationEffectiveAttributeValue>(nameof(SpeedAttribute)).Get();
        }
        set
        {
            Get<SummationEffectiveAttributeValue>(nameof(SpeedAttribute)).Append(value);
        }
    }
    public Activation? Activation
    {
        get
        {
            return Get<ActivationEffectiveAttributeValue>(nameof(ActivationAttribute)).Get();
        }
        set
        {
            Get<ActivationEffectiveAttributeValue>(nameof(ActivationAttribute)).Set(value);
        }
    }
    public ArtifactBias? ArtifactBias
    {
        get
        {
            return Get<ArtifactBiasEffectiveAttributeValue>(nameof(ArtifactBiasAttribute)).Get();
        }
        set
        {
            Get<ArtifactBiasEffectiveAttributeValue>(nameof(ArtifactBiasAttribute)).Set(value);
        }
    }
    public bool IsCursed
    {
        get
        {
            return Get<BitwiseOrEffectiveAttributeValue>(nameof(IsCursedAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<BitwiseOrEffectiveAttributeValue>(nameof(IsCursedAttribute)).Set();
            }
        }
    }
    public int DamageDice
    {
        get
        {
            return Get<SummationEffectiveAttributeValue>(nameof(DamageDiceAttribute)).Get();
        }
        set
        {
            Get<SummationEffectiveAttributeValue>(nameof(DamageDiceAttribute)).Append(value);
        }
    }
    public int DiceSides
    {
        get
        {
            return Get<SummationEffectiveAttributeValue>(nameof(DiceSidesAttribute)).Get();
        }
        set
        {
            Get<SummationEffectiveAttributeValue>(nameof(DiceSidesAttribute)).Append(value);
        }
    }
    public bool Valueless
    {
        get
        {
            return Get<BitwiseOrEffectiveAttributeValue>(nameof(ValuelessAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<BitwiseOrEffectiveAttributeValue>(nameof(ValuelessAttribute)).Set();
            }
        }
    }
    public int Weight
    {
        get
        {
            return Get<SummationEffectiveAttributeValue>(nameof(WeightAttribute)).Get();
        }
    }
    #endregion
}
