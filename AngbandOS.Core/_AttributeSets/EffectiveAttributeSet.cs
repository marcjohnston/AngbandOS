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
    private AttributeValue[] _writeProperties;
    private AttributeValue[] _overrideProperties;
    private AttributeFactory[] _propertyFactories = new AttributeFactory[0];

    public EffectiveAttributeSet()
    {
        void RegisterPropertyFactory(AttributeEnum index, AttributeFactory propertyFactory)
        {
            int intIndex = (int)index;
            if (_propertyFactories.Length <= intIndex)
            {
                Array.Resize(ref _propertyFactories, intIndex + 1);
            }
            _propertyFactories[intIndex] = propertyFactory;
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

        RegisterBoolPropertyFactory(AttributeEnum.CanApplyBlessedArtifactBias);
        RegisterBoolPropertyFactory(AttributeEnum.CanApplyArtifactBiasSlaying);
        RegisterBoolPropertyFactory(AttributeEnum.CanApplyBlowsBonus);
        RegisterBoolPropertyFactory(AttributeEnum.CanReflectBoltsAndArrows);
        RegisterBoolPropertyFactory(AttributeEnum.CanApplySlayingBonus);
        RegisterBoolPropertyFactory(AttributeEnum.CanApplyBonusArmorClassMiscPower);
        RegisterBoolPropertyFactory(AttributeEnum.CanProvideSheathOfElectricity);
        RegisterBoolPropertyFactory(AttributeEnum.CanProvideSheathOfFire);
        RegisterIntPropertyFactory(AttributeEnum.BonusHits);
        RegisterIntPropertyFactory(AttributeEnum.BonusArmorClass);
        RegisterIntPropertyFactory(AttributeEnum.BonusDamage);
        RegisterIntPropertyFactory(AttributeEnum.BonusStrength);
        RegisterIntPropertyFactory(AttributeEnum.BonusIntelligence);
        RegisterIntPropertyFactory(AttributeEnum.BonusWisdom);
        RegisterIntPropertyFactory(AttributeEnum.BonusDexterity);
        RegisterIntPropertyFactory(AttributeEnum.BonusConstitution);
        RegisterIntPropertyFactory(AttributeEnum.BonusCharisma);
        RegisterIntPropertyFactory(AttributeEnum.BonusStealth);
        RegisterIntPropertyFactory(AttributeEnum.BonusSearch);
        RegisterIntPropertyFactory(AttributeEnum.BonusInfravision);
        RegisterIntPropertyFactory(AttributeEnum.BonusTunnel);
        RegisterIntPropertyFactory(AttributeEnum.BonusAttacks);
        RegisterIntPropertyFactory(AttributeEnum.BonusSpeed);
        RegisterReferencePropertyFactory<Activation>(AttributeEnum.Activation);
        RegisterBoolPropertyFactory(AttributeEnum.Aggravate);
        RegisterBoolPropertyFactory(AttributeEnum.AntiTheft);
        RegisterReferencePropertyFactory<ArtifactBias>(AttributeEnum.ArtifactBias);
        RegisterBoolPropertyFactory(AttributeEnum.Blessed);
        RegisterBoolPropertyFactory(AttributeEnum.Blows);
        RegisterBoolPropertyFactory(AttributeEnum.BrandAcid);
        RegisterBoolPropertyFactory(AttributeEnum.BrandCold);
        RegisterBoolPropertyFactory(AttributeEnum.BrandElec);
        RegisterBoolPropertyFactory(AttributeEnum.BrandFire);
        RegisterBoolPropertyFactory(AttributeEnum.BrandPois);
        RegisterBoolPropertyFactory(AttributeEnum.Chaotic);
        RegisterColorEnumPropertyFactory(AttributeEnum.Color);
        RegisterIntPropertyFactory(AttributeEnum.Cost);
        RegisterBoolPropertyFactory(AttributeEnum.IsCursed);
        RegisterIntPropertyFactory(AttributeEnum.DamageDice);
        RegisterIntPropertyFactory(AttributeEnum.DiceSides);
        RegisterBoolPropertyFactory(AttributeEnum.DrainExp);
        RegisterBoolPropertyFactory(AttributeEnum.DreadCurse);
        RegisterBoolPropertyFactory(AttributeEnum.EasyKnow);
        RegisterBoolPropertyFactory(AttributeEnum.Feather);
        RegisterReferencePropertyFactory<string>(AttributeEnum.FriendlyName);
        RegisterBoolPropertyFactory(AttributeEnum.FreeAct);
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
        RegisterBoolPropertyFactory(AttributeEnum.NoMagic);
        RegisterBoolPropertyFactory(AttributeEnum.NoTele);
        RegisterBoolPropertyFactory(AttributeEnum.PermaCurse);
        RegisterIntPropertyFactory(AttributeEnum.Radius);
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
        RegisterBoolPropertyFactory(AttributeEnum.Search);
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
        RegisterBoolPropertyFactory(AttributeEnum.SustCha);
        RegisterBoolPropertyFactory(AttributeEnum.SustCon);
        RegisterBoolPropertyFactory(AttributeEnum.SustDex);
        RegisterBoolPropertyFactory(AttributeEnum.SustInt);
        RegisterBoolPropertyFactory(AttributeEnum.SustStr);
        RegisterBoolPropertyFactory(AttributeEnum.SustWis);
        RegisterBoolPropertyFactory(AttributeEnum.Telepathy);
        RegisterBoolPropertyFactory(AttributeEnum.Teleport);
        RegisterIntPropertyFactory(AttributeEnum.TreasureRating);
        RegisterIntPropertyFactory(AttributeEnum.Value);
        RegisterBoolPropertyFactory(AttributeEnum.Valueless);
        RegisterBoolPropertyFactory(AttributeEnum.Vampiric);
        RegisterIntPropertyFactory(AttributeEnum.Vorpal1InChance);
        RegisterIntPropertyFactory(AttributeEnum.VorpalExtraAttacks1InChance);
        RegisterIntPropertyFactory(AttributeEnum.Weight);
        RegisterBoolPropertyFactory(AttributeEnum.Wraith);
        RegisterBoolPropertyFactory(AttributeEnum.XtraMight);
        RegisterBoolPropertyFactory(AttributeEnum.XtraShots);

        // Generate a writable property values.
        _writeProperties = new AttributeValue[_propertyFactories.Length];
        foreach (AttributeFactory itemPropertyFactory in _propertyFactories)
        {
            int index = (int)itemPropertyFactory.Index;
            _writeProperties[index] = itemPropertyFactory.Instantiate();
        }

        // Generate the override property values.
        _overrideProperties = new AttributeValue[_propertyFactories.Length];
        foreach (AttributeFactory itemPropertyFactory in _propertyFactories)
        {
            int index = (int)itemPropertyFactory.Index;
            _overrideProperties[index] = itemPropertyFactory.InstantiateNullable();
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

        // Copy the enhancements.  These are immutable, so we can simply reference them.
        foreach (KeyValuePair<string, List<ReadOnlyAttributeSet>> enhancement in _enhancements)
        {
            foreach (ReadOnlyAttributeSet readOnlyPropertySet in enhancement.Value)
            {
                effectivePropertySet.AddEnhancement(enhancement.Key, readOnlyPropertySet);
            }
        }

        // Clone the writable properties.
        effectivePropertySet._writeProperties = new AttributeValue[_propertyFactories.Length];
        foreach (AttributeFactory itemPropertyFactory in _propertyFactories)
        {
            int index = (int)itemPropertyFactory.Index;
            effectivePropertySet._writeProperties[index] = _writeProperties[index].Clone();
        }

        // Clone the override properties.
        effectivePropertySet._overrideProperties = new AttributeValue[_propertyFactories.Length];
        foreach (AttributeFactory itemPropertyFactory in _propertyFactories)
        {
            int index = (int)itemPropertyFactory.Index;
            effectivePropertySet._overrideProperties[index] = _overrideProperties[index].Clone();
        }

        return effectivePropertySet;
    }

    /// <summary>
    /// Return a read-only version of the effective property set.
    /// </summary>
    /// <returns></returns>
    public ReadOnlyAttributeSet ToReadOnly()
    {
        AttributeValue[] newProperties = new AttributeValue[_propertyFactories.Length];

        foreach (AttributeFactory itemPropertyFactory in _propertyFactories)
        {
            int index = (int)itemPropertyFactory.Index;
            newProperties[index] = GetValue(itemPropertyFactory.Index);
        }
        return new ReadOnlyAttributeSet(newProperties);
    }

    public void AddEnhancement(string key, ReadOnlyAttributeSet readOnlyPropertySet) 
    {
        if (String.IsNullOrEmpty(key))
        {
            throw new Exception($"Cannot specify a blank or null key for {nameof(AddEnhancement)}");
        }
        if (!_enhancements.TryGetValue(key, out List<ReadOnlyAttributeSet>? readOnlyPropertySetList))
        {
            readOnlyPropertySetList = new List<ReadOnlyAttributeSet>();
            _enhancements.Add(key, readOnlyPropertySetList);
        }
        readOnlyPropertySetList.Add(readOnlyPropertySet);
    }
    public void AddEnhancement(ReadOnlyAttributeSet readOnlyPropertySet)
    {
        AddEnhancement("", readOnlyPropertySet);
    }
    public void RemoveEnhancements(string key)
    {
        if (String.IsNullOrEmpty(key))
        {
            throw new Exception($"Cannot specify a blank or null key for {nameof(RemoveEnhancements)}");
        }
        _enhancements.Remove(key);
    }

    public void OverrideBoolValue(AttributeEnum propertyEnum, bool? value)
    {
        int index = (int)propertyEnum;
        _overrideProperties[index] = new NullableBoolAttributeValue(value.HasValue ? value.Value : null);
    }

    public void OverrideIntValue(AttributeEnum propertyEnum, int? value)
    {
        int index = (int)propertyEnum;
        _overrideProperties[index] = new NullableIntAttributeValue(value.HasValue ? value.Value : null);
    }

    public void ResetCurse()
    {
        OverrideBoolValue(AttributeEnum.IsCursed, null);
    }
    public void RemoveCurse()
    {
        OverrideBoolValue(AttributeEnum.IsCursed, false);
    }
    public void ResetHeavyCurse()
    {
        OverrideBoolValue(AttributeEnum.HeavyCurse, null);
    }
    public void RemoveHeavyCurse()
    {
        OverrideBoolValue(AttributeEnum.HeavyCurse, false);
    }

    public bool HasKeyedItemEnhancements(string key)
    {
        return _enhancements.ContainsKey(key);
    }

    private AttributeValue GetValue(AttributeEnum propertyEnum)
    {
        // Retrieve the index for the property.
        int index = (int)propertyEnum;

        // Retrieve the factory.
        AttributeFactory itemPropertyFactory = _propertyFactories[index];

        // Retrieve a default value from the factory.
        AttributeValue itemProperty = itemPropertyFactory.Instantiate();

        // Merge all of the immutable enhancements across all of the keys.
        foreach (List<ReadOnlyAttributeSet> readOnlyPropertySetList in _enhancements.Values)
        {
            // For each key, there may be multiple item enhancements.
            foreach (ReadOnlyAttributeSet readOnlyPropertySet in readOnlyPropertySetList)
            {
                itemProperty = itemProperty.Merge(readOnlyPropertySet.GetValue(propertyEnum));
            }
        }

        // Merge the writable enhancements.
        itemProperty = itemProperty.Merge(_writeProperties[index]);

        // Override the enhancements.
        itemProperty = itemProperty.Merge(_overrideProperties[index]);

        // Return the value.
        return itemProperty;
    }

    public bool GetBoolValue(AttributeEnum propertyEnum)
    {
        AttributeValue effectiveItemProperty = GetValue(propertyEnum);
        BoolAttributeValue boolPropertyValue = (BoolAttributeValue)effectiveItemProperty;
        bool value = boolPropertyValue.Value;
        return value;
    }

    public int GetIntValue(AttributeEnum propertyEnum)
    {
        AttributeValue effectiveItemProperty = GetValue(propertyEnum);
        IntAttributeValue intPropertyValue = (IntAttributeValue)effectiveItemProperty;
        int value = intPropertyValue.Value;
        return value;
    }

    public ColorEnum GetColorValue(AttributeEnum propertyEnum)
    {
        AttributeValue effectiveItemProperty = GetValue(propertyEnum);
        ColorEnumAttributeValue colorPropertyValue = (ColorEnumAttributeValue)effectiveItemProperty;
        ColorEnum value = colorPropertyValue.Value;
        return value;
    }

    public T? GetReferenceValue<T>(AttributeEnum propertyEnum) where T : class
    {
        AttributeValue effectiveItemProperty = GetValue(propertyEnum);
        NullableReferenceAttributeValue<T> referencePropertyValue = (NullableReferenceAttributeValue<T>)effectiveItemProperty;
        T? value = referencePropertyValue.Value;
        return value;
    }

    private void SetValue(AttributeEnum propertyEnum, AttributeValue propertyValue)
    {
        // Retrieve the index for the property.
        int index = (int)propertyEnum;

        _writeProperties[index] = propertyValue;
    }

    public void SetReferenceValue<T>(AttributeEnum propertyEnum, T? propertyValue) where T : class
    {
        // Retrieve the index for the property.
        int index = (int)propertyEnum;

        _writeProperties[index] = new NullableReferenceAttributeValue<T>(propertyValue);
    }

    public void SetIntValue(AttributeEnum propertyEnum, int value)
    {
        SetValue(propertyEnum, new IntAttributeValue(value));
    }

    public void SetColorValue(AttributeEnum propertyEnum, ColorEnum value)
    {
        SetValue(propertyEnum, new ColorEnumAttributeValue(value));
    }

    public void AddIntValue(AttributeEnum propertyEnum, int value)
    {
        SetValue(propertyEnum, new IntAttributeValue(GetIntValue(propertyEnum) + value));
    }

    public void SetBoolValue(AttributeEnum propertyEnum, bool value)
    {
        SetValue(propertyEnum, new BoolAttributeValue(value));
    }

    #region Properties
    public bool CanApplyBlessedArtifactBias
    {
        get
        {
            return GetBoolValue(AttributeEnum.CanApplyBlessedArtifactBias);
        }
        set
        {
            SetBoolValue(AttributeEnum.CanApplyBlessedArtifactBias, value);
        }
    }
    public bool CanApplyArtifactBiasSlaying
    {
        get
        {
            return GetBoolValue(AttributeEnum.CanApplyArtifactBiasSlaying);
        }
        set
        {
            SetBoolValue(AttributeEnum.CanApplyArtifactBiasSlaying, value);
        }
    }
    public bool CanApplyBlowsBonus
    {
        get
        {
            return GetBoolValue(AttributeEnum.CanApplyBlowsBonus);
        }
        set
        {
            SetBoolValue(AttributeEnum.CanApplyBlowsBonus, value);
        }
    }
    public bool CanReflectBoltsAndArrows
    {
        get
        {
            return GetBoolValue(AttributeEnum.CanReflectBoltsAndArrows);
        }
        set
        {
            SetBoolValue(AttributeEnum.CanReflectBoltsAndArrows, value);
        }
    }
    public bool CanApplySlayingBonus
    {
        get
        {
            return GetBoolValue(AttributeEnum.CanApplySlayingBonus);
        }
        set
        {
            SetBoolValue(AttributeEnum.CanApplySlayingBonus, value);
        }
    }
    public bool CanApplyBonusArmorClassMiscPower
    {
        get
        {
            return GetBoolValue(AttributeEnum.CanApplyBonusArmorClassMiscPower);
        }
        set
        {
            SetBoolValue(AttributeEnum.CanApplyBonusArmorClassMiscPower, value);
        }
    }
    public bool CanProvideSheathOfElectricity
    {
        get
        {
            return GetBoolValue(AttributeEnum.CanProvideSheathOfElectricity);
        }
        set
        {
            SetBoolValue(AttributeEnum.CanProvideSheathOfElectricity, value);
        }
    }
    public bool CanProvideSheathOfFire
    {
        get
        {
            return GetBoolValue(AttributeEnum.CanProvideSheathOfFire);
        }
        set
        {
            SetBoolValue(AttributeEnum.CanProvideSheathOfFire, value);
        }
    }
    public int BonusHits
    {
        get
        {
            return GetIntValue(AttributeEnum.BonusHits);
        }
        set
        {
            SetIntValue(AttributeEnum.BonusHits, value);
        }
    }
    public int BonusArmorClass
    {
        get
        {
            return GetIntValue(AttributeEnum.BonusArmorClass);
        }
        set
        {
            SetIntValue(AttributeEnum.BonusArmorClass, value);
        }
    }
    public int BonusDamage
    {
        get
        {
            return GetIntValue(AttributeEnum.BonusDamage);
        }
        set
        {
            SetIntValue(AttributeEnum.BonusDamage, value);
        }
    }
    public int BonusStrength
    {
        get
        {
            return GetIntValue(AttributeEnum.BonusStrength);
        }
        set
        {
            SetIntValue(AttributeEnum.BonusStrength, value);
        }
    }
    public int BonusIntelligence
    {
        get
        {
            return GetIntValue(AttributeEnum.BonusIntelligence);
        }
        set
        {
            SetIntValue(AttributeEnum.BonusIntelligence, value);
        }
    }
    public int BonusWisdom
    {
        get
        {
            return GetIntValue(AttributeEnum.BonusWisdom);
        }
        set
        {
            SetIntValue(AttributeEnum.BonusWisdom, value);
        }
    }
    public int BonusDexterity
    {
        get
        {
            return GetIntValue(AttributeEnum.BonusDexterity);
        }
        set
        {
            SetIntValue(AttributeEnum.BonusDexterity, value);
        }
    }
    public int BonusConstitution
    {
        get
        {
            return GetIntValue(AttributeEnum.BonusConstitution);
        }
        set
        {
            SetIntValue(AttributeEnum.BonusConstitution, value);
        }
    }
    public int BonusCharisma
    {
        get
        {
            return GetIntValue(AttributeEnum.BonusCharisma);
        }
        set
        {
            SetIntValue(AttributeEnum.BonusCharisma, value);
        }
    }
    public int BonusStealth
    {
        get
        {
            return GetIntValue(AttributeEnum.BonusStealth);
        }
        set
        {
            SetIntValue(AttributeEnum.BonusStealth, value);
        }
    }
    public int BonusSearch
    {
        get
        {
            return GetIntValue(AttributeEnum.BonusSearch);
        }
        set
        {
            SetIntValue(AttributeEnum.BonusSearch, value);
        }
    }
    public int BonusInfravision
    {
        get
        {
            return GetIntValue(AttributeEnum.BonusInfravision);
        }
        set
        {
            SetIntValue(AttributeEnum.BonusInfravision, value);
        }
    }
    public int BonusTunnel
    {
        get
        {
            return GetIntValue(AttributeEnum.BonusTunnel);
        }
        set
        {
            SetIntValue(AttributeEnum.BonusTunnel, value);
        }
    }
    public int BonusAttacks
    {
        get
        {
            return GetIntValue(AttributeEnum.BonusAttacks);
        }
        set
        {
            SetIntValue(AttributeEnum.BonusAttacks, value);
        }
    }
    public int BonusSpeed
    {
        get
        {
            return GetIntValue(AttributeEnum.BonusSpeed);
        }
        set
        {
            SetIntValue(AttributeEnum.BonusSpeed, value);
        }
    }
    public Activation? Activation
    {
        get
        {
            return GetReferenceValue<Activation>(AttributeEnum.Activation);
        }
        set
        {
            SetReferenceValue<Activation>(AttributeEnum.Activation, value);
        }
    }
    public bool Aggravate
    {
        get
        {
            return GetBoolValue(AttributeEnum.Aggravate);
        }
        set
        {
            SetBoolValue(AttributeEnum.Aggravate, value);
        }
    }
    public bool AntiTheft
    {
        get
        {
            return GetBoolValue(AttributeEnum.AntiTheft);
        }
        set
        {
            SetBoolValue(AttributeEnum.AntiTheft, value);
        }
    }
    public ArtifactBias? ArtifactBias
    {
        get
        {
            return GetReferenceValue<ArtifactBias>(AttributeEnum.ArtifactBias);
        }
        set
        {
            SetReferenceValue<ArtifactBias>(AttributeEnum.ArtifactBias, value);
        }
    }
    public bool Blessed
    {
        get
        {
            return GetBoolValue(AttributeEnum.Blessed);
        }
        set
        {
            SetBoolValue(AttributeEnum.Blessed, value);
        }
    }
    public bool BrandAcid
    {
        get
        {
            return GetBoolValue(AttributeEnum.BrandAcid);
        }
        set
        {
            SetBoolValue(AttributeEnum.BrandAcid, value);
        }
    }
    public bool BrandCold
    {
        get
        {
            return GetBoolValue(AttributeEnum.BrandCold);
        }
        set
        {
            SetBoolValue(AttributeEnum.BrandCold, value);
        }
    }
    public bool BrandElec
    {
        get
        {
            return GetBoolValue(AttributeEnum.BrandElec);
        }
        set
        {
            SetBoolValue(AttributeEnum.BrandElec, value);
        }
    }
    public bool BrandFire
    {
        get
        {
            return GetBoolValue(AttributeEnum.BrandFire);
        }
        set
        {
            SetBoolValue(AttributeEnum.BrandFire, value);
        }
    }
    public bool BrandPois
    {
        get
        {
            return GetBoolValue(AttributeEnum.BrandPois);
        }
        set
        {
            SetBoolValue(AttributeEnum.BrandPois, value);
        }
    }
    public bool Chaotic
    {
        get
        {
            return GetBoolValue(AttributeEnum.Chaotic);
        }
        set
        {
            SetBoolValue(AttributeEnum.Chaotic, value);
        }
    }
    public ColorEnum Color
    {
        get
        {
            return GetColorValue(AttributeEnum.Color);
        }
        set
        {
            SetColorValue(AttributeEnum.Color, value);
        }
    }
    public int Cost
    {
        get
        {
            return GetIntValue(AttributeEnum.Cost);
        }
        set
        {
            SetIntValue(AttributeEnum.Cost, value);
        }
    }
    public bool IsCursed
    {
        get
        {
            return GetBoolValue(AttributeEnum.IsCursed);
        }
        set
        {
            SetBoolValue(AttributeEnum.IsCursed, value);
        }
    }
    public int DamageDice
    {
        get
        {
            return GetIntValue(AttributeEnum.DamageDice);
        }
        set
        {
            SetIntValue(AttributeEnum.DamageDice, value);
        }
    }
    public int DiceSides
    {
        get
        {
            return GetIntValue(AttributeEnum.DiceSides);
        }
        set
        {
            SetIntValue(AttributeEnum.DiceSides, value);
        }
    }
    public bool DrainExp
    {
        get
        {
            return GetBoolValue(AttributeEnum.DrainExp);
        }
        set
        {
            SetBoolValue(AttributeEnum.DrainExp, value);
        }
    }
    public bool DreadCurse
    {
        get
        {
            return GetBoolValue(AttributeEnum.DreadCurse);
        }
        set
        {
            SetBoolValue(AttributeEnum.DreadCurse, value);
        }
    }
    public bool EasyKnow
    {
        get
        {
            return GetBoolValue(AttributeEnum.EasyKnow);
        }
        set
        {
            SetBoolValue(AttributeEnum.EasyKnow, value);
        }
    }
    public bool Feather
    {
        get
        {
            return GetBoolValue(AttributeEnum.Feather);
        }
        set
        {
            SetBoolValue(AttributeEnum.Feather, value);
        }
    }
    public bool FreeAct
    {
        get
        {
            return GetBoolValue(AttributeEnum.FreeAct);
        }
        set
        {
            SetBoolValue(AttributeEnum.FreeAct, value);
        }
    }
    public string? FriendlyName
    {
        get
        {
            return GetReferenceValue<string>(AttributeEnum.FriendlyName);
        }
        set
        {
            SetReferenceValue<string>(AttributeEnum.FriendlyName, value);
        }
    }
    public bool HeavyCurse
    {
        get
        {
            return GetBoolValue(AttributeEnum.HeavyCurse);
        }
        set
        {
            SetBoolValue(AttributeEnum.HeavyCurse, value);
        }
    }
    public bool HideType
    {
        get
        {
            return GetBoolValue(AttributeEnum.HideType);
        }
        set
        {
            SetBoolValue(AttributeEnum.HideType, value);
        }
    }
    public bool HoldLife
    {
        get
        {
            return GetBoolValue(AttributeEnum.HoldLife);
        }
        set
        {
            SetBoolValue(AttributeEnum.HoldLife, value);
        }
    }
    public bool IgnoreAcid
    {
        get
        {
            return GetBoolValue(AttributeEnum.IgnoreAcid);
        }
        set
        {
            SetBoolValue(AttributeEnum.IgnoreAcid, value);
        }
    }
    public bool IgnoreCold
    {
        get
        {
            return GetBoolValue(AttributeEnum.IgnoreCold);
        }
        set
        {
            SetBoolValue(AttributeEnum.IgnoreCold, value);
        }
    }
    public bool IgnoreElec
    {
        get
        {
            return GetBoolValue(AttributeEnum.IgnoreElec);
        }
        set
        {
            SetBoolValue(AttributeEnum.IgnoreElec, value);
        }
    }
    public bool IgnoreFire
    {
        get
        {
            return GetBoolValue(AttributeEnum.IgnoreFire);
        }
        set
        {
            SetBoolValue(AttributeEnum.IgnoreFire, value);
        }
    }
    public bool ImAcid
    {
        get
        {
            return GetBoolValue(AttributeEnum.ImAcid);
        }
        set
        {
            SetBoolValue(AttributeEnum.ImAcid, value);
        }
    }
    public bool ImCold
    {
        get
        {
            return GetBoolValue(AttributeEnum.ImCold);
        }
        set
        {
            SetBoolValue(AttributeEnum.ImCold, value);
        }
    }
    public bool ImElec
    {
        get
        {
            return GetBoolValue(AttributeEnum.ImElec);
        }
        set
        {
            SetBoolValue(AttributeEnum.ImElec, value);
        }
    }
    public bool ImFire
    {
        get
        {
            return GetBoolValue(AttributeEnum.ImFire);
        }
        set
        {
            SetBoolValue(AttributeEnum.ImFire, value);
        }
    }
    public bool Impact
    {
        get
        {
            return GetBoolValue(AttributeEnum.Impact);
        }
        set
        {
            SetBoolValue(AttributeEnum.Impact, value);
        }
    }
    public bool NoMagic
    {
        get
        {
            return GetBoolValue(AttributeEnum.NoMagic);
        }
        set
        {
            SetBoolValue(AttributeEnum.NoMagic, value);
        }
    }
    public bool NoTele
    {
        get
        {
            return GetBoolValue(AttributeEnum.NoTele);
        }
        set
        {
            SetBoolValue(AttributeEnum.NoTele, value);
        }
    }
    public bool PermaCurse
    {
        get
        {
            return GetBoolValue(AttributeEnum.PermaCurse);
        }
        set
        {
            SetBoolValue(AttributeEnum.PermaCurse, value);
        }
    }
    public int Radius
    {
        get
        {
            return GetIntValue(AttributeEnum.Radius);
        }
        set
        {
            SetIntValue(AttributeEnum.Radius, value);
        }
    }
    public bool Reflect
    {
        get
        {
            return GetBoolValue(AttributeEnum.Reflect);
        }
        set
        {
            SetBoolValue(AttributeEnum.Reflect, value);
        }
    }
    public bool Regen
    {
        get
        {
            return GetBoolValue(AttributeEnum.Regen);
        }
        set
        {
            SetBoolValue(AttributeEnum.Regen, value);
        }
    }
    public bool ResAcid
    {
        get
        {
            return GetBoolValue(AttributeEnum.ResAcid);
        }
        set
        {
            SetBoolValue(AttributeEnum.ResAcid, value);
        }
    }
    public bool ResBlind
    {
        get
        {
            return GetBoolValue(AttributeEnum.ResBlind);
        }
        set
        {
            SetBoolValue(AttributeEnum.ResBlind, value);
        }
    }
    public bool ResChaos
    {
        get
        {
            return GetBoolValue(AttributeEnum.ResChaos);
        }
        set
        {
            SetBoolValue(AttributeEnum.ResChaos, value);
        }
    }
    public bool ResCold
    {
        get
        {
            return GetBoolValue(AttributeEnum.ResCold);
        }
        set
        {
            SetBoolValue(AttributeEnum.ResCold, value);
        }
    }
    public bool ResConf
    {
        get
        {
            return GetBoolValue(AttributeEnum.ResConf);
        }
        set
        {
            SetBoolValue(AttributeEnum.ResConf, value);
        }
    }
    public bool ResDark
    {
        get
        {
            return GetBoolValue(AttributeEnum.ResDark);
        }
        set
        {
            SetBoolValue(AttributeEnum.ResDark, value);
        }
    }
    public bool ResDisen
    {
        get
        {
            return GetBoolValue(AttributeEnum.ResDisen);
        }
        set
        {
            SetBoolValue(AttributeEnum.ResDisen, value);
        }
    }
    public bool ResElec
    {
        get
        {
            return GetBoolValue(AttributeEnum.ResElec);
        }
        set
        {
            SetBoolValue(AttributeEnum.ResElec, value);
        }
    }
    public bool ResFear
    {
        get
        {
            return GetBoolValue(AttributeEnum.ResFear);
        }
        set
        {
            SetBoolValue(AttributeEnum.ResFear, value);
        }
    }
    public bool ResFire
    {
        get
        {
            return GetBoolValue(AttributeEnum.ResFire);
        }
        set
        {
            SetBoolValue(AttributeEnum.ResFire, value);
        }
    }
    public bool ResLight
    {
        get
        {
            return GetBoolValue(AttributeEnum.ResLight);
        }
        set
        {
            SetBoolValue(AttributeEnum.ResLight, value);
        }
    }
    public bool ResNether
    {
        get
        {
            return GetBoolValue(AttributeEnum.ResNether);
        }
        set
        {
            SetBoolValue(AttributeEnum.ResNether, value);
        }
    }
    public bool ResNexus
    {
        get
        {
            return GetBoolValue(AttributeEnum.ResNexus);
        }
        set
        {
            SetBoolValue(AttributeEnum.ResNexus, value);
        }
    }
    public bool ResPois
    {
        get
        {
            return GetBoolValue(AttributeEnum.ResPois);
        }
        set
        {
            SetBoolValue(AttributeEnum.ResPois, value);
        }
    }
    public bool ResShards
    {
        get
        {
            return GetBoolValue(AttributeEnum.ResShards);
        }
        set
        {
            SetBoolValue(AttributeEnum.ResShards, value);
        }
    }
    public bool ResSound
    {
        get
        {
            return GetBoolValue(AttributeEnum.ResSound);
        }
        set
        {
            SetBoolValue(AttributeEnum.ResSound, value);
        }
    }
    public bool SeeInvis
    {
        get
        {
            return GetBoolValue(AttributeEnum.SeeInvis);
        }
        set
        {
            SetBoolValue(AttributeEnum.SeeInvis, value);
        }
    }
    public bool ShElec
    {
        get
        {
            return GetBoolValue(AttributeEnum.ShElec);
        }
        set
        {
            SetBoolValue(AttributeEnum.ShElec, value);
        }
    }
    public bool ShFire
    {
        get
        {
            return GetBoolValue(AttributeEnum.ShFire);
        }
        set
        {
            SetBoolValue(AttributeEnum.ShFire, value);
        }
    }
    public bool ShowMods
    {
        get
        {
            return GetBoolValue(AttributeEnum.ShowMods);
        }
        set
        {
            SetBoolValue(AttributeEnum.ShowMods, value);
        }
    }
    public bool SlayAnimal
    {
        get
        {
            return GetBoolValue(AttributeEnum.SlayAnimal);
        }
        set
        {
            SetBoolValue(AttributeEnum.SlayAnimal, value);
        }
    }
    public bool SlayDemon
    {
        get
        {
            return GetBoolValue(AttributeEnum.SlayDemon);
        }
        set
        {
            SetBoolValue(AttributeEnum.SlayDemon, value);
        }
    }
    public int SlayDragon
    {
        get
        {
            return GetIntValue(AttributeEnum.SlayDragon);
        }
        set
        {
            SetIntValue(AttributeEnum.SlayDragon, value);
        }
    }
    public bool SlayEvil
    {
        get
        {
            return GetBoolValue(AttributeEnum.SlayEvil);
        }
        set
        {
            SetBoolValue(AttributeEnum.SlayEvil, value);
        }
    }
    public bool SlayGiant
    {
        get
        {
            return GetBoolValue(AttributeEnum.SlayGiant);
        }
        set
        {
            SetBoolValue(AttributeEnum.SlayGiant, value);
        }
    }
    public bool SlayOrc
    {
        get
        {
            return GetBoolValue(AttributeEnum.SlayOrc);
        }
        set
        {
            SetBoolValue(AttributeEnum.SlayOrc, value);
        }
    }
    public bool SlayTroll
    {
        get
        {
            return GetBoolValue(AttributeEnum.SlayTroll);
        }
        set
        {
            SetBoolValue(AttributeEnum.SlayTroll, value);
        }
    }
    public bool SlayUndead
    {
        get
        {
            return GetBoolValue(AttributeEnum.SlayUndead);
        }
        set
        {
            SetBoolValue(AttributeEnum.SlayUndead, value);
        }
    }
    public bool SlowDigest
    {
        get
        {
            return GetBoolValue(AttributeEnum.SlowDigest);
        }
        set
        {
            SetBoolValue(AttributeEnum.SlowDigest, value);
        }
    }
    //public bool Speed
    //{
    //    get
    //    {
    //        return GetBoolValue(PropertyEnum.Speed);
    //    }
    //    set
    //    {
    //        SetBoolValue(PropertyEnum.Speed, value);
    //    }
    //}
    public bool SustCha
    {
        get
        {
            return GetBoolValue(AttributeEnum.SustCha);
        }
        set
        {
            SetBoolValue(AttributeEnum.SustCha, value);
        }
    }
    public bool SustCon
    {
        get
        {
            return GetBoolValue(AttributeEnum.SustCon);
        }
        set
        {
            SetBoolValue(AttributeEnum.SustCon, value);
        }
    }
    public bool SustDex
    {
        get
        {
            return GetBoolValue(AttributeEnum.SustDex);
        }
        set
        {
            SetBoolValue(AttributeEnum.SustDex, value);
        }
    }
    public bool SustInt
    {
        get
        {
            return GetBoolValue(AttributeEnum.SustInt);
        }
        set
        {
            SetBoolValue(AttributeEnum.SustInt, value);
        }
    }
    public bool SustStr
    {
        get
        {
            return GetBoolValue(AttributeEnum.SustStr);
        }
        set
        {
            SetBoolValue(AttributeEnum.SustStr, value);
        }
    }
    public bool SustWis
    {
        get
        {
            return GetBoolValue(AttributeEnum.SustWis);
        }
        set
        {
            SetBoolValue(AttributeEnum.SustWis, value);
        }
    }
    public bool Telepathy
    {
        get
        {
            return GetBoolValue(AttributeEnum.Telepathy);
        }
        set
        {
            SetBoolValue(AttributeEnum.Telepathy, value);
        }
    }
    public bool Teleport
    {
        get
        {
            return GetBoolValue(AttributeEnum.Teleport);
        }
        set
        {
            SetBoolValue(AttributeEnum.Teleport, value);
        }
    }
    public int TreasureRating
    {
        get
        {
            return GetIntValue(AttributeEnum.TreasureRating);
        }
        set
        {
            SetIntValue(AttributeEnum.TreasureRating, value);
        }
    }
    public int Value
    {
        get
        {
            return GetIntValue(AttributeEnum.Value);
        }
        set
        {
            SetIntValue(AttributeEnum.Value, value);
        }
    }
    public bool Valueless
    {
        get
        {
            return GetBoolValue(AttributeEnum.Valueless);
        }
        set
        {
            SetBoolValue(AttributeEnum.Valueless, value);
        }
    }
    public bool Vampiric
    {
        get
        {
            return GetBoolValue(AttributeEnum.Vampiric);
        }
        set
        {
            SetBoolValue(AttributeEnum.Vampiric, value);
        }
    }
    public int Vorpal1InChance
    {
        get
        {
            return GetIntValue(AttributeEnum.Vorpal1InChance);
        }
    }
    public int VorpalExtraAttacks1InChance
    {
        get
        {
            return GetIntValue(AttributeEnum.VorpalExtraAttacks1InChance);
        }
    }
    public int Weight
    {
        get
        {
            return GetIntValue(AttributeEnum.Weight);
        }
    }
    public bool Wraith
    {
        get
        {
            return GetBoolValue(AttributeEnum.Wraith);
        }
    }
    public bool XtraMight
    {
        get
        {
            return GetBoolValue(AttributeEnum.XtraMight);
        }
    }
    public bool XtraShots
    {
        get
        {
            return GetBoolValue(AttributeEnum.XtraShots);
        }
    }
    #endregion
}