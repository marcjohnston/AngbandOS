// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class EffectivePropertySet
{
    private void RegisterBoolPropertyFactory(PropertyEnum index)
    {
        int intIndex = (int)index;
        if (_propertyFactories.Length <= intIndex)
        {
            Array.Resize(ref _propertyFactories, intIndex + 1);
        }
        _propertyFactories[intIndex] = new BoolPropertyFactory(index);
    }
    private void RegisterIntPropertyFactory(PropertyEnum index)
    {
        int intIndex = (int)index;
        if (_propertyFactories.Length <= intIndex)
        {
            Array.Resize(ref _propertyFactories, intIndex + 1);
        }
        _propertyFactories[intIndex] = new IntPropertyFactory(index);
    }

    private void RegisterReferencePropertyFactory<T>(PropertyEnum index) where T : class
    {
        int intIndex = (int)index;
        if (_propertyFactories.Length <= intIndex)
        {
            Array.Resize(ref _propertyFactories, intIndex + 1);
        }
        _propertyFactories[intIndex] = new ReferencePropertyFactory<T>(index);
    }

    private PropertyFactory[] _propertyFactories = new PropertyFactory[0];

    public EffectivePropertySet()
    {
        RegisterBoolPropertyFactory(PropertyEnum.CanApplyBlessedArtifactBias);
        RegisterBoolPropertyFactory(PropertyEnum.CanApplyArtifactBiasSlaying);
        RegisterBoolPropertyFactory(PropertyEnum.CanApplyBlowsBonus);
        RegisterBoolPropertyFactory(PropertyEnum.CanReflectBoltsAndArrows);
        RegisterBoolPropertyFactory(PropertyEnum.CanApplySlayingBonus);
        RegisterBoolPropertyFactory(PropertyEnum.CanApplyBonusArmorClassMiscPower);
        RegisterBoolPropertyFactory(PropertyEnum.CanProvideSheathOfElectricity);
        RegisterBoolPropertyFactory(PropertyEnum.CanProvideSheathOfFire);
        RegisterIntPropertyFactory(PropertyEnum.BonusHit);
        RegisterIntPropertyFactory(PropertyEnum.BonusArmorClass);
        RegisterIntPropertyFactory(PropertyEnum.BonusDamage);
        RegisterIntPropertyFactory(PropertyEnum.BonusStrength);
        RegisterIntPropertyFactory(PropertyEnum.BonusIntelligence);
        RegisterIntPropertyFactory(PropertyEnum.BonusWisdom);
        RegisterIntPropertyFactory(PropertyEnum.BonusDexterity);
        RegisterIntPropertyFactory(PropertyEnum.BonusConstitution);
        RegisterIntPropertyFactory(PropertyEnum.BonusCharisma);
        RegisterIntPropertyFactory(PropertyEnum.BonusStealth);
        RegisterIntPropertyFactory(PropertyEnum.BonusSearch);
        RegisterIntPropertyFactory(PropertyEnum.BonusInfravision);
        RegisterIntPropertyFactory(PropertyEnum.BonusTunnel);
        RegisterIntPropertyFactory(PropertyEnum.BonusAttacks);
        RegisterIntPropertyFactory(PropertyEnum.BonusSpeed);
        RegisterReferencePropertyFactory<Activation>(PropertyEnum.Activation);
        RegisterBoolPropertyFactory(PropertyEnum.Aggravate);
        RegisterBoolPropertyFactory(PropertyEnum.AntiTheft);
        RegisterReferencePropertyFactory<ArtifactBias>(PropertyEnum.ArtifactBias);
        RegisterBoolPropertyFactory(PropertyEnum.Blessed);
        RegisterBoolPropertyFactory(PropertyEnum.Blows);
        RegisterBoolPropertyFactory(PropertyEnum.BrandAcid);
        RegisterBoolPropertyFactory(PropertyEnum.BrandCold);
        RegisterBoolPropertyFactory(PropertyEnum.BrandElec);
        RegisterBoolPropertyFactory(PropertyEnum.BrandFire);
        RegisterBoolPropertyFactory(PropertyEnum.BrandPois);
        RegisterBoolPropertyFactory(PropertyEnum.Cha);
        RegisterBoolPropertyFactory(PropertyEnum.Chaotic);
        RegisterBoolPropertyFactory(PropertyEnum.Con);
        RegisterIntPropertyFactory(PropertyEnum.Cost);
        RegisterBoolPropertyFactory(PropertyEnum.IsCursed);
        RegisterBoolPropertyFactory(PropertyEnum.Dex);
        RegisterBoolPropertyFactory(PropertyEnum.DrainExp);
        RegisterBoolPropertyFactory(PropertyEnum.DreadCurse);
        RegisterBoolPropertyFactory(PropertyEnum.EasyKnow);
        RegisterBoolPropertyFactory(PropertyEnum.Feather);
        RegisterReferencePropertyFactory<string>(PropertyEnum.FriendlyName);
        RegisterBoolPropertyFactory(PropertyEnum.FreeAct);
        RegisterBoolPropertyFactory(PropertyEnum.HeavyCurse);
        RegisterBoolPropertyFactory(PropertyEnum.HideType);
        RegisterBoolPropertyFactory(PropertyEnum.HoldLife);
        RegisterBoolPropertyFactory(PropertyEnum.IgnoreAcid);
        RegisterBoolPropertyFactory(PropertyEnum.IgnoreCold);
        RegisterBoolPropertyFactory(PropertyEnum.IgnoreElec);
        RegisterBoolPropertyFactory(PropertyEnum.IgnoreFire);
        RegisterBoolPropertyFactory(PropertyEnum.ImAcid);
        RegisterBoolPropertyFactory(PropertyEnum.ImCold);
        RegisterBoolPropertyFactory(PropertyEnum.ImElec);
        RegisterBoolPropertyFactory(PropertyEnum.ImFire);
        RegisterBoolPropertyFactory(PropertyEnum.Impact);
        RegisterBoolPropertyFactory(PropertyEnum.Infra);
        RegisterBoolPropertyFactory(PropertyEnum.InstaArt);
        RegisterBoolPropertyFactory(PropertyEnum.Int);
        RegisterBoolPropertyFactory(PropertyEnum.KillDragon);
        RegisterBoolPropertyFactory(PropertyEnum.NoMagic);
        RegisterBoolPropertyFactory(PropertyEnum.NoTele);
        RegisterBoolPropertyFactory(PropertyEnum.PermaCurse);
        RegisterIntPropertyFactory(PropertyEnum.Radius);
        RegisterBoolPropertyFactory(PropertyEnum.Reflect);
        RegisterBoolPropertyFactory(PropertyEnum.Regen);
        RegisterBoolPropertyFactory(PropertyEnum.ResAcid);
        RegisterBoolPropertyFactory(PropertyEnum.ResBlind);
        RegisterBoolPropertyFactory(PropertyEnum.ResChaos);
        RegisterBoolPropertyFactory(PropertyEnum.ResCold);
        RegisterBoolPropertyFactory(PropertyEnum.ResConf);
        RegisterBoolPropertyFactory(PropertyEnum.ResDark);
        RegisterBoolPropertyFactory(PropertyEnum.ResDisen);
        RegisterBoolPropertyFactory(PropertyEnum.ResElec);
        RegisterBoolPropertyFactory(PropertyEnum.ResFear);
        RegisterBoolPropertyFactory(PropertyEnum.ResFire);
        RegisterBoolPropertyFactory(PropertyEnum.ResLight);
        RegisterBoolPropertyFactory(PropertyEnum.ResNether);
        RegisterBoolPropertyFactory(PropertyEnum.ResNexus);
        RegisterBoolPropertyFactory(PropertyEnum.ResPois);
        RegisterBoolPropertyFactory(PropertyEnum.ResShards);
        RegisterBoolPropertyFactory(PropertyEnum.ResSound);
        RegisterBoolPropertyFactory(PropertyEnum.Search);
        RegisterBoolPropertyFactory(PropertyEnum.SeeInvis);
        RegisterBoolPropertyFactory(PropertyEnum.ShElec);
        RegisterBoolPropertyFactory(PropertyEnum.ShFire);
        RegisterBoolPropertyFactory(PropertyEnum.ShowMods);
        RegisterBoolPropertyFactory(PropertyEnum.SlayAnimal);
        RegisterBoolPropertyFactory(PropertyEnum.SlayDemon);
        RegisterBoolPropertyFactory(PropertyEnum.SlayDragon);
        RegisterBoolPropertyFactory(PropertyEnum.SlayEvil);
        RegisterBoolPropertyFactory(PropertyEnum.SlayGiant);
        RegisterBoolPropertyFactory(PropertyEnum.SlayOrc);
        RegisterBoolPropertyFactory(PropertyEnum.SlayTroll);
        RegisterBoolPropertyFactory(PropertyEnum.SlayUndead);
        RegisterBoolPropertyFactory(PropertyEnum.SlowDigest);
        RegisterBoolPropertyFactory(PropertyEnum.Speed);
        RegisterBoolPropertyFactory(PropertyEnum.Stealth);
        RegisterBoolPropertyFactory(PropertyEnum.Str);
        RegisterBoolPropertyFactory(PropertyEnum.SustCha);
        RegisterBoolPropertyFactory(PropertyEnum.SustCon);
        RegisterBoolPropertyFactory(PropertyEnum.SustDex);
        RegisterBoolPropertyFactory(PropertyEnum.SustInt);
        RegisterBoolPropertyFactory(PropertyEnum.SustStr);
        RegisterBoolPropertyFactory(PropertyEnum.SustWis);
        RegisterBoolPropertyFactory(PropertyEnum.Telepathy);
        RegisterBoolPropertyFactory(PropertyEnum.Teleport);
        RegisterIntPropertyFactory(PropertyEnum.TreasureRating);
        RegisterBoolPropertyFactory(PropertyEnum.Tunnel);
        RegisterIntPropertyFactory(PropertyEnum.Value);
        RegisterBoolPropertyFactory(PropertyEnum.Valueless);
        RegisterBoolPropertyFactory(PropertyEnum.Vampiric);
        RegisterBoolPropertyFactory(PropertyEnum.Vorpal);
        RegisterIntPropertyFactory(PropertyEnum.Weight);
        RegisterBoolPropertyFactory(PropertyEnum.Wis);
        RegisterBoolPropertyFactory(PropertyEnum.Wraith);
        RegisterBoolPropertyFactory(PropertyEnum.XtraMight);
        RegisterBoolPropertyFactory(PropertyEnum.XtraShots);

        // Generate a writable property values.
        _writeProperties = new PropertyValue[_propertyFactories.Length];
        foreach (PropertyFactory itemPropertyFactory in _propertyFactories)
        {
            int index = (int)itemPropertyFactory.Index;
            _writeProperties[index] = itemPropertyFactory.Instantiate();
        }

        // Generate the override property values.
        _overrideProperties = new PropertyValue[_propertyFactories.Length];
        foreach (PropertyFactory itemPropertyFactory in _propertyFactories)
        {
            int index = (int)itemPropertyFactory.Index;
            _overrideProperties[index] = itemPropertyFactory.InstantiateNullable();
        }
    }
    private Dictionary<string, List<ReadOnlyPropertySet>> _enhancements = new Dictionary<string, List<ReadOnlyPropertySet>>();
    private PropertyValue[] _writeProperties;
    private PropertyValue[] _overrideProperties;
    public EffectivePropertySet Clone()
    {
        // Build a writable property set.
        EffectivePropertySet effectivePropertySet = new EffectivePropertySet();

        // Copy the enhancements.  These are immutable, so we can simply reference them.
        foreach (KeyValuePair<string, List<ReadOnlyPropertySet>> enhancement in _enhancements)
        {
            foreach (ReadOnlyPropertySet readOnlyPropertySet in enhancement.Value)
            {
                effectivePropertySet.AddEnhancement(enhancement.Key, readOnlyPropertySet);
            }
        }

        // Clone the override properties.
        effectivePropertySet._overrideProperties = new PropertyValue[_propertyFactories.Length];
        foreach (PropertyFactory itemPropertyFactory in _propertyFactories)
        {
            int index = (int)itemPropertyFactory.Index;
            effectivePropertySet._overrideProperties[index] = _overrideProperties[index].Clone();
        }

        // Clone the writable properties.
        effectivePropertySet._writeProperties = new PropertyValue[_propertyFactories.Length];
        foreach (PropertyFactory itemPropertyFactory in _propertyFactories)
        {
            int index = (int)itemPropertyFactory.Index;
            effectivePropertySet._writeProperties[index] = _writeProperties[index].Clone();
        }

        return effectivePropertySet;
    }
    public ReadOnlyPropertySet ToReadOnly()
    {
        PropertyValue[] newProperties = new PropertyValue[_propertyFactories.Length];

        foreach (PropertyFactory itemPropertyFactory in _propertyFactories)
        {
            int index = (int)itemPropertyFactory.Index;
            newProperties[index] = GetValue(itemPropertyFactory.Index);
        }
        return new ReadOnlyPropertySet(newProperties);
    }

    public void AddEnhancement(string key, ReadOnlyPropertySet readOnlyPropertySet) 
    {
        if (!_enhancements.TryGetValue(key, out List<ReadOnlyPropertySet>? readOnlyPropertySetList))
        {
            readOnlyPropertySetList = new List<ReadOnlyPropertySet>();
            _enhancements.Add(key, readOnlyPropertySetList);
        }
        readOnlyPropertySetList.Add(readOnlyPropertySet);
    }
    public void AddEnhancement(ReadOnlyPropertySet readOnlyPropertySet)
    {
        AddEnhancement(Guid.NewGuid().ToString(), readOnlyPropertySet);
    }
    public void RemoveEnhancement(string key)
    {
        _enhancements.Remove(key);
    }
    private void Reset(PropertyEnum propertyEnum)
    {
        int index = (int)propertyEnum;
        NullablePropertyValue nullablePropertyValue = (NullablePropertyValue)_overrideProperties[index];
        nullablePropertyValue.Reset();
    }

    private void Set(PropertyEnum propertyEnum, PropertyValue propertyValue)
    {
        int index = (int)propertyEnum;
        NullablePropertyValue nullablePropertyValue = (NullablePropertyValue)_overrideProperties[index];
        nullablePropertyValue.Set(propertyValue);
    }

    public void ResetCurse()
    {
        Reset(PropertyEnum.IsCursed);
    }
    public void RemoveCurse()
    {
        Set(PropertyEnum.IsCursed, new BoolPropertyValue(false));
    }
    public void ResetHeavyCurse()
    {
        Reset(PropertyEnum.HeavyCurse);
    }
    public void RemoveHeavyCurse()
    {
        Set(PropertyEnum.HeavyCurse, new BoolPropertyValue(false));
    }

    public bool HasKeyedItemEnhancements(string key)
    {
        return _enhancements.ContainsKey(key);
    }

    private PropertyValue GetValue(PropertyEnum propertyEnum)
    {
        // Retrieve the index for the property.
        int index = (int)propertyEnum;

        // Retrieve the factory.
        PropertyFactory itemPropertyFactory = _propertyFactories[index];

        // Retrieve a default value from the factory.
        PropertyValue itemProperty = itemPropertyFactory.Instantiate();

        // Merge all of the immutable enhancements across all of the keys.
        foreach (List<ReadOnlyPropertySet> readOnlyPropertySetList in _enhancements.Values)
        {
            // For each key, there may be multiple item enhancements.
            foreach (ReadOnlyPropertySet readOnlyPropertySet in readOnlyPropertySetList)
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

    public bool GetBoolValue(PropertyEnum propertyEnum)
    {
        PropertyValue effectiveItemProperty = GetValue(propertyEnum);
        BoolPropertyValue boolPropertyValue = (BoolPropertyValue)effectiveItemProperty;
        bool value = boolPropertyValue.Value;
        return value;
    }

    public int GetIntValue(PropertyEnum propertyEnum)
    {
        PropertyValue effectiveItemProperty = GetValue(propertyEnum);
        IntPropertyValue intPropertyValue = (IntPropertyValue)effectiveItemProperty;
        int value = intPropertyValue.Value;
        return value;
    }

    public T? GetReferenceValue<T>(PropertyEnum propertyEnum) where T : class
    {
        PropertyValue effectiveItemProperty = GetValue(propertyEnum);
        NullableReferencePropertyValue<T> referencePropertyValue = (NullableReferencePropertyValue<T>)effectiveItemProperty;
        T? value = referencePropertyValue.Value;
        return value;
    }

    private void SetValue(PropertyEnum propertyEnum, PropertyValue propertyValue)
    {
        // Retrieve the index for the property.
        int index = (int)propertyEnum;

        _writeProperties[index] = propertyValue;
    }

    public void SetReferenceValue<T>(PropertyEnum propertyEnum, T? propertyValue) where T : class
    {
        // Retrieve the index for the property.
        int index = (int)propertyEnum;

        _writeProperties[index] = new NullableReferencePropertyValue<T>(propertyValue);
    }

    public void SetIntValue(PropertyEnum propertyEnum, int value)
    {
        SetValue(propertyEnum, new IntPropertyValue(value));
    }

    public void AddIntValue(PropertyEnum propertyEnum, int value)
    {
        SetValue(propertyEnum, new IntPropertyValue(GetIntValue(propertyEnum) + value));
    }

    public void SetBoolValue(PropertyEnum propertyEnum, bool value)
    {
        SetValue(propertyEnum, new BoolPropertyValue(value));
    }

    #region Properties
    public bool CanApplyBlessedArtifactBias
    {
        get
        {
            return GetBoolValue(PropertyEnum.CanApplyBlessedArtifactBias);
        }
        set
        {
            SetBoolValue(PropertyEnum.CanApplyBlessedArtifactBias, value);
        }
    }
    public bool CanApplyArtifactBiasSlaying
    {
        get
        {
            return GetBoolValue(PropertyEnum.CanApplyArtifactBiasSlaying);
        }
        set
        {
            SetBoolValue(PropertyEnum.CanApplyArtifactBiasSlaying, value);
        }
    }
    public bool CanApplyBlowsBonus
    {
        get
        {
            return GetBoolValue(PropertyEnum.CanApplyBlowsBonus);
        }
        set
        {
            SetBoolValue(PropertyEnum.CanApplyBlowsBonus, value);
        }
    }
    public bool CanReflectBoltsAndArrows
    {
        get
        {
            return GetBoolValue(PropertyEnum.CanReflectBoltsAndArrows);
        }
        set
        {
            SetBoolValue(PropertyEnum.CanReflectBoltsAndArrows, value);
        }
    }
    public bool CanApplySlayingBonus
    {
        get
        {
            return GetBoolValue(PropertyEnum.CanApplySlayingBonus);
        }
        set
        {
            SetBoolValue(PropertyEnum.CanApplySlayingBonus, value);
        }
    }
    public bool CanApplyBonusArmorClassMiscPower
    {
        get
        {
            return GetBoolValue(PropertyEnum.CanApplyBonusArmorClassMiscPower);
        }
        set
        {
            SetBoolValue(PropertyEnum.CanApplyBonusArmorClassMiscPower, value);
        }
    }
    public bool CanProvideSheathOfElectricity
    {
        get
        {
            return GetBoolValue(PropertyEnum.CanProvideSheathOfElectricity);
        }
        set
        {
            SetBoolValue(PropertyEnum.CanProvideSheathOfElectricity, value);
        }
    }
    public bool CanProvideSheathOfFire
    {
        get
        {
            return GetBoolValue(PropertyEnum.CanProvideSheathOfFire);
        }
        set
        {
            SetBoolValue(PropertyEnum.CanProvideSheathOfFire, value);
        }
    }
    public int BonusHit
    {
        get
        {
            return GetIntValue(PropertyEnum.BonusHit);
        }
        set
        {
            SetIntValue(PropertyEnum.BonusHit, value);
        }
    }
    public int BonusArmorClass
    {
        get
        {
            return GetIntValue(PropertyEnum.BonusArmorClass);
        }
        set
        {
            SetIntValue(PropertyEnum.BonusArmorClass, value);
        }
    }
    public int BonusDamage
    {
        get
        {
            return GetIntValue(PropertyEnum.BonusDamage);
        }
        set
        {
            SetIntValue(PropertyEnum.BonusDamage, value);
        }
    }
    public int BonusStrength
    {
        get
        {
            return GetIntValue(PropertyEnum.BonusStrength);
        }
        set
        {
            SetIntValue(PropertyEnum.BonusStrength, value);
        }
    }
    public int BonusIntelligence
    {
        get
        {
            return GetIntValue(PropertyEnum.BonusIntelligence);
        }
        set
        {
            SetIntValue(PropertyEnum.BonusIntelligence, value);
        }
    }
    public int BonusWisdom
    {
        get
        {
            return GetIntValue(PropertyEnum.BonusWisdom);
        }
        set
        {
            SetIntValue(PropertyEnum.BonusWisdom, value);
        }
    }
    public int BonusDexterity
    {
        get
        {
            return GetIntValue(PropertyEnum.BonusDexterity);
        }
        set
        {
            SetIntValue(PropertyEnum.BonusDexterity, value);
        }
    }
    public int BonusConstitution
    {
        get
        {
            return GetIntValue(PropertyEnum.BonusConstitution);
        }
        set
        {
            SetIntValue(PropertyEnum.BonusConstitution, value);
        }
    }
    public int BonusCharisma
    {
        get
        {
            return GetIntValue(PropertyEnum.BonusCharisma);
        }
        set
        {
            SetIntValue(PropertyEnum.BonusCharisma, value);
        }
    }
    public int BonusStealth
    {
        get
        {
            return GetIntValue(PropertyEnum.BonusStealth);
        }
        set
        {
            SetIntValue(PropertyEnum.BonusStealth, value);
        }
    }
    public int BonusSearch
    {
        get
        {
            return GetIntValue(PropertyEnum.BonusSearch);
        }
        set
        {
            SetIntValue(PropertyEnum.BonusSearch, value);
        }
    }
    public int BonusInfravision
    {
        get
        {
            return GetIntValue(PropertyEnum.BonusInfravision);
        }
        set
        {
            SetIntValue(PropertyEnum.BonusInfravision, value);
        }
    }
    public int BonusTunnel
    {
        get
        {
            return GetIntValue(PropertyEnum.BonusTunnel);
        }
        set
        {
            SetIntValue(PropertyEnum.BonusTunnel, value);
        }
    }
    public int BonusAttacks
    {
        get
        {
            return GetIntValue(PropertyEnum.BonusAttacks);
        }
        set
        {
            SetIntValue(PropertyEnum.BonusAttacks, value);
        }
    }
    public int BonusSpeed
    {
        get
        {
            return GetIntValue(PropertyEnum.BonusSpeed);
        }
        set
        {
            SetIntValue(PropertyEnum.BonusSpeed, value);
        }
    }
    public Activation? Activation
    {
        get
        {
            return GetReferenceValue<Activation>(PropertyEnum.Activation);
        }
        set
        {
            SetReferenceValue<Activation>(PropertyEnum.Activation, value);
        }
    }
    public bool Aggravate
    {
        get
        {
            return GetBoolValue(PropertyEnum.Aggravate);
        }
        set
        {
            SetBoolValue(PropertyEnum.Aggravate, value);
        }
    }
    public bool AntiTheft
    {
        get
        {
            return GetBoolValue(PropertyEnum.AntiTheft);
        }
        set
        {
            SetBoolValue(PropertyEnum.AntiTheft, value);
        }
    }
    public ArtifactBias? ArtifactBias
    {
        get
        {
            return GetReferenceValue<ArtifactBias>(PropertyEnum.ArtifactBias);
        }
        set
        {
            SetReferenceValue<ArtifactBias>(PropertyEnum.ArtifactBias, value);
        }
    }
    public bool Blessed
    {
        get
        {
            return GetBoolValue(PropertyEnum.Blessed);
        }
        set
        {
            SetBoolValue(PropertyEnum.Blessed, value);
        }
    }
    public bool Blows
    {
        get
        {
            return GetBoolValue(PropertyEnum.Blows);
        }
        set
        {
            SetBoolValue(PropertyEnum.Blows, value);
        }
    }
    public bool BrandAcid
    {
        get
        {
            return GetBoolValue(PropertyEnum.BrandAcid);
        }
        set
        {
            SetBoolValue(PropertyEnum.BrandAcid, value);
        }
    }
    public bool BrandCold
    {
        get
        {
            return GetBoolValue(PropertyEnum.BrandCold);
        }
        set
        {
            SetBoolValue(PropertyEnum.BrandCold, value);
        }
    }
    public bool BrandElec
    {
        get
        {
            return GetBoolValue(PropertyEnum.BrandElec);
        }
        set
        {
            SetBoolValue(PropertyEnum.BrandElec, value);
        }
    }
    public bool BrandFire
    {
        get
        {
            return GetBoolValue(PropertyEnum.BrandFire);
        }
        set
        {
            SetBoolValue(PropertyEnum.BrandFire, value);
        }
    }
    public bool BrandPois
    {
        get
        {
            return GetBoolValue(PropertyEnum.BrandPois);
        }
        set
        {
            SetBoolValue(PropertyEnum.BrandPois, value);
        }
    }
    public bool Cha
    {
        get
        {
            return GetBoolValue(PropertyEnum.Cha);
        }
        set
        {
            SetBoolValue(PropertyEnum.Cha, value);
        }
    }
    public bool Chaotic
    {
        get
        {
            return GetBoolValue(PropertyEnum.Chaotic);
        }
        set
        {
            SetBoolValue(PropertyEnum.Chaotic, value);
        }
    }
    public bool Con
    {
        get
        {
            return GetBoolValue(PropertyEnum.Con);
        }
        set
        {
            SetBoolValue(PropertyEnum.Con, value);
        }
    }
    public int Cost
    {
        get
        {
            return GetIntValue(PropertyEnum.Cost);
        }
        set
        {
            SetIntValue(PropertyEnum.Cost, value);
        }
    }
    public bool IsCursed
    {
        get
        {
            return GetBoolValue(PropertyEnum.IsCursed);
        }
        set
        {
            SetBoolValue(PropertyEnum.IsCursed, value);
        }
    }
    public bool Dex
    {
        get
        {
            return GetBoolValue(PropertyEnum.Dex);
        }
        set
        {
            SetBoolValue(PropertyEnum.Dex, value);
        }
    }
    public bool DrainExp
    {
        get
        {
            return GetBoolValue(PropertyEnum.DrainExp);
        }
        set
        {
            SetBoolValue(PropertyEnum.DrainExp, value);
        }
    }
    public bool DreadCurse
    {
        get
        {
            return GetBoolValue(PropertyEnum.DreadCurse);
        }
        set
        {
            SetBoolValue(PropertyEnum.DreadCurse, value);
        }
    }
    public bool EasyKnow
    {
        get
        {
            return GetBoolValue(PropertyEnum.EasyKnow);
        }
        set
        {
            SetBoolValue(PropertyEnum.EasyKnow, value);
        }
    }
    public bool Feather
    {
        get
        {
            return GetBoolValue(PropertyEnum.Feather);
        }
        set
        {
            SetBoolValue(PropertyEnum.Feather, value);
        }
    }
    public bool FreeAct
    {
        get
        {
            return GetBoolValue(PropertyEnum.FreeAct);
        }
        set
        {
            SetBoolValue(PropertyEnum.FreeAct, value);
        }
    }
    public string? FriendlyName
    {
        get
        {
            return GetReferenceValue<string>(PropertyEnum.FriendlyName);
        }
        set
        {
            SetReferenceValue<string>(PropertyEnum.FriendlyName, value);
        }
    }
    public bool HeavyCurse
    {
        get
        {
            return GetBoolValue(PropertyEnum.HeavyCurse);
        }
        set
        {
            SetBoolValue(PropertyEnum.HeavyCurse, value);
        }
    }
    public bool HideType
    {
        get
        {
            return GetBoolValue(PropertyEnum.HideType);
        }
        set
        {
            SetBoolValue(PropertyEnum.HideType, value);
        }
    }
    public bool HoldLife
    {
        get
        {
            return GetBoolValue(PropertyEnum.HoldLife);
        }
        set
        {
            SetBoolValue(PropertyEnum.HoldLife, value);
        }
    }
    public bool IgnoreAcid
    {
        get
        {
            return GetBoolValue(PropertyEnum.IgnoreAcid);
        }
        set
        {
            SetBoolValue(PropertyEnum.IgnoreAcid, value);
        }
    }
    public bool IgnoreCold
    {
        get
        {
            return GetBoolValue(PropertyEnum.IgnoreCold);
        }
        set
        {
            SetBoolValue(PropertyEnum.IgnoreCold, value);
        }
    }
    public bool IgnoreElec
    {
        get
        {
            return GetBoolValue(PropertyEnum.IgnoreElec);
        }
        set
        {
            SetBoolValue(PropertyEnum.IgnoreElec, value);
        }
    }
    public bool IgnoreFire
    {
        get
        {
            return GetBoolValue(PropertyEnum.IgnoreFire);
        }
        set
        {
            SetBoolValue(PropertyEnum.IgnoreFire, value);
        }
    }
    public bool ImAcid
    {
        get
        {
            return GetBoolValue(PropertyEnum.ImAcid);
        }
        set
        {
            SetBoolValue(PropertyEnum.ImAcid, value);
        }
    }
    public bool ImCold
    {
        get
        {
            return GetBoolValue(PropertyEnum.ImCold);
        }
        set
        {
            SetBoolValue(PropertyEnum.ImCold, value);
        }
    }
    public bool ImElec
    {
        get
        {
            return GetBoolValue(PropertyEnum.ImElec);
        }
        set
        {
            SetBoolValue(PropertyEnum.ImElec, value);
        }
    }
    public bool ImFire
    {
        get
        {
            return GetBoolValue(PropertyEnum.ImFire);
        }
        set
        {
            SetBoolValue(PropertyEnum.ImFire, value);
        }
    }
    public bool Impact
    {
        get
        {
            return GetBoolValue(PropertyEnum.Impact);
        }
        set
        {
            SetBoolValue(PropertyEnum.Impact, value);
        }
    }
    public bool Infra
    {
        get
        {
            return GetBoolValue(PropertyEnum.Infra);
        }
        set
        {
            SetBoolValue(PropertyEnum.Infra, value);
        }
    }
    public bool InstaArt
    {
        get
        {
            return GetBoolValue(PropertyEnum.InstaArt);
        }
        set
        {
            SetBoolValue(PropertyEnum.InstaArt, value);
        }
    }
    public bool Int
    {
        get
        {
            return GetBoolValue(PropertyEnum.Int);
        }
        set
        {
            SetBoolValue(PropertyEnum.Int, value);
        }
    }
    public bool KillDragon
    {
        get
        {
            return GetBoolValue(PropertyEnum.KillDragon);
        }
        set
        {
            SetBoolValue(PropertyEnum.KillDragon, value);
        }
    }
    public bool NoMagic
    {
        get
        {
            return GetBoolValue(PropertyEnum.NoMagic);
        }
        set
        {
            SetBoolValue(PropertyEnum.NoMagic, value);
        }
    }
    public bool NoTele
    {
        get
        {
            return GetBoolValue(PropertyEnum.NoTele);
        }
        set
        {
            SetBoolValue(PropertyEnum.NoTele, value);
        }
    }
    public bool PermaCurse
    {
        get
        {
            return GetBoolValue(PropertyEnum.PermaCurse);
        }
        set
        {
            SetBoolValue(PropertyEnum.PermaCurse, value);
        }
    }
    public int Radius
    {
        get
        {
            return GetIntValue(PropertyEnum.Radius);
        }
        set
        {
            SetIntValue(PropertyEnum.Radius, value);
        }
    }
    public bool Reflect
    {
        get
        {
            return GetBoolValue(PropertyEnum.Reflect);
        }
        set
        {
            SetBoolValue(PropertyEnum.Reflect, value);
        }
    }
    public bool Regen
    {
        get
        {
            return GetBoolValue(PropertyEnum.Regen);
        }
        set
        {
            SetBoolValue(PropertyEnum.Regen, value);
        }
    }
    public bool ResAcid
    {
        get
        {
            return GetBoolValue(PropertyEnum.ResAcid);
        }
        set
        {
            SetBoolValue(PropertyEnum.ResAcid, value);
        }
    }
    public bool ResBlind
    {
        get
        {
            return GetBoolValue(PropertyEnum.ResBlind);
        }
        set
        {
            SetBoolValue(PropertyEnum.ResBlind, value);
        }
    }
    public bool ResChaos
    {
        get
        {
            return GetBoolValue(PropertyEnum.ResChaos);
        }
        set
        {
            SetBoolValue(PropertyEnum.ResChaos, value);
        }
    }
    public bool ResCold
    {
        get
        {
            return GetBoolValue(PropertyEnum.ResCold);
        }
        set
        {
            SetBoolValue(PropertyEnum.ResCold, value);
        }
    }
    public bool ResConf
    {
        get
        {
            return GetBoolValue(PropertyEnum.ResConf);
        }
        set
        {
            SetBoolValue(PropertyEnum.ResConf, value);
        }
    }
    public bool ResDark
    {
        get
        {
            return GetBoolValue(PropertyEnum.ResDark);
        }
        set
        {
            SetBoolValue(PropertyEnum.ResDark, value);
        }
    }
    public bool ResDisen
    {
        get
        {
            return GetBoolValue(PropertyEnum.ResDisen);
        }
        set
        {
            SetBoolValue(PropertyEnum.ResDisen, value);
        }
    }
    public bool ResElec
    {
        get
        {
            return GetBoolValue(PropertyEnum.ResElec);
        }
        set
        {
            SetBoolValue(PropertyEnum.ResElec, value);
        }
    }
    public bool ResFear
    {
        get
        {
            return GetBoolValue(PropertyEnum.ResFear);
        }
        set
        {
            SetBoolValue(PropertyEnum.ResFear, value);
        }
    }
    public bool ResFire
    {
        get
        {
            return GetBoolValue(PropertyEnum.ResFire);
        }
        set
        {
            SetBoolValue(PropertyEnum.ResFire, value);
        }
    }
    public bool ResLight
    {
        get
        {
            return GetBoolValue(PropertyEnum.ResLight);
        }
        set
        {
            SetBoolValue(PropertyEnum.ResLight, value);
        }
    }
    public bool ResNether
    {
        get
        {
            return GetBoolValue(PropertyEnum.ResNether);
        }
        set
        {
            SetBoolValue(PropertyEnum.ResNether, value);
        }
    }
    public bool ResNexus
    {
        get
        {
            return GetBoolValue(PropertyEnum.ResNexus);
        }
        set
        {
            SetBoolValue(PropertyEnum.ResNexus, value);
        }
    }
    public bool ResPois
    {
        get
        {
            return GetBoolValue(PropertyEnum.ResPois);
        }
        set
        {
            SetBoolValue(PropertyEnum.ResPois, value);
        }
    }
    public bool ResShards
    {
        get
        {
            return GetBoolValue(PropertyEnum.ResShards);
        }
        set
        {
            SetBoolValue(PropertyEnum.ResShards, value);
        }
    }
    public bool ResSound
    {
        get
        {
            return GetBoolValue(PropertyEnum.ResSound);
        }
        set
        {
            SetBoolValue(PropertyEnum.ResSound, value);
        }
    }
    public bool Search
    {
        get
        {
            return GetBoolValue(PropertyEnum.Search);
        }
        set
        {
            SetBoolValue(PropertyEnum.Search, value);
        }
    }
    public bool SeeInvis
    {
        get
        {
            return GetBoolValue(PropertyEnum.SeeInvis);
        }
        set
        {
            SetBoolValue(PropertyEnum.SeeInvis, value);
        }
    }
    public bool ShElec
    {
        get
        {
            return GetBoolValue(PropertyEnum.ShElec);
        }
        set
        {
            SetBoolValue(PropertyEnum.ShElec, value);
        }
    }
    public bool ShFire
    {
        get
        {
            return GetBoolValue(PropertyEnum.ShFire);
        }
        set
        {
            SetBoolValue(PropertyEnum.ShFire, value);
        }
    }
    public bool ShowMods
    {
        get
        {
            return GetBoolValue(PropertyEnum.ShowMods);
        }
        set
        {
            SetBoolValue(PropertyEnum.ShowMods, value);
        }
    }
    public bool SlayAnimal
    {
        get
        {
            return GetBoolValue(PropertyEnum.SlayAnimal);
        }
        set
        {
            SetBoolValue(PropertyEnum.SlayAnimal, value);
        }
    }
    public bool SlayDemon
    {
        get
        {
            return GetBoolValue(PropertyEnum.SlayDemon);
        }
        set
        {
            SetBoolValue(PropertyEnum.SlayDemon, value);
        }
    }
    public bool SlayDragon
    {
        get
        {
            return GetBoolValue(PropertyEnum.SlayDragon);
        }
        set
        {
            SetBoolValue(PropertyEnum.SlayDragon, value);
        }
    }
    public bool SlayEvil
    {
        get
        {
            return GetBoolValue(PropertyEnum.SlayEvil);
        }
        set
        {
            SetBoolValue(PropertyEnum.SlayEvil, value);
        }
    }
    public bool SlayGiant
    {
        get
        {
            return GetBoolValue(PropertyEnum.SlayGiant);
        }
        set
        {
            SetBoolValue(PropertyEnum.SlayGiant, value);
        }
    }
    public bool SlayOrc
    {
        get
        {
            return GetBoolValue(PropertyEnum.SlayOrc);
        }
        set
        {
            SetBoolValue(PropertyEnum.SlayOrc, value);
        }
    }
    public bool SlayTroll
    {
        get
        {
            return GetBoolValue(PropertyEnum.SlayTroll);
        }
        set
        {
            SetBoolValue(PropertyEnum.SlayTroll, value);
        }
    }
    public bool SlayUndead
    {
        get
        {
            return GetBoolValue(PropertyEnum.SlayUndead);
        }
        set
        {
            SetBoolValue(PropertyEnum.SlayUndead, value);
        }
    }
    public bool SlowDigest
    {
        get
        {
            return GetBoolValue(PropertyEnum.SlowDigest);
        }
        set
        {
            SetBoolValue(PropertyEnum.SlowDigest, value);
        }
    }
    public bool Speed
    {
        get
        {
            return GetBoolValue(PropertyEnum.Speed);
        }
        set
        {
            SetBoolValue(PropertyEnum.Speed, value);
        }
    }
    public bool Stealth
    {
        get
        {
            return GetBoolValue(PropertyEnum.Stealth);
        }
        set
        {
            SetBoolValue(PropertyEnum.Stealth, value);
        }
    }
    public bool Str
    {
        get
        {
            return GetBoolValue(PropertyEnum.Str);
        }
        set
        {
            SetBoolValue(PropertyEnum.Str, value);
        }
    }
    public bool SustCha
    {
        get
        {
            return GetBoolValue(PropertyEnum.SustCha);
        }
        set
        {
            SetBoolValue(PropertyEnum.SustCha, value);
        }
    }
    public bool SustCon
    {
        get
        {
            return GetBoolValue(PropertyEnum.SustCon);
        }
        set
        {
            SetBoolValue(PropertyEnum.SustCon, value);
        }
    }
    public bool SustDex
    {
        get
        {
            return GetBoolValue(PropertyEnum.SustDex);
        }
        set
        {
            SetBoolValue(PropertyEnum.SustDex, value);
        }
    }
    public bool SustInt
    {
        get
        {
            return GetBoolValue(PropertyEnum.SustInt);
        }
        set
        {
            SetBoolValue(PropertyEnum.SustInt, value);
        }
    }
    public bool SustStr
    {
        get
        {
            return GetBoolValue(PropertyEnum.SustStr);
        }
        set
        {
            SetBoolValue(PropertyEnum.SustStr, value);
        }
    }
    public bool SustWis
    {
        get
        {
            return GetBoolValue(PropertyEnum.SustWis);
        }
        set
        {
            SetBoolValue(PropertyEnum.SustWis, value);
        }
    }
    public bool Telepathy
    {
        get
        {
            return GetBoolValue(PropertyEnum.Telepathy);
        }
        set
        {
            SetBoolValue(PropertyEnum.Telepathy, value);
        }
    }
    public bool Teleport
    {
        get
        {
            return GetBoolValue(PropertyEnum.Teleport);
        }
        set
        {
            SetBoolValue(PropertyEnum.Teleport, value);
        }
    }
    public int TreasureRating
    {
        get
        {
            return GetIntValue(PropertyEnum.TreasureRating);
        }
        set
        {
            SetIntValue(PropertyEnum.TreasureRating, value);
        }
    }
    public bool Tunnel
    {
        get
        {
            return GetBoolValue(PropertyEnum.Tunnel);
        }
        set
        {
            SetBoolValue(PropertyEnum.Tunnel, value);
        }
    }
    public int Value
    {
        get
        {
            return GetIntValue(PropertyEnum.Value);
        }
        set
        {
            SetIntValue(PropertyEnum.Value, value);
        }
    }
    public bool Valueless
    {
        get
        {
            return GetBoolValue(PropertyEnum.Valueless);
        }
        set
        {
            SetBoolValue(PropertyEnum.Valueless, value);
        }
    }
    public bool Vampiric
    {
        get
        {
            return GetBoolValue(PropertyEnum.Vampiric);
        }
        set
        {
            SetBoolValue(PropertyEnum.Vampiric, value);
        }
    }
    public bool Vorpal
    {
        get
        {
            return GetBoolValue(PropertyEnum.Vorpal);
        }
        set
        {
            SetBoolValue(PropertyEnum.Vorpal, value);
        }
    }
    public int Weight
    {
        get
        {
            return GetIntValue(PropertyEnum.Weight);
        }
        set
        {
            SetIntValue(PropertyEnum.Weight, value);
        }
    }
    public bool Wis
    {
        get
        {
            return GetBoolValue(PropertyEnum.Wis);
        }
        set
        {
            SetBoolValue(PropertyEnum.Wis, value);
        }
    }
    public bool Wraith
    {
        get
        {
            return GetBoolValue(PropertyEnum.Wraith);
        }
        set
        {
            SetBoolValue(PropertyEnum.Wraith, value);
        }
    }
    public bool XtraMight
    {
        get
        {
            return GetBoolValue(PropertyEnum.XtraMight);
        }
        set
        {
            SetBoolValue(PropertyEnum.XtraMight, value);
        }
    }
    public bool XtraShots
    {
        get
        {
            return GetBoolValue(PropertyEnum.XtraShots);
        }
        set
        {
            SetBoolValue(PropertyEnum.XtraShots, value);
        }
    }
    #endregion
}