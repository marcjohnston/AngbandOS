// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents a set of properties where the value for each property is determined from many sources including a built-in writable property.  An additonal override value can also be applied to each property.
/// This is similar to a CSS style layering.  Each property type uses a different algorithm to determine the effective value.
/// Booleans are ORed together.  Any source with a true value will result in a true effective value.  The writable property defaults to false and can be set to true.
/// Integers are summed.  The writable property defaults to 0 and can be set to any integer value.
/// Reference properties only return the last reference with the writable property having the last say.  The writable property defaults to null and can be set to any reference value.
/// Properties that support override are nullable and writable.  A null value indicates that the effective property value will be be overriden.
/// 
/// Enhancements can be added to the effective property set.  Enhancements are always immutable through the use of the ReadOnlyPropertySet and can be keyed by a string.  Multiple enhancements can be added for the same key.
/// Keyed enhancements allow the enhancement to be removed.  Non-keyed enhancements cannot be removed.
/// Cloning is supported through immutability because the read-only property sets are immutable.
/// </summary>
[Serializable]
internal class EffectiveAttributeSet
{
    private Dictionary<string, List<ReadOnlyAttributeSet>> _enhancements = new Dictionary<string, List<ReadOnlyAttributeSet>>();
    private AttributeValue[] _defaultAttributeValues;
    private AttributeValue?[] _additiveAttributeValues;
    private AttributeValue?[] _fixedAttributeValues;
    private AttributeFactory[] _attributeFactories = new AttributeFactory[0];

    public EffectiveAttributeSet()
    {
        void RegisterPropertyFactory(AttributeEnum index, AttributeFactory propertyFactory)
        {
            int intIndex = (int)index;
            if (_attributeFactories.Length <= intIndex)
            {
                Array.Resize(ref _attributeFactories, intIndex + 1);
            }
            _attributeFactories[intIndex] = propertyFactory;
        }
        void RegisterBoolPropertyFactory(AttributeEnum index)
        {
            RegisterPropertyFactory(index, new BoolAttributeFactory(index));
        }
        void RegisterColorEnumPropertyFactory(AttributeEnum index)
        {
            RegisterPropertyFactory(index, new ColorEnumAttributeFactory(index));
        }
        void RegisterIntPropertyFactory(AttributeEnum index)
        {
            RegisterPropertyFactory(index, new IntAttributeFactory(index));
        }
        void RegisterReferencePropertyFactory<T>(AttributeEnum index) where T : class
        {
            RegisterPropertyFactory(index, new ReferenceAttributeFactory<T>(index));
        }

        RegisterReferencePropertyFactory<Activation>(AttributeEnum.Activation);
        RegisterBoolPropertyFactory(AttributeEnum.Aggravate);
        RegisterBoolPropertyFactory(AttributeEnum.AntiTheft);
        RegisterReferencePropertyFactory<ArtifactBias>(AttributeEnum.ArtifactBias);
        RegisterBoolPropertyFactory(AttributeEnum.ArtifactBiasSlayingDisabled);
        RegisterIntPropertyFactory(AttributeEnum.Attacks);
        RegisterIntPropertyFactory(AttributeEnum.BaseArmorClass);
        RegisterBoolPropertyFactory(AttributeEnum.Blessed);
        RegisterBoolPropertyFactory(AttributeEnum.Blows);
        RegisterIntPropertyFactory(AttributeEnum.BonusArmorClass);
        RegisterBoolPropertyFactory(AttributeEnum.BrandAcid);
        RegisterBoolPropertyFactory(AttributeEnum.BrandCold);
        RegisterBoolPropertyFactory(AttributeEnum.BrandElec);
        RegisterBoolPropertyFactory(AttributeEnum.BrandFire);
        RegisterBoolPropertyFactory(AttributeEnum.BrandPois);
        RegisterBoolPropertyFactory(AttributeEnum.CanApplyBlessedArtifactBias);
        RegisterBoolPropertyFactory(AttributeEnum.CanApplyBlowsBonus);
        RegisterBoolPropertyFactory(AttributeEnum.CanApplyBonusArmorClassMiscPower);
        RegisterBoolPropertyFactory(AttributeEnum.CanApplySlayingBonus);
        RegisterBoolPropertyFactory(AttributeEnum.CanProvideSheathOfElectricity);
        RegisterBoolPropertyFactory(AttributeEnum.CanProvideSheathOfFire);
        RegisterBoolPropertyFactory(AttributeEnum.CanReflectBoltsAndArrows);
        RegisterBoolPropertyFactory(AttributeEnum.Chaotic);
        RegisterIntPropertyFactory(AttributeEnum.Charisma);
        RegisterColorEnumPropertyFactory(AttributeEnum.Color);
        RegisterIntPropertyFactory(AttributeEnum.Constitution);
        RegisterIntPropertyFactory(AttributeEnum.DamageDice);
        RegisterIntPropertyFactory(AttributeEnum.Dexterity);
        RegisterIntPropertyFactory(AttributeEnum.DiceSides);
        RegisterIntPropertyFactory(AttributeEnum.DisarmTraps);
        RegisterBoolPropertyFactory(AttributeEnum.DrainExp);
        RegisterBoolPropertyFactory(AttributeEnum.DreadCurse);
        RegisterBoolPropertyFactory(AttributeEnum.EasyKnow);
        RegisterBoolPropertyFactory(AttributeEnum.Feather);
        RegisterBoolPropertyFactory(AttributeEnum.FreeAct);
        RegisterReferencePropertyFactory<string>(AttributeEnum.FriendlyName);
        RegisterBoolPropertyFactory(AttributeEnum.HatesAcid);
        RegisterBoolPropertyFactory(AttributeEnum.HatesCold);
        RegisterBoolPropertyFactory(AttributeEnum.HatesElectricity);
        RegisterBoolPropertyFactory(AttributeEnum.HatesFire);
        RegisterBoolPropertyFactory(AttributeEnum.HeavyCurse);
        RegisterBoolPropertyFactory(AttributeEnum.HideType);
        RegisterBoolPropertyFactory(AttributeEnum.HoldLife);
        RegisterBoolPropertyFactory(AttributeEnum.IgnoreAcid);
        RegisterBoolPropertyFactory(AttributeEnum.IgnoreCold);
        RegisterBoolPropertyFactory(AttributeEnum.IgnoreElec);
        RegisterBoolPropertyFactory(AttributeEnum.IgnoreFire);
        RegisterBoolPropertyFactory(AttributeEnum.ImAcid);
        RegisterBoolPropertyFactory(AttributeEnum.ImCold);
        RegisterBoolPropertyFactory(AttributeEnum.ImElec);
        RegisterBoolPropertyFactory(AttributeEnum.ImFire);
        RegisterBoolPropertyFactory(AttributeEnum.Impact);
        RegisterIntPropertyFactory(AttributeEnum.Infravision);
        RegisterIntPropertyFactory(AttributeEnum.Intelligence);
        RegisterBoolPropertyFactory(AttributeEnum.IsCursed);
        RegisterIntPropertyFactory(AttributeEnum.MeleeToHit);
        RegisterBoolPropertyFactory(AttributeEnum.NoMagic);
        RegisterBoolPropertyFactory(AttributeEnum.NoTele);
        RegisterBoolPropertyFactory(AttributeEnum.PermaCurse);
        RegisterIntPropertyFactory(AttributeEnum.Radius);
        RegisterIntPropertyFactory(AttributeEnum.RangedToHit);
        RegisterBoolPropertyFactory(AttributeEnum.Reflect);
        RegisterBoolPropertyFactory(AttributeEnum.Regen);
        RegisterBoolPropertyFactory(AttributeEnum.ResAcid);
        RegisterBoolPropertyFactory(AttributeEnum.ResBlind);
        RegisterBoolPropertyFactory(AttributeEnum.ResChaos);
        RegisterBoolPropertyFactory(AttributeEnum.ResCold);
        RegisterBoolPropertyFactory(AttributeEnum.ResConf);
        RegisterBoolPropertyFactory(AttributeEnum.ResDark);
        RegisterBoolPropertyFactory(AttributeEnum.ResDisen);
        RegisterBoolPropertyFactory(AttributeEnum.ResElec);
        RegisterBoolPropertyFactory(AttributeEnum.ResFear);
        RegisterBoolPropertyFactory(AttributeEnum.ResFire);
        RegisterBoolPropertyFactory(AttributeEnum.ResLight);
        RegisterBoolPropertyFactory(AttributeEnum.ResNether);
        RegisterBoolPropertyFactory(AttributeEnum.ResNexus);
        RegisterBoolPropertyFactory(AttributeEnum.ResPois);
        RegisterBoolPropertyFactory(AttributeEnum.ResShards);
        RegisterBoolPropertyFactory(AttributeEnum.ResSound);
        RegisterIntPropertyFactory(AttributeEnum.SavingThrow);
        RegisterIntPropertyFactory(AttributeEnum.Search);
        RegisterIntPropertyFactory(AttributeEnum.SearchFrequency);
        RegisterBoolPropertyFactory(AttributeEnum.SeeInvis);
        RegisterBoolPropertyFactory(AttributeEnum.ShElec);
        RegisterBoolPropertyFactory(AttributeEnum.ShFire);
        RegisterBoolPropertyFactory(AttributeEnum.ShowMods);
        RegisterBoolPropertyFactory(AttributeEnum.SlayAnimal);
        RegisterBoolPropertyFactory(AttributeEnum.SlayDemon);
        RegisterIntPropertyFactory(AttributeEnum.SlayDragon);
        RegisterBoolPropertyFactory(AttributeEnum.SlayEvil);
        RegisterBoolPropertyFactory(AttributeEnum.SlayGiant);
        RegisterBoolPropertyFactory(AttributeEnum.SlayOrc);
        RegisterBoolPropertyFactory(AttributeEnum.SlayTroll);
        RegisterBoolPropertyFactory(AttributeEnum.SlayUndead);
        RegisterBoolPropertyFactory(AttributeEnum.SlowDigest);
        RegisterIntPropertyFactory(AttributeEnum.Speed);
        RegisterIntPropertyFactory(AttributeEnum.Stealth);
        RegisterIntPropertyFactory(AttributeEnum.Strength);
        RegisterBoolPropertyFactory(AttributeEnum.SustCha);
        RegisterBoolPropertyFactory(AttributeEnum.SustCon);
        RegisterBoolPropertyFactory(AttributeEnum.SustDex);
        RegisterBoolPropertyFactory(AttributeEnum.SustInt);
        RegisterBoolPropertyFactory(AttributeEnum.SustStr);
        RegisterBoolPropertyFactory(AttributeEnum.SustWis);
        RegisterBoolPropertyFactory(AttributeEnum.Telepathy);
        RegisterBoolPropertyFactory(AttributeEnum.Teleport);
        RegisterIntPropertyFactory(AttributeEnum.ThrowingToHit);
        RegisterIntPropertyFactory(AttributeEnum.ToDamage);
        RegisterIntPropertyFactory(AttributeEnum.TreasureRating);
        RegisterIntPropertyFactory(AttributeEnum.Tunnel);
        RegisterIntPropertyFactory(AttributeEnum.UseDevice);
        RegisterIntPropertyFactory(AttributeEnum.Value);
        RegisterBoolPropertyFactory(AttributeEnum.Valueless);
        RegisterBoolPropertyFactory(AttributeEnum.Vampiric);
        RegisterIntPropertyFactory(AttributeEnum.Vorpal1InChance);
        RegisterIntPropertyFactory(AttributeEnum.VorpalExtraAttacks1InChance);
        RegisterIntPropertyFactory(AttributeEnum.Weight);
        RegisterIntPropertyFactory(AttributeEnum.Wisdom);
        RegisterBoolPropertyFactory(AttributeEnum.Wraith);
        RegisterBoolPropertyFactory(AttributeEnum.XtraMight);
        RegisterBoolPropertyFactory(AttributeEnum.XtraShots);

        // Generate the default property values.
        _defaultAttributeValues = new AttributeValue[_attributeFactories.Length];
        foreach (AttributeFactory itemPropertyFactory in _attributeFactories)
        {
            int index = (int)itemPropertyFactory.Index;
            _defaultAttributeValues[index] = itemPropertyFactory.Instantiate();
        }

        // Generate a writable property values.
        _additiveAttributeValues = new AttributeValue[_attributeFactories.Length];
        foreach (AttributeFactory itemPropertyFactory in _attributeFactories)
        {
            int index = (int)itemPropertyFactory.Index;
            _additiveAttributeValues[index] = null;
        }

        // Generate the override property values.
        _fixedAttributeValues = new AttributeValue[_attributeFactories.Length];
        foreach (AttributeFactory itemPropertyFactory in _attributeFactories)
        {
            int index = (int)itemPropertyFactory.Index;
            _fixedAttributeValues[index] = null;
        }
    }

    /// <summary>
    /// Returns a clone of the effective property set.  The clone will have the same enhancements, writable properties, and override properties as the original.
    /// </summary>
    /// <returns></returns>
    public EffectiveAttributeSet Clone()
    {
        // Build a writable property set.
        EffectiveAttributeSet effectivePropertySet = new EffectiveAttributeSet();

        // Clone the default attributes.  Since the array doesn't change and the values are immutable, we only need a reference to the entire array.
        effectivePropertySet._defaultAttributeValues = _defaultAttributeValues;

        // Copy the enhancements.  These are immutable, so we can simply add references to them.
        foreach (KeyValuePair<string, List<ReadOnlyAttributeSet>> enhancement in _enhancements)
        {
            foreach (ReadOnlyAttributeSet readOnlyPropertySet in enhancement.Value)
            {
                effectivePropertySet.AddEnhancement(enhancement.Key, readOnlyPropertySet);
            }
        }

        // Clone the writable properties.  We will need a new array, but immutability allows us to simply reference the values.
        effectivePropertySet._additiveAttributeValues = new AttributeValue?[_attributeFactories.Length];
        foreach (AttributeFactory itemPropertyFactory in _attributeFactories)
        {
            int index = (int)itemPropertyFactory.Index;
            effectivePropertySet._additiveAttributeValues[index] = _additiveAttributeValues[index];
        }

        // Clone the override properties.  We will need a new array, but immutability allows us to simply reference the values.
        effectivePropertySet._fixedAttributeValues = new AttributeValue?[_attributeFactories.Length];
        foreach (AttributeFactory itemPropertyFactory in _attributeFactories)
        {
            int index = (int)itemPropertyFactory.Index;
            effectivePropertySet._fixedAttributeValues[index] = _fixedAttributeValues[index];
        }

        return effectivePropertySet;
    }

    /// <summary>
    /// Return a read-only version of the effective property set.
    /// </summary>
    /// <returns></returns>
    public ReadOnlyAttributeSet ToReadOnly()
    {
        AttributeValue[] newProperties = new AttributeValue[_attributeFactories.Length];

        foreach (AttributeFactory itemPropertyFactory in _attributeFactories)
        {
            int index = (int)itemPropertyFactory.Index;
            newProperties[index] = ComputeEffectiveValue(index);
        }
        return new ReadOnlyAttributeSet(newProperties);
    }

    public void AddEnhancement(string key, ReadOnlyAttributeSet readOnlyPropertySet)
    {
        if (String.IsNullOrEmpty(key))
        {
            throw new Exception($"Cannot specify a blank or null key for {nameof(AddEnhancement)}");
        }
        AddEnhancementToDictionary(key, readOnlyPropertySet);
    }
    public void AddEnhancement(ReadOnlyAttributeSet readOnlyPropertySet)
    {
        AddEnhancementToDictionary("", readOnlyPropertySet);
    }
    public void RemoveEnhancements(string key)
    {
        if (String.IsNullOrEmpty(key))
        {
            throw new Exception($"Cannot specify a blank or null key for {nameof(RemoveEnhancements)}");
        }
        _enhancements.Remove(key);
    }

    public void ResetCurse()
    {
        SetBoolAttributeValue(AttributeEnum.IsCursed, null);
    }
    public void RemoveCurse()
    {
        SetBoolAttributeValue(AttributeEnum.IsCursed, false);
    }
    public void ResetHeavyCurse()
    {
        SetBoolAttributeValue(AttributeEnum.HeavyCurse, null);
    }
    public void RemoveHeavyCurse()
    {
        SetBoolAttributeValue(AttributeEnum.HeavyCurse, false);
    }

    public bool HasKeyedItemEnhancements(string key)
    {
        return _enhancements.ContainsKey(key);
    }

    /// <summary>
    /// Returns an attribute set for a specific key.  This is used to retrieve the value of an item factory for items that are not yet known.
    /// No override or writeable properties are applied.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public AttributeValue GetKeyedValue(AttributeEnum attributeEnum, string key)
    {
        if (String.IsNullOrEmpty(key))
        {
            throw new Exception($"Cannot specify a blank or null key for {nameof(ComputeEffectiveValue)}");
        }

        // Retrieve the index for the property.
        int index = (int)attributeEnum;

        // Get the factory default value.
        AttributeValue itemProperty = _attributeFactories[index].Instantiate();

        // For each key, there may be multiple item enhancements.
        foreach (ReadOnlyAttributeSet readOnlyPropertySet in _enhancements[key])
        {
            itemProperty = itemProperty.Merge(readOnlyPropertySet.GetValue(index));
        }
        return itemProperty;
    }

    public bool GetBoolAttributeValue(AttributeEnum attributeEnum)
    {
        int index = (int)attributeEnum;
        AttributeValue effectiveItemProperty = ComputeEffectiveValue(index);
        BoolAttributeValue boolPropertyValue = (BoolAttributeValue)effectiveItemProperty;
        bool value = boolPropertyValue.Value;
        return value;
    }

    public int GetIntAttributeValue(AttributeEnum attributeEnum)
    {
        int index = (int)attributeEnum;
        AttributeValue effectiveItemProperty = ComputeEffectiveValue(index);
        IntAttributeValue intPropertyValue = (IntAttributeValue)effectiveItemProperty;
        int value = intPropertyValue.Value;
        return value;
    }

    public ColorEnum GetColorAttributeValue(AttributeEnum attributeEnum)
    {
        int index = (int)attributeEnum;
        AttributeValue effectiveItemProperty = ComputeEffectiveValue(index);
        ColorEnumAttributeValue colorPropertyValue = (ColorEnumAttributeValue)effectiveItemProperty;
        ColorEnum value = colorPropertyValue.Value;
        return value;
    }

    public T? GetReferenceAttributeValue<T>(AttributeEnum attributeEnum) where T : class
    {
        int index = (int)attributeEnum;
        AttributeValue effectiveItemProperty = ComputeEffectiveValue(index);
        NullableReferenceAttributeValue<T> referencePropertyValue = (NullableReferenceAttributeValue<T>)effectiveItemProperty;
        T? value = referencePropertyValue.Value;
        return value;
    }

    /// <summary>
    /// Sets an attribute to a fixed value or; when null, reverts the attribute to the effective computed value.  This is done by setting the fixed attribute value.
    /// </summary>
    /// <param name="attributeEnum"></param>
    /// <param name="value"></param>
    public void SetReferenceAttributeValue<T>(AttributeEnum attributeEnum, T? propertyValue) where T : class
    {
        // Retrieve the index for the property.
        int index = (int)attributeEnum;
        _fixedAttributeValues[index] = propertyValue is null ? null : new NullableReferenceAttributeValue<T>(_attributeFactories[index], propertyValue);
    }

    /// <summary>
    /// Sets an attribute to a fixed value or; when null, reverts the attribute to the effective computed value.  This is done by setting the fixed attribute value.
    /// </summary>
    /// <param name="attributeEnum"></param>
    /// <param name="value"></param>
    public void SetIntAttributeValue(AttributeEnum attributeEnum, int? value)
    {
        int index = (int)attributeEnum;
        _fixedAttributeValues[index] = !value.HasValue ? null : new IntAttributeValue(_attributeFactories[index], value.Value);
    }

    /// <summary>
    /// Sets an attribute to a fixed value or; when null, reverts the attribute to the effective computed value.  This is done by setting the fixed attribute value.
    /// </summary>
    /// <param name="attributeEnum"></param>
    /// <param name="value"></param>
    public void SetColorAttributeValue(AttributeEnum attributeEnum, ColorEnum? value)
    {
        int index = (int)attributeEnum;
        _fixedAttributeValues[index] = !value.HasValue ? null : new ColorEnumAttributeValue(_attributeFactories[index], value.Value);
    }

    /// <summary>
    /// Sets an attribute to a fixed value or; when null, reverts the attribute to the effective computed value.  This is done by setting the fixed attribute value.
    /// </summary>
    /// <param name="attributeEnum"></param>
    /// <param name="value"></param>
    public void SetBoolAttributeValue(AttributeEnum attributeEnum, bool? value)
    {
        int index = (int)attributeEnum;
        _fixedAttributeValues[index] = !value.HasValue ? null : new BoolAttributeValue(_attributeFactories[index], value.Value);
    }

    /// <summary>
    /// Adds a quantity to an unfixed attribute.  This is done by incrementing the writable attribute value by 1.
    /// </summary>
    /// <param name="attributeEnum"></param>
    /// <param name="value"></param>
    public void AddIntAttributeValue(AttributeEnum attributeEnum, int value)
    {
        // Compute the index of the attribute.
        int index = (int)attributeEnum;

        // Retrieve the current writable value.
        IntAttributeValue? intAttributeValue = (IntAttributeValue?)_additiveAttributeValues[index];

        // Apply a zero value, if there is no current writable value.
        int currentValue = intAttributeValue?.Value ?? 0;

        // Add the value to the current writable value.
        _additiveAttributeValues[index] = new IntAttributeValue(_attributeFactories[index], currentValue + value);
    }

    private void AddEnhancementToDictionary(string key, ReadOnlyAttributeSet readOnlyPropertySet)
    {
        if (!_enhancements.TryGetValue(key, out List<ReadOnlyAttributeSet>? readOnlyPropertySetList))
        {
            readOnlyPropertySetList = new List<ReadOnlyAttributeSet>();
            _enhancements.Add(key, readOnlyPropertySetList);
        }
        readOnlyPropertySetList.Add(readOnlyPropertySet);
    }

    private AttributeValue ComputeEffectiveValue(int index)
    {
        // Determine if the value has been overriden.
        AttributeValue? overrideAttributeValue = _fixedAttributeValues[index];
        if (overrideAttributeValue is not null)
        {
            // It was, return the override value.
            return overrideAttributeValue;
        }

        // Start with the default value for us to start with.
        AttributeValue itemProperty = _defaultAttributeValues[index];

        // Merge all of the immutable enhancements across all of the keys.
        foreach (List<ReadOnlyAttributeSet> readOnlyPropertySetList in _enhancements.Values)
        {
            // For each key, there may be multiple item enhancements.
            foreach (ReadOnlyAttributeSet readOnlyPropertySet in readOnlyPropertySetList)
            {
                AttributeValue? attributeValue = readOnlyPropertySet.GetValue(index);

                // Check to see if there is a modifier specified.
                if (attributeValue is not null)
                {
                    // Merge the attribute value.
                    itemProperty = itemProperty.Merge(attributeValue);
                }
            }
        }

        // Merge the writable enhancements.
        AttributeValue? additiveAttributeValue = _additiveAttributeValues[index];
        if (additiveAttributeValue is not null)
        {
            itemProperty = itemProperty.Merge(additiveAttributeValue);
        }

        // Return the value.
        return itemProperty;
    }

    #region Properties
    public bool CanApplyBlessedArtifactBias
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.CanApplyBlessedArtifactBias);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.CanApplyBlessedArtifactBias, value);
        }
    }
    public bool ArtifactBiasSlayingDisabled
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.ArtifactBiasSlayingDisabled);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.ArtifactBiasSlayingDisabled, value);
        }
    }
    public bool CanApplyBlowsBonus
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.CanApplyBlowsBonus);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.CanApplyBlowsBonus, value);
        }
    }
    public bool CanReflectBoltsAndArrows
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.CanReflectBoltsAndArrows);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.CanReflectBoltsAndArrows, value);
        }
    }
    public bool CanApplySlayingBonus
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.CanApplySlayingBonus);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.CanApplySlayingBonus, value);
        }
    }
    public bool CanApplyBonusArmorClassMiscPower
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.CanApplyBonusArmorClassMiscPower);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.CanApplyBonusArmorClassMiscPower, value);
        }
    }
    public bool CanProvideSheathOfElectricity
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.CanProvideSheathOfElectricity);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.CanProvideSheathOfElectricity, value);
        }
    }
    public bool CanProvideSheathOfFire
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.CanProvideSheathOfFire);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.CanProvideSheathOfFire, value);
        }
    }
    public int MeleeToHit
    {
        get
        {
            return GetIntAttributeValue(AttributeEnum.MeleeToHit);
        }
        set
        {
            SetIntAttributeValue(AttributeEnum.MeleeToHit, value);
        }
    }
    public int BaseArmorClass
    {
        get
        {
            return GetIntAttributeValue(AttributeEnum.BaseArmorClass);
        }
        set
        {
            SetIntAttributeValue(AttributeEnum.BaseArmorClass, value);
        }
    }
    public int BonusArmorClass
    {
        get
        {
            return GetIntAttributeValue(AttributeEnum.BonusArmorClass);
        }
        set
        {
            SetIntAttributeValue(AttributeEnum.BonusArmorClass, value);
        }
    }
    public int DisarmTraps
    {
        get
        {
            return GetIntAttributeValue(AttributeEnum.DisarmTraps);
        }
        set
        {
            SetIntAttributeValue(AttributeEnum.DisarmTraps, value);
        }
    }
    public int ToDamage
    {
        get
        {
            return GetIntAttributeValue(AttributeEnum.ToDamage);
        }
        set
        {
            SetIntAttributeValue(AttributeEnum.ToDamage, value);
        }
    }
    public int Strength
    {
        get
        {
            return GetIntAttributeValue(AttributeEnum.Strength);
        }
        set
        {
            SetIntAttributeValue(AttributeEnum.Strength, value);
        }
    }
    public int Intelligence
    {
        get
        {
            return GetIntAttributeValue(AttributeEnum.Intelligence);
        }
        set
        {
            SetIntAttributeValue(AttributeEnum.Intelligence, value);
        }
    }
    public int Wisdom
    {
        get
        {
            return GetIntAttributeValue(AttributeEnum.Wisdom);
        }
        set
        {
            SetIntAttributeValue(AttributeEnum.Wisdom, value);
        }
    }
    public int Dexterity
    {
        get
        {
            return GetIntAttributeValue(AttributeEnum.Dexterity);
        }
        set
        {
            SetIntAttributeValue(AttributeEnum.Dexterity, value);
        }
    }
    public int Constitution
    {
        get
        {
            return GetIntAttributeValue(AttributeEnum.Constitution);
        }
        set
        {
            SetIntAttributeValue(AttributeEnum.Constitution, value);
        }
    }
    public int Charisma
    {
        get
        {
            return GetIntAttributeValue(AttributeEnum.Charisma);
        }
        set
        {
            SetIntAttributeValue(AttributeEnum.Charisma, value);
        }
    }
    public int Stealth
    {
        get
        {
            return GetIntAttributeValue(AttributeEnum.Stealth);
        }
        set
        {
            SetIntAttributeValue(AttributeEnum.Stealth, value);
        }
    }
    public int Search
    {
        get
        {
            return GetIntAttributeValue(AttributeEnum.Search);
        }
        set
        {
            SetIntAttributeValue(AttributeEnum.Search, value);
        }
    }
    public int Infravision
    {
        get
        {
            return GetIntAttributeValue(AttributeEnum.Infravision);
        }
        set
        {
            SetIntAttributeValue(AttributeEnum.Infravision, value);
        }
    }
    public int Tunnel
    {
        get
        {
            return GetIntAttributeValue(AttributeEnum.Tunnel);
        }
        set
        {
            SetIntAttributeValue(AttributeEnum.Tunnel, value);
        }
    }
    public int Attacks
    {
        get
        {
            return GetIntAttributeValue(AttributeEnum.Attacks);
        }
        set
        {
            SetIntAttributeValue(AttributeEnum.Attacks, value);
        }
    }
    public int Speed
    {
        get
        {
            return GetIntAttributeValue(AttributeEnum.Speed);
        }
        set
        {
            SetIntAttributeValue(AttributeEnum.Speed, value);
        }
    }
    public Activation? Activation
    {
        get
        {
            return GetReferenceAttributeValue<Activation>(AttributeEnum.Activation);
        }
        set
        {
            SetReferenceAttributeValue<Activation>(AttributeEnum.Activation, value);
        }
    }
    public bool Aggravate
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.Aggravate);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.Aggravate, value);
        }
    }
    public bool AntiTheft
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.AntiTheft);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.AntiTheft, value);
        }
    }
    public ArtifactBias? ArtifactBias
    {
        get
        {
            return GetReferenceAttributeValue<ArtifactBias>(AttributeEnum.ArtifactBias);
        }
        set
        {
            SetReferenceAttributeValue<ArtifactBias>(AttributeEnum.ArtifactBias, value);
        }
    }
    public bool Blessed
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.Blessed);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.Blessed, value);
        }
    }
    public bool BrandAcid
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.BrandAcid);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.BrandAcid, value);
        }
    }
    public bool BrandCold
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.BrandCold);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.BrandCold, value);
        }
    }
    public bool BrandElec
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.BrandElec);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.BrandElec, value);
        }
    }
    public bool BrandFire
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.BrandFire);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.BrandFire, value);
        }
    }
    public bool BrandPois
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.BrandPois);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.BrandPois, value);
        }
    }
    public bool Chaotic
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.Chaotic);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.Chaotic, value);
        }
    }
    public ColorEnum Color
    {
        get
        {
            return GetColorAttributeValue(AttributeEnum.Color);
        }
        set
        {
            SetColorAttributeValue(AttributeEnum.Color, value);
        }
    }
    public bool IsCursed
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.IsCursed);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.IsCursed, value);
        }
    }
    public int DamageDice
    {
        get
        {
            return GetIntAttributeValue(AttributeEnum.DamageDice);
        }
        set
        {
            SetIntAttributeValue(AttributeEnum.DamageDice, value);
        }
    }
    public int DiceSides
    {
        get
        {
            return GetIntAttributeValue(AttributeEnum.DiceSides);
        }
        set
        {
            SetIntAttributeValue(AttributeEnum.DiceSides, value);
        }
    }
    public bool DrainExp
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.DrainExp);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.DrainExp, value);
        }
    }
    public bool DreadCurse
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.DreadCurse);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.DreadCurse, value);
        }
    }
    public bool EasyKnow
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.EasyKnow);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.EasyKnow, value);
        }
    }
    public bool Feather
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.Feather);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.Feather, value);
        }
    }
    public bool FreeAct
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.FreeAct);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.FreeAct, value);
        }
    }
    public string? FriendlyName
    {
        get
        {
            return GetReferenceAttributeValue<string>(AttributeEnum.FriendlyName);
        }
        set
        {
            SetReferenceAttributeValue<string>(AttributeEnum.FriendlyName, value);
        }
    }
    public bool HatesElectricity
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.HatesElectricity);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.HatesElectricity, value);
        }
    }
    public bool HatesAcid
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.HatesAcid);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.HatesAcid, value);
        }
    }
    public bool HatesCold
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.HatesCold);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.HatesCold, value);
        }
    }
    public bool HatesFire
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.HatesFire);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.HatesFire, value);
        }
    }
    public bool HeavyCurse
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.HeavyCurse);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.HeavyCurse, value);
        }
    }
    public bool HideType
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.HideType);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.HideType, value);
        }
    }
    public bool HoldLife
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.HoldLife);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.HoldLife, value);
        }
    }
    public bool IgnoreAcid
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.IgnoreAcid);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.IgnoreAcid, value);
        }
    }
    public bool IgnoreCold
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.IgnoreCold);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.IgnoreCold, value);
        }
    }
    public bool IgnoreElec
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.IgnoreElec);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.IgnoreElec, value);
        }
    }
    public bool IgnoreFire
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.IgnoreFire);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.IgnoreFire, value);
        }
    }
    public bool ImAcid
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.ImAcid);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.ImAcid, value);
        }
    }
    public bool ImCold
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.ImCold);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.ImCold, value);
        }
    }
    public bool ImElec
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.ImElec);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.ImElec, value);
        }
    }
    public bool ImFire
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.ImFire);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.ImFire, value);
        }
    }
    public bool Impact
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.Impact);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.Impact, value);
        }
    }
    public bool NoMagic
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.NoMagic);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.NoMagic, value);
        }
    }
    public bool NoTele
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.NoTele);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.NoTele, value);
        }
    }
    public bool PermaCurse
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.PermaCurse);
        }
        set
        {
            SetBoolAttributeValue(AttributeEnum.PermaCurse, value);
        }
    }
    public int Radius
    {
        get
        {
            return GetIntAttributeValue(AttributeEnum.Radius);
        }
        set
        {
            SetIntAttributeValue(AttributeEnum.Radius, value);
        }
    }
    public bool Reflect
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.Reflect);
        }
    }
    public bool Regen
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.Regen);
        }
    }
    public bool ResAcid
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.ResAcid);
        }
    }
    public bool ResBlind
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.ResBlind);
        }
    }
    public bool ResChaos
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.ResChaos);
        }
    }
    public bool ResCold
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.ResCold);
        }
    }
    public bool ResConf
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.ResConf);
        }
    }
    public bool ResDark
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.ResDark);
        }
    }
    public bool ResDisen
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.ResDisen);
        }
    }
    public bool ResElec
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.ResElec);
        }
    }
    public bool ResFear
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.ResFear);
        }
    }
    public bool ResFire
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.ResFire);
        }
    }
    public bool ResLight
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.ResLight);
        }
    }
    public bool ResNether
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.ResNether);
        }
    }
    public bool ResNexus
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.ResNexus);
        }
    }
    public bool ResPois
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.ResPois);
        }
    }
    public bool ResShards
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.ResShards);
        }
    }
    public bool ResSound
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.ResSound);
        }
    }
    public bool SeeInvis
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.SeeInvis);
        }
    }
    public bool ShElec
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.ShElec);
        }
    }
    public bool ShFire
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.ShFire);
        }
    }
    public bool ShowMods
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.ShowMods);
        }
    }
    public bool SlayAnimal
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.SlayAnimal);
        }
    }
    public bool SlayDemon
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.SlayDemon);
        }
    }
    public int SlayDragon
    {
        get
        {
            return GetIntAttributeValue(AttributeEnum.SlayDragon);
        }
    }
    public bool SlayEvil
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.SlayEvil);
        }
    }
    public bool SlayGiant
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.SlayGiant);
        }
    }
    public bool SlayOrc
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.SlayOrc);
        }
    }
    public bool SlayTroll
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.SlayTroll);
        }
    }
    public bool SlayUndead
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.SlayUndead);
        }
    }
    public bool SlowDigest
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.SlowDigest);
        }
    }
    public bool SustCha
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.SustCha);
        }
    }
    public bool SustCon
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.SustCon);
        }
    }
    public bool SustDex
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.SustDex);
        }
    }
    public bool SustInt
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.SustInt);
        }
    }
    public bool SustStr
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.SustStr);
        }
    }
    public bool SustWis
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.SustWis);
        }
    }
    public bool Telepathy
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.Telepathy);
        }
    }
    public bool Teleport
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.Teleport);
        }
    }
    public int TreasureRating
    {
        get
        {
            return GetIntAttributeValue(AttributeEnum.TreasureRating);
        }
    }
    public int Value
    {
        get
        {
            return GetIntAttributeValue(AttributeEnum.Value);
        }
        set
        {
            SetIntAttributeValue(AttributeEnum.Value, value);
        }
    }
    public bool Valueless
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.Valueless);
        }
    }
    public bool Vampiric
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.Vampiric);
        }
    }
    public int Vorpal1InChance
    {
        get
        {
            return GetIntAttributeValue(AttributeEnum.Vorpal1InChance);
        }
    }
    public int VorpalExtraAttacks1InChance
    {
        get
        {
            return GetIntAttributeValue(AttributeEnum.VorpalExtraAttacks1InChance);
        }
    }
    public int Weight
    {
        get
        {
            return GetIntAttributeValue(AttributeEnum.Weight);
        }
    }
    public bool Wraith
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.Wraith);
        }
    }
    public bool XtraMight
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.XtraMight);
        }
    }
    public bool XtraShots
    {
        get
        {
            return GetBoolAttributeValue(AttributeEnum.XtraShots);
        }
    }
    #endregion
}