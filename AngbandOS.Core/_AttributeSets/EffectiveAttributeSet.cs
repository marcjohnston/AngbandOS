// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Collections;

namespace AngbandOS.Core;

[Serializable]
internal class EffectiveAttributeSet : IEnumerable<EffectiveAttributeValue>
{
    private readonly Game Game;
    private readonly EffectiveAttributeValue[] _effectiveAttributeValues;
    private static Attribute[]? CachedAttributes = null;
    private Attribute[] LoadCachedAttributes()
    {
        if (CachedAttributes == null)
        {
            CachedAttributes = Game.SingletonRepository.Get<Attribute>();
        }
        return CachedAttributes;
    }

    public EffectiveAttributeSet(Game game)
    {
        Game = game;
        Attribute[] cachedAttributes = LoadCachedAttributes();
        _effectiveAttributeValues = new EffectiveAttributeValue[cachedAttributes.Length];
        foreach (Attribute attribute in cachedAttributes)
        {
            EffectiveAttributeValue effectiveAttributeValue = attribute.CreateEffectiveAttributeValue();
            _effectiveAttributeValues[attribute.Index] = effectiveAttributeValue;
        }
    }

    public void RemoveKeyedEnhancements(string key)
    {
        foreach (EffectiveAttributeValue attributeLedger in _effectiveAttributeValues)
            attributeLedger.RemoveModifiers(key);
    }

    public void ReplaceAttributeSet(string key, ReadOnlyAttributeSet readOnlyPropertySet)
    {
        RemoveKeyedEnhancements(key);
        MergeAttributeSet(readOnlyPropertySet);
    }

    /// <summary>
    /// Merge a set of read-only attribute values with a specific key.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void MergeAttributeSet(ReadOnlyAttributeSet readOnlyPropertySet)
    {
        foreach (Attribute attribute in Game.SingletonRepository.Get<Attribute>())
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
        foreach (Attribute attribute in Game.SingletonRepository.Get<Attribute>())
        {
            _effectiveAttributeValues[attribute.Index].Merge(key, readOnlyPropertySet[attribute.Index]);
        }
    }

    public ReadOnlyAttributeSet ToReadOnly()
    {
        Attribute[] cachedAttributes = LoadCachedAttributes();
        AttributeValue[] attributeModifiers = new AttributeValue[cachedAttributes.Length];
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
        Attribute[] cachedAttributes = LoadCachedAttributes();
        foreach (Attribute attribute in cachedAttributes)
        {
            clone._effectiveAttributeValues[attribute.Index] = _effectiveAttributeValues[attribute.Index].Clone();
        }
        return clone;
    }

    public IEnumerator<EffectiveAttributeValue> GetEnumerator()
    {
        return _effectiveAttributeValues.AsEnumerable<EffectiveAttributeValue>().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    #region Properties
    public int MeleeToHit
    {
        get
        {
            return Get<SumEffectiveAttributeValue>(nameof(MeleeToHitAttribute)).Get();
        }
        set
        {
            Get<SumEffectiveAttributeValue>(nameof(MeleeToHitAttribute)).Append(value);
        }
    }
    public int BonusArmorClass
    {
        get
        {
            return Get<SumEffectiveAttributeValue>(nameof(BonusArmorClassAttribute)).Get();
        }
        set
        {
            Get<SumEffectiveAttributeValue>(nameof(BonusArmorClassAttribute)).Append(value);
        }
    }
    public int DisarmTraps
    {
        get
        {
            return Get<SumEffectiveAttributeValue>(nameof(DisarmTrapsAttribute)).Get();
        }
        set
        {
            Get<SumEffectiveAttributeValue>(nameof(DisarmTrapsAttribute)).Append(value);
        }
    }
    public int ToDamage
    {
        get
        {
            return Get<SumEffectiveAttributeValue>(nameof(ToDamageAttribute)).Get();
        }
        set
        {
            Get<SumEffectiveAttributeValue>(nameof(ToDamageAttribute)).Append(value);
        }
    }
    public int Strength
    {
        get
        {
            return Get<SumEffectiveAttributeValue>(nameof(StrengthAttribute)).Get();
        }
        set
        {
            Get<SumEffectiveAttributeValue>(nameof(StrengthAttribute)).Append(value);
        }
    }
    public int Intelligence
    {
        get
        {
            return Get<SumEffectiveAttributeValue>(nameof(IntelligenceAttribute)).Get();
        }
        set
        {
            Get<SumEffectiveAttributeValue>(nameof(IntelligenceAttribute)).Append(value);
        }
    }
    public int Wisdom
    {
        get
        {
            return Get<SumEffectiveAttributeValue>(nameof(WisdomAttribute)).Get();
        }
        set
        {
            Get<SumEffectiveAttributeValue>(nameof(WisdomAttribute)).Append(value);
        }
    }
    public int Dexterity
    {
        get
        {
            return Get<SumEffectiveAttributeValue>(nameof(DexterityAttribute)).Get();
        }
        set
        {
            Get<SumEffectiveAttributeValue>(nameof(DexterityAttribute)).Append(value);
        }
    }
    public int Constitution
    {
        get
        {
            return Get<SumEffectiveAttributeValue>(nameof(ConstitutionAttribute)).Get();
        }
        set
        {
            Get<SumEffectiveAttributeValue>(nameof(ConstitutionAttribute)).Append(value);
        }
    }
    public int Charisma
    {
        get
        {
            return Get<SumEffectiveAttributeValue>(nameof(CharismaAttribute)).Get();
        }
        set
        {
            Get<SumEffectiveAttributeValue>(nameof(CharismaAttribute)).Append(value);
        }
    }
    public int Stealth
    {
        get
        {
            return Get<SumEffectiveAttributeValue>(nameof(StealthAttribute)).Get();
        }
        set
        {
            Get<SumEffectiveAttributeValue>(nameof(StealthAttribute)).Append(value);
        }
    }
    public int Search
    {
        get
        {
            return Get<SumEffectiveAttributeValue>(nameof(SearchAttribute)).Get();
        }
        set
        {
            Get<SumEffectiveAttributeValue>(nameof(SearchAttribute)).Append(value);
        }
    }
    public int Infravision
    {
        get
        {
            return Get<SumEffectiveAttributeValue>(nameof(InfravisionAttribute)).Get();
        }
        set
        {
            Get<SumEffectiveAttributeValue>(nameof(InfravisionAttribute)).Append(value);
        }
    }
    public int Tunnel
    {
        get
        {
            return Get<SumEffectiveAttributeValue>(nameof(TunnelAttribute)).Get();
        }
        set
        {
            Get<SumEffectiveAttributeValue>(nameof(TunnelAttribute)).Append(value);
        }
    }
    public int Attacks
    {
        get
        {
            return Get<SumEffectiveAttributeValue>(nameof(AttacksAttribute)).Get();
        }
        set
        {
            Get<SumEffectiveAttributeValue>(nameof(AttacksAttribute)).Append(value);
        }
    }
    public int Speed
    {
        get
        {
            return Get<SumEffectiveAttributeValue>(nameof(SpeedAttribute)).Get();
        }
        set
        {
            Get<SumEffectiveAttributeValue>(nameof(SpeedAttribute)).Append(value);
        }
    }
    public Activation? Activation
    {
        get
        {
            return Get<NullableReferenceSetEffectiveAttributeValue<Activation>>(nameof(ActivationAttribute)).Get();
        }
        set
        {
            Get<NullableReferenceSetEffectiveAttributeValue<Activation>>(nameof(ActivationAttribute)).Set(value);
        }
    }
    public ArtifactBias? ArtifactBias
    {
        get
        {
            return Get<NullableReferenceSetEffectiveAttributeValue<ArtifactBias>>(nameof(ArtifactBiasAttribute)).Get();
        }
        set
        {
            Get<NullableReferenceSetEffectiveAttributeValue<ArtifactBias>>(nameof(ArtifactBiasAttribute)).Set(value);
        }
    }
    public ColorEnum Color
    {
        get
        {
            return Get<ColorEnumSetEffectiveAttributeValue>(nameof(ColorAttribute)).Get();
        }
        set
        {
            Get<ColorEnumSetEffectiveAttributeValue>(nameof(ColorAttribute)).Set(value);
        }
    }
    public bool IsCursed
    {
        get
        {
            bool? isCursed = Get<BoolSetEffectiveAttributeValue>(nameof(IsCursedAttribute)).Get();
            return isCursed.HasValue && isCursed.Value;
        }
        set
        {
            if (value)
            {
                Get<BoolSetEffectiveAttributeValue>(nameof(IsCursedAttribute)).Set();
            }
            else if (!value)
            {
                Get<BoolSetEffectiveAttributeValue>(nameof(IsCursedAttribute)).Reset();
            }
        }
    }
    public int DamageDice
    {
        get
        {
            return Get<SumEffectiveAttributeValue>(nameof(DamageDiceAttribute)).Get();
        }
        set
        {
            Get<SumEffectiveAttributeValue>(nameof(DamageDiceAttribute)).Append(value);
        }
    }
    public int DiceSides
    {
        get
        {
            return Get<SumEffectiveAttributeValue>(nameof(DiceSidesAttribute)).Get();
        }
        set
        {
            Get<SumEffectiveAttributeValue>(nameof(DiceSidesAttribute)).Append(value);
        }
    }
    public bool DreadCurse
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(DreadCurseAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(DreadCurseAttribute)).Set();
            }
        }
    }
    public bool EasyKnow
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(EasyKnowAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(EasyKnowAttribute)).Set();
            }
        }
    }
    public bool Feather
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(FeatherAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(FeatherAttribute)).Set();
            }
        }
    }
    public bool FreeAct
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(FreeActAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(FreeActAttribute)).Set();
            }
        }
    }
    public string? FriendlyName
    {
        get
        {
            return Get<NullableReferenceSetEffectiveAttributeValue<string>>(nameof(FriendlyNameAttribute)).Get();
        }
        set
        {
            Get<NullableReferenceSetEffectiveAttributeValue<string>>(nameof(FriendlyNameAttribute)).Set(value);
        }
    }
    public bool HatesElectricity
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(HatesElectricityAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(HatesElectricityAttribute)).Set();
            }
        }
    }
    public bool HatesAcid
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(HatesAcidAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(HatesAcidAttribute)).Set();
            }
        }
    }
    public bool HatesCold
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(HatesColdAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(HatesColdAttribute)).Set();
            }
        }
    }
    public bool HatesFire
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(HatesFireAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(HatesFireAttribute)).Set();
            }
        }
    }
    public bool HeavyCurse
    {
        get
        {
            bool? heavyCurse = Get<BoolSetEffectiveAttributeValue>(nameof(HeavyCurseAttribute)).Get();
            return heavyCurse.HasValue && heavyCurse.Value;
        }
        set
        {
            if (value)
            {
                Get<BoolSetEffectiveAttributeValue>(nameof(IsCursedAttribute)).Set();
            }
            else if (!value)
            {
                Get<BoolSetEffectiveAttributeValue>(nameof(IsCursedAttribute)).Reset();
            }
        }
    }
    public bool HideType
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(HideTypeAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(HideTypeAttribute)).Set();
            }
        }
    }
    public bool HoldLife
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(HoldLifeAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(HoldLifeAttribute)).Set();
            }
        }
    }
    public bool IgnoreAcid
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(IgnoreAcidAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(IgnoreAcidAttribute)).Set();
            }
        }
    }
    public bool IgnoreCold
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(IgnoreColdAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(IgnoreColdAttribute)).Set();
            }
        }
    }
    public bool IgnoreElec
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(IgnoreElecAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(IgnoreElecAttribute)).Set();
            }
        }
    }
    public bool IgnoreFire
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(IgnoreFireAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(IgnoreFireAttribute)).Set();
            }
        }
    }
    public bool ImAcid
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(ImAcidAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(ImAcidAttribute)).Set();
            }
        }
    }
    public bool ImCold
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(ImColdAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(ImColdAttribute)).Set();
            }
        }
    }
    public bool ImElec
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(ImElecAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(ImElecAttribute)).Set();
            }
        }
    }
    public bool ImFire
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(ImFireAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(ImFireAttribute)).Set();
            }
        }
    }
    public bool Impact
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(ImpactAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(ImpactAttribute)).Set();
            }
        }
    }
    public bool NoMagic
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(NoMagicAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(NoMagicAttribute)).Set();
            }
        }
    }
    public bool NoTele
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(NoTeleAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(NoTeleAttribute)).Set();
            }
        }
    }
    public bool PermaCurse
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(PermaCurseAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(PermaCurseAttribute)).Set();
            }
        }
    }
    public int Radius
    {
        get
        {
            return Get<SumEffectiveAttributeValue>(nameof(RadiusAttribute)).Get();
        }
        set
        {
            Get<SumEffectiveAttributeValue>(nameof(RadiusAttribute)).Append(value);
        }
    }
    public bool Valueless
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(ValuelessAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(ValuelessAttribute)).Set();
            }
        }
    }
    public int Vorpal1InChance
    {
        get
        {
            return Get<SumEffectiveAttributeValue>(nameof(Vorpal1InChanceAttribute)).Get();
        }
        set
        {
            Get<SumEffectiveAttributeValue>(nameof(Vorpal1InChanceAttribute)).Set(value);
        }
    }
    public int Weight
    {
        get
        {
            return Get<SumEffectiveAttributeValue>(nameof(WeightAttribute)).Get();
        }
        set
        {
            Get<SumEffectiveAttributeValue>(nameof(WeightAttribute)).Set(value);
        }
    }
    #endregion
}
