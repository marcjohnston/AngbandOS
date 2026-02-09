// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class EffectiveAttributeSet
{
    private readonly Game Game;
    private readonly EffectiveAttributeValue[] _effectiveAttributeValues;
    public EffectiveAttributeSet(Game game)
    {
        Game = game;
        _effectiveAttributeValues = new EffectiveAttributeValue[Game.SingletonRepository.Count<Attribute>()];
        foreach (Attribute attribute in Game.SingletonRepository.Get<Attribute>())
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
        AttributeValue[] attributeModifiers = new AttributeValue[Game.SingletonRepository.Count<Attribute>()];
        foreach (Attribute attribute in Game.SingletonRepository.Get<Attribute>())
        {
            attributeModifiers[attribute.Index] = _effectiveAttributeValues[attribute.Index].ToReadOnly();
        }
        return new ReadOnlyAttributeSet(attributeModifiers);
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
    public T Get<T>(AttributeEnum attribute) where T : EffectiveAttributeValue
    {
        int index = (int)attribute;
        return (T)_effectiveAttributeValues[index];
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
        foreach (Attribute attribute in Game.SingletonRepository.Get<Attribute>())
        {
            clone._effectiveAttributeValues[attribute.Index] = _effectiveAttributeValues[attribute.Index].Clone();
        }
        return clone;
    }

    #region Properties
    public bool CanApplyBlessedArtifactBias
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.CanApplyBlessedArtifactBias).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.CanApplyBlessedArtifactBias).Set();
            }
        }
    }
    public bool ArtifactBiasSlayingDisabled
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.ArtifactBiasSlayingDisabled).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.ArtifactBiasSlayingDisabled).Set();
            }
        }
    }
    public bool CanApplyBlowsBonus
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.CanApplyBlowsBonus).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.CanApplyBlowsBonus).Set();
            }
        }
    }
    public bool CanReflectBoltsAndArrows
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.CanReflectBoltsAndArrows).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.CanReflectBoltsAndArrows).Set();
            }
        }
    }
    public bool CanApplySlayingBonus
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.CanApplySlayingBonus).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.CanApplySlayingBonus).Set();
            }
        }
    }
    public bool CanApplyBonusArmorClassMiscPower
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.CanApplyBonusArmorClassMiscPower).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.CanApplyBonusArmorClassMiscPower).Set();
            }
        }
    }
    public bool CanProvideSheathOfElectricity
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.CanProvideSheathOfElectricity).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.CanProvideSheathOfElectricity).Set();
            }
        }
    }
    public bool CanProvideSheathOfFire
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.CanProvideSheathOfFire).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.CanProvideSheathOfFire).Set();
            }
        }
    }
    public int MeleeToHit
    {
        get
        {
            return Get<AdditionEffectiveAttributeValue>(AttributeEnum.MeleeToHit).Get();
        }
        set
        {
            Get<AdditionEffectiveAttributeValue>(AttributeEnum.MeleeToHit).Append(value);
        }
    }
    public int BaseArmorClass
    {
        get
        {
            return Get<AdditionEffectiveAttributeValue>(AttributeEnum.BaseArmorClass).Get();
        }
        set
        {
            Get<AdditionEffectiveAttributeValue>(AttributeEnum.BaseArmorClass).Append(value);
        }
    }
    public int BonusArmorClass
    {
        get
        {
            return Get<AdditionEffectiveAttributeValue>(AttributeEnum.BonusArmorClass).Get();
        }
        set
        {
            Get<AdditionEffectiveAttributeValue>(AttributeEnum.BonusArmorClass).Append(value);
        }
    }
    public int DisarmTraps
    {
        get
        {
            return Get<AdditionEffectiveAttributeValue>(AttributeEnum.DisarmTraps).Get();
        }
        set
        {
            Get<AdditionEffectiveAttributeValue>(AttributeEnum.DisarmTraps).Append(value);
        }
    }
    public int ToDamage
    {
        get
        {
            return Get<AdditionEffectiveAttributeValue>(AttributeEnum.ToDamage).Get();
        }
        set
        {
            Get<AdditionEffectiveAttributeValue>(AttributeEnum.ToDamage).Append(value);
        }
    }
    public int Strength
    {
        get
        {
            return Get<AdditionEffectiveAttributeValue>(AttributeEnum.Strength).Get();
        }
        set
        {
            Get<AdditionEffectiveAttributeValue>(AttributeEnum.Strength).Append(value);
        }
    }
    public int Intelligence
    {
        get
        {
            return Get<AdditionEffectiveAttributeValue>(AttributeEnum.Intelligence).Get();
        }
        set
        {
            Get<AdditionEffectiveAttributeValue>(AttributeEnum.Intelligence).Append(value);
        }
    }
    public int Wisdom
    {
        get
        {
            return Get<AdditionEffectiveAttributeValue>(AttributeEnum.Wisdom).Get();
        }
        set
        {
            Get<AdditionEffectiveAttributeValue>(AttributeEnum.Wisdom).Append(value);
        }
    }
    public int Dexterity
    {
        get
        {
            return Get<AdditionEffectiveAttributeValue>(AttributeEnum.Dexterity).Get();
        }
        set
        {
            Get<AdditionEffectiveAttributeValue>(AttributeEnum.Dexterity).Append(value);
        }
    }
    public int Constitution
    {
        get
        {
            return Get<AdditionEffectiveAttributeValue>(AttributeEnum.Constitution).Get();
        }
        set
        {
            Get<AdditionEffectiveAttributeValue>(AttributeEnum.Constitution).Append(value);
        }
    }
    public int Charisma
    {
        get
        {
            return Get<AdditionEffectiveAttributeValue>(AttributeEnum.Charisma).Get();
        }
        set
        {
            Get<AdditionEffectiveAttributeValue>(AttributeEnum.Charisma).Append(value);
        }
    }
    public int Stealth
    {
        get
        {
            return Get<AdditionEffectiveAttributeValue>(AttributeEnum.Stealth).Get();
        }
        set
        {
            Get<AdditionEffectiveAttributeValue>(AttributeEnum.Stealth).Append(value);
        }
    }
    public int Search
    {
        get
        {
            return Get<AdditionEffectiveAttributeValue>(AttributeEnum.Search).Get();
        }
        set
        {
            Get<AdditionEffectiveAttributeValue>(AttributeEnum.Search).Append(value);
        }
    }
    public int Infravision
    {
        get
        {
            return Get<AdditionEffectiveAttributeValue>(AttributeEnum.Infravision).Get();
        }
        set
        {
            Get<AdditionEffectiveAttributeValue>(AttributeEnum.Infravision).Append(value);
        }
    }
    public int Tunnel
    {
        get
        {
            return Get<AdditionEffectiveAttributeValue>(AttributeEnum.Tunnel).Get();
        }
        set
        {
            Get<AdditionEffectiveAttributeValue>(AttributeEnum.Tunnel).Append(value);
        }
    }
    public int Attacks
    {
        get
        {
            return Get<AdditionEffectiveAttributeValue>(AttributeEnum.Attacks).Get();
        }
        set
        {
            Get<AdditionEffectiveAttributeValue>(AttributeEnum.Attacks).Append(value);
        }
    }
    public int Speed
    {
        get
        {
            return Get<AdditionEffectiveAttributeValue>(AttributeEnum.Speed).Get();
        }
        set
        {
            Get<AdditionEffectiveAttributeValue>(AttributeEnum.Speed).Append(value);
        }
    }
    public Activation? Activation
    {
        get
        {
            return Get<NullableReferenceAttributeValue<Activation>>(AttributeEnum.Activation).Get();
        }
        set
        {
            Get<NullableReferenceAttributeValue<Activation>>(AttributeEnum.Activation).Set(value);
        }
    }
    public bool Aggravate
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.Aggravate).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.Aggravate).Set();
            }
        }
    }
    public bool AntiTheft
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.AntiTheft).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.AntiTheft).Set();
            }
        }
    }
    public ArtifactBias? ArtifactBias
    {
        get
        {
            return Get<NullableReferenceAttributeValue<ArtifactBias>>(AttributeEnum.ArtifactBias).Get();
        }
        set
        {
            Get<NullableReferenceAttributeValue<ArtifactBias>>(AttributeEnum.ArtifactBias).Set(value);
        }
    }
    public bool Blessed
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.Blessed).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.Blessed).Set();
            }
        }
    }
    public bool BrandAcid
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.BrandAcid).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.BrandAcid).Set();
            }
        }
    }
    public bool BrandCold
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.BrandCold).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.BrandCold).Set();
            }
        }
    }
    public bool BrandElec
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.BrandElec).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.BrandElec).Set();
            }
        }
    }
    public bool BrandFire
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.BrandFire).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.BrandFire).Set();
            }
        }
    }
    public bool BrandPois
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.BrandPois).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.BrandPois).Set();
            }
        }
    }
    public bool Chaotic
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.Chaotic).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.Chaotic).Set();
            }
        }
    }
    public ColorEnum Color
    {
        get
        {
            return Get<ColorEnumEffectiveAttributeValue>(AttributeEnum.Color).Get();
        }
        set
        {
            Get<ColorEnumEffectiveAttributeValue>(AttributeEnum.Color).Set(value);
        }
    }
    public bool IsCursed
    {
        get
        {
            bool? isCursed = Get<BoolAttributeValue>(AttributeEnum.IsCursed).Get();
            return isCursed.HasValue && isCursed.Value;
        }
        set
        {
            if (value)
            {
                Get<BoolAttributeValue>(AttributeEnum.IsCursed).Set();
            }
            else if (!value)
            {
                Get<BoolAttributeValue>(AttributeEnum.IsCursed).Reset();
            }
        }
    }
    public int DamageDice
    {
        get
        {
            return Get<AdditionEffectiveAttributeValue>(AttributeEnum.DamageDice).Get();
        }
        set
        {
            Get<AdditionEffectiveAttributeValue>(AttributeEnum.DamageDice).Append(value);
        }
    }
    public int DiceSides
    {
        get
        {
            return Get<AdditionEffectiveAttributeValue>(AttributeEnum.DiceSides).Get();
        }
        set
        {
            Get<AdditionEffectiveAttributeValue>(AttributeEnum.DiceSides).Append(value);
        }
    }
    public bool DrainExp
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.DrainExp).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.DrainExp).Set();
            }
        }
    }
    public bool DreadCurse
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.DreadCurse).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.DreadCurse).Set();
            }
        }
    }
    public bool EasyKnow
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.EasyKnow).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.EasyKnow).Set();
            }
        }
    }
    public bool Feather
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.Feather).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.Feather).Set();
            }
        }
    }
    public bool FreeAct
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.FreeAct).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.FreeAct).Set();
            }
        }
    }
    public string? FriendlyName
    {
        get
        {
            return Get<NullableReferenceAttributeValue<string>>(AttributeEnum.FriendlyName).Get();
        }
        set
        {
            Get<NullableReferenceAttributeValue<string>>(AttributeEnum.FriendlyName).Set(value);
        }
    }
    public bool HatesElectricity
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.HatesElectricity).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.HatesElectricity).Set();
            }
        }
    }
    public bool HatesAcid
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.HatesAcid).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.HatesAcid).Set();
            }
        }
    }
    public bool HatesCold
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.HatesCold).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.HatesCold).Set();
            }
        }
    }
    public bool HatesFire
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.HatesFire).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.HatesFire).Set();
            }
        }
    }
    public bool HeavyCurse
    {
        get
        {
            bool? heavyCurse = Get<BoolAttributeValue>(AttributeEnum.HeavyCurse).Get();
            return heavyCurse.HasValue && heavyCurse.Value;
        }
        set
        {
            if (value)
            {
                Get<BoolAttributeValue>(AttributeEnum.IsCursed).Set();
            }
            else if (!value)
            {
                Get<BoolAttributeValue>(AttributeEnum.IsCursed).Reset();
            }
        }
    }
    public bool HideType
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.HideType).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.HideType).Set();
            }
        }
    }
    public bool HoldLife
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.HoldLife).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.HoldLife).Set();
            }
        }
    }
    public bool IgnoreAcid
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.IgnoreAcid).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.IgnoreAcid).Set();
            }
        }
    }
    public bool IgnoreCold
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.IgnoreCold).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.IgnoreCold).Set();
            }
        }
    }
    public bool IgnoreElec
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.IgnoreElec).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.IgnoreElec).Set();
            }
        }
    }
    public bool IgnoreFire
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.IgnoreFire).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.IgnoreFire).Set();
            }
        }
    }
    public bool ImAcid
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.ImAcid).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.ImAcid).Set();
            }
        }
    }
    public bool ImCold
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.ImCold).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.ImCold).Set();
            }
        }
    }
    public bool ImElec
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.ImElec).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.ImElec).Set();
            }
        }
    }
    public bool ImFire
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.ImFire).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.ImFire).Set();
            }
        }
    }
    public bool Impact
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.Impact).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.Impact).Set();
            }
        }
    }
    public bool NoMagic
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.NoMagic).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.NoMagic).Set();
            }
        }
    }
    public bool NoTele
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.NoTele).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.NoTele).Set();
            }
        }
    }
    public bool PermaCurse
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.PermaCurse).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.PermaCurse).Set();
            }
        }
    }
    public int Radius
    {
        get
        {
            return Get<AdditionEffectiveAttributeValue>(AttributeEnum.Radius).Get();
        }
        set
        {
            Get<AdditionEffectiveAttributeValue>(AttributeEnum.Radius).Append(value);
        }
    }
    public bool Reflect
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.Reflect).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.Reflect).Set();
            }
        }
    }
    public bool Regen
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.Regen).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.Regen).Set();
            }
        }
    }
    public bool ResAcid
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.ResAcid).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.ResAcid).Set();
            }
        }
    }
    public bool ResBlind
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.ResBlind).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.ResBlind).Set();
            }
        }
    }
    public bool ResChaos
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.ResChaos).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.ResChaos).Set();
            }
        }
    }
    public bool ResCold
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.ResCold).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.ResCold).Set();
            }
        }
    }
    public bool ResConf
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.ResConf).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.ResConf).Set();
            }
        }
    }
    public bool ResDark
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.ResDark).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.ResDark).Set();
            }
        }
    }
    public bool ResDisen
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.ResDisen).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.ResDisen).Set();
            }
        }
    }
    public bool ResElec
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.ResElec).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.ResElec).Set();
            }
        }
    }
    public bool ResFear
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.ResFear).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.ResFear).Set();
            }
        }
    }
    public bool ResFire
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.ResFire).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.ResFire).Set();
            }
        }
    }
    public bool ResLight
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.ResLight).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.ResLight).Set();
            }
        }
    }
    public bool ResNether
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.ResNether).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.ResNether).Set();
            }
        }
    }
    public bool ResNexus
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.ResNexus).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.ResNexus).Set();
            }
        }
    }
    public bool ResPois
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.ResPois).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.ResPois).Set();
            }
        }
    }
    public bool ResShards
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.ResShards).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.ResShards).Set();
            }
        }
    }
    public bool ResSound
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.ResSound).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.ResSound).Set();
            }
        }
    }
    public int SavingThrow
    {
        get
        {
            return Get<AdditionEffectiveAttributeValue>(AttributeEnum.SavingThrow).Get();
        }
        set
        {
            Get<AdditionEffectiveAttributeValue>(AttributeEnum.SavingThrow).Set(value);
        }
    }
    public bool SeeInvis
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.SeeInvis).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.SeeInvis).Set();
            }
        }
    }
    public bool ShElec
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.ShElec).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.ShElec).Set();
            }
        }
    }
    public bool ShFire
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.ShFire).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.ShFire).Set();
            }
        }
    }
    public bool ShowMods
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.ShowMods).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.ShowMods).Set();
            }
        }
    }
    public bool SlayAnimal
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.SlayAnimal).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.SlayAnimal).Set();
            }
        }
    }
    public bool SlayDemon
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.SlayDemon).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.SlayDemon).Set();
            }
        }
    }
    public int SlayDragon
    {
        get
        {
            return Get<AdditionEffectiveAttributeValue>(AttributeEnum.SlayDragon).Get();
        }
        set
        {
            Get<AdditionEffectiveAttributeValue>(AttributeEnum.SlayDragon).Set(value);
        }
    }
    public bool SlayEvil
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.SlayEvil).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.SlayEvil).Set();
            }
        }
    }
    public bool SlayGiant
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.SlayGiant).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.SlayGiant).Set();
            }
        }
    }
    public bool SlayOrc
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.SlayOrc).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.SlayOrc).Set();
            }
        }
    }
    public bool SlayTroll
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.SlayTroll).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.SlayTroll).Set();
            }
        }
    }
    public bool SlayUndead
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.SlayUndead).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.SlayUndead).Set();
            }
        }
    }
    public bool SlowDigest
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.SlowDigest).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.SlowDigest).Set();
            }
        }
    }
    public bool SustCha
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.SustCha).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.SustCha).Set();
            }
        }
    }
    public bool SustCon
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.SustCon).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.SustCon).Set();
            }
        }
    }
    public bool SustDex
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.SustDex).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.SustDex).Set();
            }
        }
    }
    public bool SustInt
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.SustInt).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.SustInt).Set();
            }
        }
    }
    public bool SustStr
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.SustStr).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.SustStr).Set();
            }
        }
    }
    public bool SustWis
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.SustWis).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.SustWis).Set();
            }
        }
    }
    public bool Telepathy
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.Telepathy).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.Telepathy).Set();
            }
        }
    }
    public bool Teleport
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.Teleport).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.Teleport).Set();
            }
        }
    }
    public int TreasureRating
    {
        get
        {
            return Get<AdditionEffectiveAttributeValue>(AttributeEnum.TreasureRating).Get();
        }
        set
        {
            Get<AdditionEffectiveAttributeValue>(AttributeEnum.TreasureRating).Set(value);
        }
    }
    public int UseDevice
    {
        get
        {
            return Get<AdditionEffectiveAttributeValue>(AttributeEnum.UseDevice).Get();
        }
        set
        {
            Get<AdditionEffectiveAttributeValue>(AttributeEnum.UseDevice).Set(value);
        }
    }
    public int Value
    {
        get
        {
            return Get<AdditionEffectiveAttributeValue>(AttributeEnum.Value).Get();
        }
        set
        {
            Get<AdditionEffectiveAttributeValue>(AttributeEnum.Value).Append(value);
        }
    }
    public bool Valueless
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.Valueless).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.Valueless).Set();
            }
        }
    }
    public bool Vampiric
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.Vampiric).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.Vampiric).Set();
            }
        }
    }
    public int Vorpal1InChance
    {
        get
        {
            return Get<AdditionEffectiveAttributeValue>(AttributeEnum.Vorpal1InChance).Get();
        }
        set
        {
            Get<AdditionEffectiveAttributeValue>(AttributeEnum.Vorpal1InChance).Set(value);
        }
    }
    public int VorpalExtraAttacks1InChance
    {
        get
        {
            return Get<AdditionEffectiveAttributeValue>(AttributeEnum.VorpalExtraAttacks1InChance).Get();
        }
        set
        {
            Get<AdditionEffectiveAttributeValue>(AttributeEnum.VorpalExtraAttacks1InChance).Set(value);
        }
    }
    public int Weight
    {
        get
        {
            return Get<AdditionEffectiveAttributeValue>(AttributeEnum.Weight).Get();
        }
        set
        {
            Get<AdditionEffectiveAttributeValue>(AttributeEnum.Weight).Set(value);
        }
    }
    public bool Wraith
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.Wraith).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.Wraith).Set();
            }
        }
    }
    public bool XtraMight
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.XtraMight).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.XtraMight).Set();
            }
        }
    }
    public bool XtraShots
    {
        get
        {
            return Get<OrEffectiveAttributeValue>(AttributeEnum.XtraShots).Get();
        }
        set
        {
            if (value)
            {
                Get<OrEffectiveAttributeValue>(AttributeEnum.XtraShots).Set();
            }
        }
    }
    #endregion
}
