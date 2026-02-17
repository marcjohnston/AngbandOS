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
    public bool CanApplyBlessedArtifactBias
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(CanApplyBlessedArtifactBiasAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(CanApplyBlessedArtifactBiasAttribute)).Set();
            }
        }
    }
    public bool ArtifactBiasCanSlay
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(ArtifactBiasCanSlayAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(ArtifactBiasCanSlayAttribute)).Set();
            }
        }
    }
    public bool CanApplyBlowsBonus
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(CanApplyBlowsBonusAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(CanApplyBlowsBonusAttribute)).Set();
            }
        }
    }
    public bool CanApplySlayingBonus
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(CanApplySlayingBonusAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(CanApplySlayingBonusAttribute)).Set();
            }
        }
    }
    public bool CanApplyBonusArmorClassMiscPower
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(CanApplyBonusArmorClassMiscPowerAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(CanApplyBonusArmorClassMiscPowerAttribute)).Set();
            }
        }
    }
    public bool CanProvideSheathOfElectricity
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(CanProvideSheathOfElectricityAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(CanProvideSheathOfElectricityAttribute)).Set();
            }
        }
    }
    public bool CanProvideSheathOfFire
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(CanProvideSheathOfFireAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(CanProvideSheathOfFireAttribute)).Set();
            }
        }
    }
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
    public int BaseArmorClass
    {
        get
        {
            return Get<SumEffectiveAttributeValue>(nameof(BaseArmorClassAttribute)).Get();
        }
        set
        {
            Get<SumEffectiveAttributeValue>(nameof(BaseArmorClassAttribute)).Append(value);
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
    public bool Aggravate
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(AggravateAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(AggravateAttribute)).Set();
            }
        }
    }
    public bool AntiTheft
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(AntiTheftAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(AntiTheftAttribute)).Set();
            }
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
    public bool Blessed
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(BlessedAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(BlessedAttribute)).Set();
            }
        }
    }
    public bool BrandAcid
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(BrandAcidAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(BrandAcidAttribute)).Set();
            }
        }
    }
    public bool BrandCold
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(BrandColdAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(BrandColdAttribute)).Set();
            }
        }
    }
    public bool BrandElec
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(BrandElecAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(BrandElecAttribute)).Set();
            }
        }
    }
    public bool BrandFire
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(BrandFireAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(BrandFireAttribute)).Set();
            }
        }
    }
    public bool BrandPois
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(BrandPoisAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(BrandPoisAttribute)).Set();
            }
        }
    }
    public bool Chaotic
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(ChaoticAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(ChaoticAttribute)).Set();
            }
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
    public bool DrainExp
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(DrainExpAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(DrainExpAttribute)).Set();
            }
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
    public int BurnRate
    {
        get
        {
            return Get<SumEffectiveAttributeValue>(nameof(BurnRateAttribute)).Get();
        }
        set
        {
            Get<SumEffectiveAttributeValue>(nameof(BurnRateAttribute)).Append(value);
        }
    }
    public bool Reflect
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(ReflectAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(ReflectAttribute)).Set();
            }
        }
    }
    public bool Regen
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(RegenAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(RegenAttribute)).Set();
            }
        }
    }
    public bool ResAcid
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(ResAcidAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(ResAcidAttribute)).Set();
            }
        }
    }
    public bool ResBlind
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(ResBlindAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(ResBlindAttribute)).Set();
            }
        }
    }
    public bool ResChaos
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(ResChaosAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(ResChaosAttribute)).Set();
            }
        }
    }
    public bool ResCold
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(ResColdAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(ResColdAttribute)).Set();
            }
        }
    }
    public bool ResConf
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(ResConfAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(ResConfAttribute)).Set();
            }
        }
    }
    public bool ResDark
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(ResDarkAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(ResDarkAttribute)).Set();
            }
        }
    }
    public bool ResDisen
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(ResDisenAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(ResDisenAttribute)).Set();
            }
        }
    }
    public bool ResElec
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(ResElecAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(ResElecAttribute)).Set();
            }
        }
    }
    public bool ResFear
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(ResFearAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(ResFearAttribute)).Set();
            }
        }
    }
    public bool ResFire
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(ResFireAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(ResFireAttribute)).Set();
            }
        }
    }
    public bool ResLight
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(ResLightAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(ResLightAttribute)).Set();
            }
        }
    }
    public bool ResNether
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(ResNetherAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(ResNetherAttribute)).Set();
            }
        }
    }
    public bool ResNexus
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(ResNexusAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(ResNexusAttribute)).Set();
            }
        }
    }
    public bool ResPois
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(ResPoisAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(ResPoisAttribute)).Set();
            }
        }
    }
    public bool ResShards
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(ResShardsAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(ResShardsAttribute)).Set();
            }
        }
    }
    public bool ResSound
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(ResSoundAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(ResSoundAttribute)).Set();
            }
        }
    }
    public int SavingThrow
    {
        get
        {
            return Get<SumEffectiveAttributeValue>(nameof(SavingThrowAttribute)).Get();
        }
        set
        {
            Get<SumEffectiveAttributeValue>(nameof(SavingThrowAttribute)).Set(value);
        }
    }
    public bool SeeInvis
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(SeeInvisAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(SeeInvisAttribute)).Set();
            }
        }
    }
    public bool ShElec
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(ShElecAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(ShElecAttribute)).Set();
            }
        }
    }
    public bool ShFire
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(ShFireAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(ShFireAttribute)).Set();
            }
        }
    }
    public bool ShowMods
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(ShowModsAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(ShowModsAttribute)).Set();
            }
        }
    }
    public bool SlayAnimal
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(SlayAnimalAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(SlayAnimalAttribute)).Set();
            }
        }
    }
    public bool SlayDemon
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(SlayDemonAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(SlayDemonAttribute)).Set();
            }
        }
    }
    public int SlayDragon
    {
        get
        {
            return Get<SumEffectiveAttributeValue>(nameof(SlayDragonAttribute)).Get();
        }
        set
        {
            Get<SumEffectiveAttributeValue>(nameof(SlayDragonAttribute)).Set(value);
        }
    }
    public bool SlayEvil
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(SlayEvilAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(SlayEvilAttribute)).Set();
            }
        }
    }
    public bool SlayGiant
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(SlayGiantAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(SlayGiantAttribute)).Set();
            }
        }
    }
    public bool SlayOrc
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(SlayOrcAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(SlayOrcAttribute)).Set();
            }
        }
    }
    public bool SlayTroll
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(SlayTrollAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(SlayTrollAttribute)).Set();
            }
        }
    }
    public bool SlayUndead
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(SlayUndeadAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(SlayUndeadAttribute)).Set();
            }
        }
    }
    public bool SlowDigest
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(SlowDigestAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(SlowDigestAttribute)).Set();
            }
        }
    }
    public bool SustCha
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(SustChaAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(SustChaAttribute)).Set();
            }
        }
    }
    public bool SustCon
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(SustConAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(SustConAttribute)).Set();
            }
        }
    }
    public bool SustDex
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(SustDexAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(SustDexAttribute)).Set();
            }
        }
    }
    public bool SustInt
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(SustIntAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(SustIntAttribute)).Set();
            }
        }
    }
    public bool SustStr
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(SustStrAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(SustStrAttribute)).Set();
            }
        }
    }
    public bool SustWis
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(SustWisAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(SustWisAttribute)).Set();
            }
        }
    }
    public bool Telepathy
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(TelepathyAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(TelepathyAttribute)).Set();
            }
        }
    }
    public bool Teleport
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(TeleportAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(TeleportAttribute)).Set();
            }
        }
    }
    public int TreasureRating
    {
        get
        {
            return Get<SumEffectiveAttributeValue>(nameof(TreasureRatingAttribute)).Get();
        }
        set
        {
            Get<SumEffectiveAttributeValue>(nameof(TreasureRatingAttribute)).Set(value);
        }
    }
    public int UseDevice
    {
        get
        {
            return Get<SumEffectiveAttributeValue>(nameof(UseDeviceAttribute)).Get();
        }
        set
        {
            Get<SumEffectiveAttributeValue>(nameof(UseDeviceAttribute)).Set(value);
        }
    }
    public int Value
    {
        get
        {
            return Get<SumEffectiveAttributeValue>(nameof(ValueAttribute)).Get();
        }
        set
        {
            Get<SumEffectiveAttributeValue>(nameof(ValueAttribute)).Append(value);
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
    public bool Vampiric
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(VampiricAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(VampiricAttribute)).Set();
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
    public int VorpalExtraAttacks1InChance
    {
        get
        {
            return Get<SumEffectiveAttributeValue>(nameof(VorpalExtraAttacks1InChanceAttribute)).Get();
        }
        set
        {
            Get<SumEffectiveAttributeValue>(nameof(VorpalExtraAttacks1InChanceAttribute)).Set(value);
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
    public bool Wraith
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(WraithAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(WraithAttribute)).Set();
            }
        }
    }
    public bool XtraMight
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(XtraMightAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(XtraMightAttribute)).Set();
            }
        }
    }
    public bool XtraShots
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(nameof(XtraShotsAttribute)).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(nameof(XtraShotsAttribute)).Set();
            }
        }
    }
    #endregion
}
