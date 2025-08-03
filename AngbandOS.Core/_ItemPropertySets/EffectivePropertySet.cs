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
    private PropertyValue GetValue(PropertyEnum propertyEnum)
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
            itemProperty = itemProperty.Merge(effectivePropertySet.GetValue(propertyEnum));
        }

        // Merge the writable enhancements.
        itemProperty = itemProperty.Merge(_writeProperties[index]);

        // Override the enhancements.
        itemProperty = itemProperty.Merge(_overrideProperties[index]);

        // Return the value.
        return itemProperty;
    }

    private bool GetBoolValue(PropertyEnum propertyEnum)
    {
        PropertyValue effectiveItemProperty = GetValue(propertyEnum);
        BoolPropertyValue boolPropertyValue = (BoolPropertyValue)effectiveItemProperty;
        bool value = boolPropertyValue.Value;
        return value;
    }

    private int GetIntValue(PropertyEnum propertyEnum)
    {
        PropertyValue effectiveItemProperty = GetValue(propertyEnum);
        IntPropertyValue intPropertyValue = (IntPropertyValue)effectiveItemProperty;
        int value = intPropertyValue.Value;
        return value;
    }

    private void SetValue(PropertyEnum propertyEnum, PropertyValue propertyValue)
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
            return GetBoolValue(PropertyEnum.CanApplyBlessedArtifactBias);
        }
        set
        {
            SetValue(PropertyEnum.CanApplyBlessedArtifactBias, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.CanApplyArtifactBiasSlaying, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.CanApplyBlowsBonus, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.CanReflectBoltsAndArrows, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.CanApplySlayingBonus, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.CanApplyBonusArmorClassMiscPower, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.CanProvideSheathOfElectricity, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.CanProvideSheathOfFire, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.BonusHit, new IntPropertyValue(value));
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
            SetValue(PropertyEnum.BonusArmorClass, new IntPropertyValue(value));
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
            SetValue(PropertyEnum.BonusDamage, new IntPropertyValue(value));
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
            SetValue(PropertyEnum.BonusStrength, new IntPropertyValue(value));
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
            SetValue(PropertyEnum.BonusIntelligence, new IntPropertyValue(value));
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
            SetValue(PropertyEnum.BonusWisdom, new IntPropertyValue(value));
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
            SetValue(PropertyEnum.BonusDexterity, new IntPropertyValue(value));
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
            SetValue(PropertyEnum.BonusConstitution, new IntPropertyValue(value));
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
            SetValue(PropertyEnum.BonusCharisma, new IntPropertyValue(value));
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
            SetValue(PropertyEnum.BonusStealth, new IntPropertyValue(value));
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
            SetValue(PropertyEnum.BonusSearch, new IntPropertyValue(value));
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
            SetValue(PropertyEnum.BonusInfravision, new IntPropertyValue(value));
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
            SetValue(PropertyEnum.BonusTunnel, new IntPropertyValue(value));
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
            SetValue(PropertyEnum.BonusAttacks, new IntPropertyValue(value));
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
            SetValue(PropertyEnum.BonusSpeed, new IntPropertyValue(value));
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
            return GetBoolValue(PropertyEnum.Aggravate);
        }
        set
        {
            SetValue(PropertyEnum.Aggravate, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.AntiTheft, new BoolPropertyValue(value));
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
            return GetBoolValue(PropertyEnum.Blessed);
        }
        set
        {
            SetValue(PropertyEnum.Blessed, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.Blows, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.BrandAcid, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.BrandCold, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.BrandElec, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.BrandFire, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.BrandPois, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.Cha, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.Chaotic, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.Con, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.IsCursed, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.Dex, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.DrainExp, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.DreadCurse, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.EasyKnow, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.Feather, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.FreeAct, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.HeavyCurse, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.HideType, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.HoldLife, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.IgnoreAcid, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.IgnoreCold, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.IgnoreElec, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.IgnoreFire, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.ImAcid, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.ImCold, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.ImElec, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.ImFire, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.Impact, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.Infra, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.InstaArt, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.Int, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.KillDragon, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.NoMagic, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.NoTele, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.PermaCurse, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.Radius, new IntPropertyValue(value));
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
            SetValue(PropertyEnum.Reflect, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.Regen, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.ResAcid, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.ResBlind, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.ResChaos, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.ResCold, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.ResConf, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.ResDark, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.ResDisen, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.ResElec, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.ResFear, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.ResFire, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.ResLight, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.ResNether, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.ResNexus, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.ResPois, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.ResShards, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.ResSound, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.Search, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.SeeInvis, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.ShElec, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.ShFire, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.ShowMods, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.SlayAnimal, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.SlayDemon, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.SlayDragon, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.SlayEvil, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.SlayGiant, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.SlayOrc, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.SlayTroll, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.SlayUndead, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.SlowDigest, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.Speed, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.Stealth, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.Str, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.SustCha, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.SustCon, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.SustDex, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.SustInt, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.SustStr, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.SustWis, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.Telepathy, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.Teleport, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.TreasureRating, new IntPropertyValue(value));
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
            SetValue(PropertyEnum.Tunnel, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.Value, new IntPropertyValue(value));
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
            SetValue(PropertyEnum.Valueless, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.Vampiric, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.Vorpal, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.Wis, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.Wraith, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.XtraMight, new BoolPropertyValue(value));
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
            SetValue(PropertyEnum.XtraShots, new BoolPropertyValue(value));
        }
    }
    #endregion
}