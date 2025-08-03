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
        _propertyFactories[intIndex] = new BoolPropertyFactory(intIndex);
    }
    private void RegisterIntPropertyFactory(PropertyEnum index)
    {
        int intIndex = (int)index;
        if (_propertyFactories.Length <= intIndex)
        {
            Array.Resize(ref _propertyFactories, intIndex + 1);
        }
        _propertyFactories[intIndex] = new IntPropertyFactory(intIndex);
    }

    private void RegisterReferencePropertyFactory<T>(PropertyEnum index) where T : class
    {
        int intIndex = (int)index;
        if (_propertyFactories.Length <= intIndex)
        {
            Array.Resize(ref _propertyFactories, intIndex + 1);
        }
        _propertyFactories[intIndex] = new ReferencePropertyFactory<T>(intIndex);
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
        RegisterBoolPropertyFactory(PropertyEnum.IsCursed);
        RegisterBoolPropertyFactory(PropertyEnum.Dex);
        RegisterBoolPropertyFactory(PropertyEnum.DrainExp);
        RegisterBoolPropertyFactory(PropertyEnum.DreadCurse);
        RegisterBoolPropertyFactory(PropertyEnum.EasyKnow);
        RegisterBoolPropertyFactory(PropertyEnum.Feather);
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
        RegisterBoolPropertyFactory(PropertyEnum.Wis);
        RegisterBoolPropertyFactory(PropertyEnum.Wraith);
        RegisterBoolPropertyFactory(PropertyEnum.XtraMight);
        RegisterBoolPropertyFactory(PropertyEnum.XtraShots);

        int maxPropertyEnum = Enum.GetValues(typeof(PropertyEnum)).Cast<int>().Max();

        // Generate a writable property values.
        _writeProperties = new PropertyValue[maxPropertyEnum];
        foreach (PropertyFactory itemPropertyFactory in _propertyFactories)
        {
            _writeProperties[itemPropertyFactory.Index] = itemPropertyFactory.Instantiate();
        }

        // Generate the override property values.
        _overrideProperties = new PropertyValue[maxPropertyEnum];
        foreach (PropertyFactory itemPropertyFactory in _propertyFactories)
        {
            _overrideProperties[itemPropertyFactory.Index] = itemPropertyFactory.InstantiateNullable();
        }
    }
    private Dictionary<string, EffectivePropertySet> _enhancements = new Dictionary<string, EffectivePropertySet>();
    private PropertyValue[] _writeProperties;
    private PropertyValue[] _overrideProperties;
    public EffectivePropertySet Clone()
    {
        EffectivePropertySet effectivePropertySet = new EffectivePropertySet();

        foreach (KeyValuePair<string, EffectivePropertySet> enhancement in _enhancements)
        {
            effectivePropertySet.AddEnhancement(enhancement.Key, enhancement.Value); // These are immutable.
        }
        effectivePropertySet._overrideProperties = new PropertyValue[_overrideProperties.Length];
        for (int index = 0; index < _overrideProperties.Length; index++)
        {
            effectivePropertySet._overrideProperties[index] = _overrideProperties[index].Clone();
        }
        effectivePropertySet._writeProperties = new PropertyValue[_writeProperties.Length];
        for (int index = 0; index < _writeProperties.Length; index++)
        {
            effectivePropertySet._writeProperties[index] = _writeProperties[index].Clone();
        }

        return effectivePropertySet;
    }
    public void AddEnhancement(string key, EffectivePropertySet effectivePropertySet) 
    {
        _enhancements.Add(key, effectivePropertySet);
    }
    public void AddEnhancement(EffectivePropertySet effectivePropertySet)
    {
        _enhancements.Add(Guid.NewGuid().ToString(), effectivePropertySet);
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
    private PropertyValue GetEffectiveValue(PropertyEnum propertyEnum)
    {
        // Retrieve the index for the property.
        int index = (int)propertyEnum;

        // Retrieve the factory.
        PropertyFactory itemPropertyFactory = _propertyFactories[index];

        // Retrieve a default value from the factory.
        PropertyValue itemProperty = itemPropertyFactory.Instantiate();

        // Merge all of the immutable enhancements.
        foreach (EffectivePropertySet effectivePropertySet in _enhancements.Values)
        {
            itemProperty = itemProperty.Merge(effectivePropertySet.GetEffectiveValue(propertyEnum));
        }

        // Merge the writable enhancements.
        itemProperty = itemProperty.Merge(_writeProperties[index]);

        // Override the enhancements.
        itemProperty = itemProperty.Merge(_overrideProperties[index]);

        // Return the value.
        return itemProperty;
    }

    private bool GetEffectiveBoolValue(PropertyEnum propertyEnum)
    {
        PropertyValue effectiveItemProperty = GetEffectiveValue(propertyEnum);
        BoolPropertyValue boolPropertyValue = (BoolPropertyValue)effectiveItemProperty;
        bool value = boolPropertyValue.Value;
        return value;
    }

    private int GetEffectiveIntValue(PropertyEnum propertyEnum)
    {
        PropertyValue effectiveItemProperty = GetEffectiveValue(propertyEnum);
        IntPropertyValue intPropertyValue = (IntPropertyValue)effectiveItemProperty;
        int value = intPropertyValue.Value;
        return value;
    }

    private void Write(PropertyEnum propertyEnum, PropertyValue propertyValue)
    {
        // Retrieve the index for the property.
        int index = (int)propertyEnum;

        _writeProperties[index] = propertyValue;
    }

    #region Properties
    public bool CanApplyBlessedArtifactBias
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.CanApplyBlessedArtifactBias);
        }
        set
        {
            Write(PropertyEnum.CanApplyBlessedArtifactBias, new BoolPropertyValue(value));
        }
    }
    public bool CanApplyArtifactBiasSlaying
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.CanApplyArtifactBiasSlaying);
        }
        set
        {
            Write(PropertyEnum.CanApplyArtifactBiasSlaying, new BoolPropertyValue(value));
        }
    }
    public bool CanApplyBlowsBonus
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.CanApplyBlowsBonus);
        }
        set
        {
            Write(PropertyEnum.CanApplyBlowsBonus, new BoolPropertyValue(value));
        }
    }
    public bool CanReflectBoltsAndArrows
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.CanReflectBoltsAndArrows);
        }
        set
        {
            Write(PropertyEnum.CanReflectBoltsAndArrows, new BoolPropertyValue(value));
        }
    }
    public bool CanApplySlayingBonus
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.CanApplySlayingBonus);
        }
        set
        {
            Write(PropertyEnum.CanApplySlayingBonus, new BoolPropertyValue(value));
        }
    }
    public bool CanApplyBonusArmorClassMiscPower
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.CanApplyBonusArmorClassMiscPower);
        }
        set
        {
            Write(PropertyEnum.CanApplyBonusArmorClassMiscPower, new BoolPropertyValue(value));
        }
    }
    public bool CanProvideSheathOfElectricity
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.CanProvideSheathOfElectricity);
        }
        set
        {
            Write(PropertyEnum.CanProvideSheathOfElectricity, new BoolPropertyValue(value));
        }
    }
    public bool CanProvideSheathOfFire
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.CanProvideSheathOfFire);
        }
        set
        {
            Write(PropertyEnum.CanProvideSheathOfFire, new BoolPropertyValue(value));
        }
    }
    public int BonusHit
    {
        get
        {
            return GetEffectiveIntValue(PropertyEnum.BonusHit);
        }
        set
        {
            Write(PropertyEnum.BonusHit, new IntPropertyValue(value));
        }
    }
    public int BonusArmorClass
    {
        get
        {
            return GetEffectiveIntValue(PropertyEnum.BonusArmorClass);
        }
        set
        {
            Write(PropertyEnum.BonusArmorClass, new IntPropertyValue(value));
        }
    }
    public int BonusDamage
    {
        get
        {
            return GetEffectiveIntValue(PropertyEnum.BonusDamage);
        }
        set
        {
            Write(PropertyEnum.BonusDamage, new IntPropertyValue(value));
        }
    }
    public int BonusStrength
    {
        get
        {
            return GetEffectiveIntValue(PropertyEnum.BonusStrength);
        }
        set
        {
            Write(PropertyEnum.BonusStrength, new IntPropertyValue(value));
        }
    }
    public int BonusIntelligence
    {
        get
        {
            return GetEffectiveIntValue(PropertyEnum.BonusIntelligence);
        }
        set
        {
            Write(PropertyEnum.BonusIntelligence, new IntPropertyValue(value));
        }
    }
    public int BonusWisdom
    {
        get
        {
            return GetEffectiveIntValue(PropertyEnum.BonusWisdom);
        }
        set
        {
            Write(PropertyEnum.BonusWisdom, new IntPropertyValue(value));
        }
    }
    public int BonusDexterity
    {
        get
        {
            return GetEffectiveIntValue(PropertyEnum.BonusDexterity);
        }
        set
        {
            Write(PropertyEnum.BonusDexterity, new IntPropertyValue(value));
        }
    }
    public int BonusConstitution
    {
        get
        {
            return GetEffectiveIntValue(PropertyEnum.BonusConstitution);
        }
        set
        {
            Write(PropertyEnum.BonusConstitution, new IntPropertyValue(value));
        }
    }
    public int BonusCharisma
    {
        get
        {
            return GetEffectiveIntValue(PropertyEnum.BonusCharisma);
        }
        set
        {
            Write(PropertyEnum.BonusCharisma, new IntPropertyValue(value));
        }
    }
    public int BonusStealth
    {
        get
        {
            return GetEffectiveIntValue(PropertyEnum.BonusStealth);
        }
        set
        {
            Write(PropertyEnum.BonusStealth, new IntPropertyValue(value));
        }
    }
    public int BonusSearch
    {
        get
        {
            return GetEffectiveIntValue(PropertyEnum.BonusSearch);
        }
        set
        {
            Write(PropertyEnum.BonusSearch, new IntPropertyValue(value));
        }
    }
    public int BonusInfravision
    {
        get
        {
            return GetEffectiveIntValue(PropertyEnum.BonusInfravision);
        }
        set
        {
            Write(PropertyEnum.BonusInfravision, new IntPropertyValue(value));
        }
    }
    public int BonusTunnel
    {
        get
        {
            return GetEffectiveIntValue(PropertyEnum.BonusTunnel);
        }
        set
        {
            Write(PropertyEnum.BonusTunnel, new IntPropertyValue(value));
        }
    }
    public int BonusAttacks
    {
        get
        {
            return GetEffectiveIntValue(PropertyEnum.BonusAttacks);
        }
        set
        {
            Write(PropertyEnum.BonusAttacks, new IntPropertyValue(value));
        }
    }
    public int BonusSpeed
    {
        get
        {
            return GetEffectiveIntValue(PropertyEnum.BonusSpeed);
        }
        set
        {
            Write(PropertyEnum.BonusSpeed, new IntPropertyValue(value));
        }
    }
    public Activation? Activation
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool Aggravate
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.Aggravate);
        }
        set
        {
            Write(PropertyEnum.Aggravate, new BoolPropertyValue(value));
        }
    }
    public bool AntiTheft
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.AntiTheft);
        }
        set
        {
            Write(PropertyEnum.AntiTheft, new BoolPropertyValue(value));
        }
    }
    public ArtifactBias? ArtifactBias
    {
        get
        {
            return default;
        }
        set
        {

        }
    }
    public bool Blessed
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.Blessed);
        }
        set
        {
            Write(PropertyEnum.Blessed, new BoolPropertyValue(value));
        }
    }
    public bool Blows
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.Blows);
        }
        set
        {
            Write(PropertyEnum.Blows, new BoolPropertyValue(value));
        }
    }
    public bool BrandAcid
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.BrandAcid);
        }
        set
        {
            Write(PropertyEnum.BrandAcid, new BoolPropertyValue(value));
        }
    }
    public bool BrandCold
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.BrandCold);
        }
        set
        {
            Write(PropertyEnum.BrandCold, new BoolPropertyValue(value));
        }
    }
    public bool BrandElec
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.BrandElec);
        }
        set
        {
            Write(PropertyEnum.BrandElec, new BoolPropertyValue(value));
        }
    }
    public bool BrandFire
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.BrandFire);
        }
        set
        {
            Write(PropertyEnum.BrandFire, new BoolPropertyValue(value));
        }
    }
    public bool BrandPois
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.BrandPois);
        }
        set
        {
            Write(PropertyEnum.BrandPois, new BoolPropertyValue(value));
        }
    }
    public bool Cha
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.Cha);
        }
        set
        {
            Write(PropertyEnum.Cha, new BoolPropertyValue(value));
        }
    }
    public bool Chaotic
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.Chaotic);
        }
        set
        {
            Write(PropertyEnum.Chaotic, new BoolPropertyValue(value));
        }
    }
    public bool Con
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.Con);
        }
        set
        {
            Write(PropertyEnum.Con, new BoolPropertyValue(value));
        }
    }
    public bool IsCursed
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.IsCursed);
        }
        set
        {
            Write(PropertyEnum.IsCursed, new BoolPropertyValue(value));
        }
    }
    public bool Dex
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.Dex);
        }
        set
        {
            Write(PropertyEnum.Dex, new BoolPropertyValue(value));
        }
    }
    public bool DrainExp
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.DrainExp);
        }
        set
        {
            Write(PropertyEnum.DrainExp, new BoolPropertyValue(value));
        }
    }
    public bool DreadCurse
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.DreadCurse);
        }
        set
        {
            Write(PropertyEnum.DreadCurse, new BoolPropertyValue(value));
        }
    }
    public bool EasyKnow
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.EasyKnow);
        }
        set
        {
            Write(PropertyEnum.EasyKnow, new BoolPropertyValue(value));
        }
    }
    public bool Feather
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.Feather);
        }
        set
        {
            Write(PropertyEnum.Feather, new BoolPropertyValue(value));
        }
    }
    public bool FreeAct
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.FreeAct);
        }
        set
        {
            Write(PropertyEnum.FreeAct, new BoolPropertyValue(value));
        }
    }
    public bool HeavyCurse
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.HeavyCurse);
        }
        set
        {
            Write(PropertyEnum.HeavyCurse, new BoolPropertyValue(value));
        }
    }
    public bool HideType
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.HideType);
        }
        set
        {
            Write(PropertyEnum.HideType, new BoolPropertyValue(value));
        }
    }
    public bool HoldLife
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.HoldLife);
        }
        set
        {
            Write(PropertyEnum.HoldLife, new BoolPropertyValue(value));
        }
    }
    public bool IgnoreAcid
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.IgnoreAcid);
        }
        set
        {
            Write(PropertyEnum.IgnoreAcid, new BoolPropertyValue(value));
        }
    }
    public bool IgnoreCold
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.IgnoreCold);
        }
        set
        {
            Write(PropertyEnum.IgnoreCold, new BoolPropertyValue(value));
        }
    }
    public bool IgnoreElec
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.IgnoreElec);
        }
        set
        {
            Write(PropertyEnum.IgnoreElec, new BoolPropertyValue(value));
        }
    }
    public bool IgnoreFire
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.IgnoreFire);
        }
        set
        {
            Write(PropertyEnum.IgnoreFire, new BoolPropertyValue(value));
        }
    }
    public bool ImAcid
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.ImAcid);
        }
        set
        {
            Write(PropertyEnum.ImAcid, new BoolPropertyValue(value));
        }
    }
    public bool ImCold
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.ImCold);
        }
        set
        {
            Write(PropertyEnum.ImCold, new BoolPropertyValue(value));
        }
    }
    public bool ImElec
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.ImElec);
        }
        set
        {
            Write(PropertyEnum.ImElec, new BoolPropertyValue(value));
        }
    }
    public bool ImFire
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.ImFire);
        }
        set
        {
            Write(PropertyEnum.ImFire, new BoolPropertyValue(value));
        }
    }
    public bool Impact
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.Impact);
        }
        set
        {
            Write(PropertyEnum.Impact, new BoolPropertyValue(value));
        }
    }
    public bool Infra
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.Infra);
        }
        set
        {
            Write(PropertyEnum.Infra, new BoolPropertyValue(value));
        }
    }
    public bool InstaArt
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.InstaArt);
        }
        set
        {
            Write(PropertyEnum.InstaArt, new BoolPropertyValue(value));
        }
    }
    public bool Int
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.Int);
        }
        set
        {
            Write(PropertyEnum.Int, new BoolPropertyValue(value));
        }
    }
    public bool KillDragon
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.KillDragon);
        }
        set
        {
            Write(PropertyEnum.KillDragon, new BoolPropertyValue(value));
        }
    }
    public bool NoMagic
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.NoMagic);
        }
        set
        {
            Write(PropertyEnum.NoMagic, new BoolPropertyValue(value));
        }
    }
    public bool NoTele
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.NoTele);
        }
        set
        {
            Write(PropertyEnum.NoTele, new BoolPropertyValue(value));
        }
    }
    public bool PermaCurse
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.PermaCurse);
        }
        set
        {
            Write(PropertyEnum.PermaCurse, new BoolPropertyValue(value));
        }
    }
    public int Radius
    {
        get
        {
            return GetEffectiveIntValue(PropertyEnum.Radius);
        }
        set
        {
            Write(PropertyEnum.Radius, new IntPropertyValue(value));
        }
    }
    public bool Reflect
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.Reflect);
        }
        set
        {
            Write(PropertyEnum.Reflect, new BoolPropertyValue(value));
        }
    }
    public bool Regen
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.Regen);
        }
        set
        {
            Write(PropertyEnum.Regen, new BoolPropertyValue(value));
        }
    }
    public bool ResAcid
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.ResAcid);
        }
        set
        {
            Write(PropertyEnum.ResAcid, new BoolPropertyValue(value));
        }
    }
    public bool ResBlind
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.ResBlind);
        }
        set
        {
            Write(PropertyEnum.ResBlind, new BoolPropertyValue(value));
        }
    }
    public bool ResChaos
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.ResChaos);
        }
        set
        {
            Write(PropertyEnum.ResChaos, new BoolPropertyValue(value));
        }
    }
    public bool ResCold
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.ResCold);
        }
        set
        {
            Write(PropertyEnum.ResCold, new BoolPropertyValue(value));
        }
    }
    public bool ResConf
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.ResConf);
        }
        set
        {
            Write(PropertyEnum.ResConf, new BoolPropertyValue(value));
        }
    }
    public bool ResDark
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.ResDark);
        }
        set
        {
            Write(PropertyEnum.ResDark, new BoolPropertyValue(value));
        }
    }
    public bool ResDisen
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.ResDisen);
        }
        set
        {
            Write(PropertyEnum.ResDisen, new BoolPropertyValue(value));
        }
    }
    public bool ResElec
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.ResElec);
        }
        set
        {
            Write(PropertyEnum.ResElec, new BoolPropertyValue(value));
        }
    }
    public bool ResFear
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.ResFear);
        }
        set
        {
            Write(PropertyEnum.ResFear, new BoolPropertyValue(value));
        }
    }
    public bool ResFire
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.ResFire);
        }
        set
        {
            Write(PropertyEnum.ResFire, new BoolPropertyValue(value));
        }
    }
    public bool ResLight
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.ResLight);
        }
        set
        {
            Write(PropertyEnum.ResLight, new BoolPropertyValue(value));
        }
    }
    public bool ResNether
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.ResNether);
        }
        set
        {
            Write(PropertyEnum.ResNether, new BoolPropertyValue(value));
        }
    }
    public bool ResNexus
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.ResNexus);
        }
        set
        {
            Write(PropertyEnum.ResNexus, new BoolPropertyValue(value));
        }
    }
    public bool ResPois
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.ResPois);
        }
        set
        {
            Write(PropertyEnum.ResPois, new BoolPropertyValue(value));
        }
    }
    public bool ResShards
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.ResShards);
        }
        set
        {
            Write(PropertyEnum.ResShards, new BoolPropertyValue(value));
        }
    }
    public bool ResSound
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.ResSound);
        }
        set
        {
            Write(PropertyEnum.ResSound, new BoolPropertyValue(value));
        }
    }
    public bool Search
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.Search);
        }
        set
        {
            Write(PropertyEnum.Search, new BoolPropertyValue(value));
        }
    }
    public bool SeeInvis
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.SeeInvis);
        }
        set
        {
            Write(PropertyEnum.SeeInvis, new BoolPropertyValue(value));
        }
    }
    public bool ShElec
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.ShElec);
        }
        set
        {
            Write(PropertyEnum.ShElec, new BoolPropertyValue(value));
        }
    }
    public bool ShFire
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.ShFire);
        }
        set
        {
            Write(PropertyEnum.ShFire, new BoolPropertyValue(value));
        }
    }
    public bool ShowMods
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.ShowMods);
        }
        set
        {
            Write(PropertyEnum.ShowMods, new BoolPropertyValue(value));
        }
    }
    public bool SlayAnimal
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.SlayAnimal);
        }
        set
        {
            Write(PropertyEnum.SlayAnimal, new BoolPropertyValue(value));
        }
    }
    public bool SlayDemon
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.SlayDemon);
        }
        set
        {
            Write(PropertyEnum.SlayDemon, new BoolPropertyValue(value));
        }
    }
    public bool SlayDragon
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.SlayDragon);
        }
        set
        {
            Write(PropertyEnum.SlayDragon, new BoolPropertyValue(value));
        }
    }
    public bool SlayEvil
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.SlayEvil);
        }
        set
        {
            Write(PropertyEnum.SlayEvil, new BoolPropertyValue(value));
        }
    }
    public bool SlayGiant
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.SlayGiant);
        }
        set
        {
            Write(PropertyEnum.SlayGiant, new BoolPropertyValue(value));
        }
    }
    public bool SlayOrc
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.SlayOrc);
        }
        set
        {
            Write(PropertyEnum.SlayOrc, new BoolPropertyValue(value));
        }
    }
    public bool SlayTroll
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.SlayTroll);
        }
        set
        {
            Write(PropertyEnum.SlayTroll, new BoolPropertyValue(value));
        }
    }
    public bool SlayUndead
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.SlayUndead);
        }
        set
        {
            Write(PropertyEnum.SlayUndead, new BoolPropertyValue(value));
        }
    }
    public bool SlowDigest
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.SlowDigest);
        }
        set
        {
            Write(PropertyEnum.SlowDigest, new BoolPropertyValue(value));
        }
    }
    public bool Speed
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.Speed);
        }
        set
        {
            Write(PropertyEnum.Speed, new BoolPropertyValue(value));
        }
    }
    public bool Stealth
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.Stealth);
        }
        set
        {
            Write(PropertyEnum.Stealth, new BoolPropertyValue(value));
        }
    }
    public bool Str
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.Str);
        }
        set
        {
            Write(PropertyEnum.Str, new BoolPropertyValue(value));
        }
    }
    public bool SustCha
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.SustCha);
        }
        set
        {
            Write(PropertyEnum.SustCha, new BoolPropertyValue(value));
        }
    }
    public bool SustCon
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.SustCon);
        }
        set
        {
            Write(PropertyEnum.SustCon, new BoolPropertyValue(value));
        }
    }
    public bool SustDex
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.SustDex);
        }
        set
        {
            Write(PropertyEnum.SustDex, new BoolPropertyValue(value));
        }
    }
    public bool SustInt
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.SustInt);
        }
        set
        {
            Write(PropertyEnum.SustInt, new BoolPropertyValue(value));
        }
    }
    public bool SustStr
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.SustStr);
        }
        set
        {
            Write(PropertyEnum.SustStr, new BoolPropertyValue(value));
        }
    }
    public bool SustWis
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.SustWis);
        }
        set
        {
            Write(PropertyEnum.SustWis, new BoolPropertyValue(value));
        }
    }
    public bool Telepathy
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.Telepathy);
        }
        set
        {
            Write(PropertyEnum.Telepathy, new BoolPropertyValue(value));
        }
    }
    public bool Teleport
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.Teleport);
        }
        set
        {
            Write(PropertyEnum.Teleport, new BoolPropertyValue(value));
        }
    }
    public int TreasureRating
    {
        get
        {
            return GetEffectiveIntValue(PropertyEnum.TreasureRating);
        }
        set
        {
            Write(PropertyEnum.TreasureRating, new IntPropertyValue(value));
        }
    }
    public bool Tunnel
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.Tunnel);
        }
        set
        {
            Write(PropertyEnum.Tunnel, new BoolPropertyValue(value));
        }
    }
    public int Value
    {
        get
        {
            return GetEffectiveIntValue(PropertyEnum.Value);
        }
        set
        {
            Write(PropertyEnum.Value, new IntPropertyValue(value));
        }
    }
    public bool Valueless
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.Valueless);
        }
        set
        {
            Write(PropertyEnum.Valueless, new BoolPropertyValue(value));
        }
    }
    public bool Vampiric
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.Vampiric);
        }
        set
        {
            Write(PropertyEnum.Vampiric, new BoolPropertyValue(value));
        }
    }
    public bool Vorpal
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.Vorpal);
        }
        set
        {
            Write(PropertyEnum.Vorpal, new BoolPropertyValue(value));
        }
    }
    public bool Wis
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.Wis);
        }
        set
        {
            Write(PropertyEnum.Wis, new BoolPropertyValue(value));
        }
    }
    public bool Wraith
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.Wraith);
        }
        set
        {
            Write(PropertyEnum.Wraith, new BoolPropertyValue(value));
        }
    }
    public bool XtraMight
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.XtraMight);
        }
        set
        {
            Write(PropertyEnum.XtraMight, new BoolPropertyValue(value));
        }
    }
    public bool XtraShots
    {
        get
        {
            return GetEffectiveBoolValue(PropertyEnum.XtraShots);
        }
        set
        {
            Write(PropertyEnum.XtraShots, new BoolPropertyValue(value));
        }
    }
    #endregion
}