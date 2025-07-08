// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class RwItemPropertySet : ItemPropertySet
{
    public RwItemPropertySet()
    {
        foreach (ItemPropertyFactory itemCharacteristicFactory in ItemPropertyFactories)
        {
            ItemProperties[itemCharacteristicFactory.Index] = itemCharacteristicFactory.Instantiate();
        }
    }

    public RwItemPropertySet(ItemProperty[] itemCharacteristics) : base(itemCharacteristics) { }

    /// <summary>
    /// Returns a cloned set of item properties.
    /// </summary>
    /// <remarks>
    /// This read-write version of the clone is used to clone the <see cref="Item.EnchantmentItemProperties"/> when cloning an <see cref="Item"/>.
    /// </remarks>
    /// <returns></returns>
    public RwItemPropertySet Clone()
    {
        ItemProperty[] clonedItemCharacteristics = CloneAllItemProperties();
        return new RwItemPropertySet(clonedItemCharacteristics);
    }

    public RoItemPropertySet AsReadOnly()
    {
        return new RoItemPropertySet(ItemProperties);
    }

    public RwItemPropertySet Merge(RoItemPropertySet itemCharacteristics)
    {
        ItemProperty[] mergedItemCharacteristics = MergeAllItemProperties(itemCharacteristics);
        return new RwItemPropertySet(mergedItemCharacteristics);
    }

    #region Properties
    public bool CanApplyBlessedArtifactBias
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanApplyBlessedArtifactBias];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanApplyBlessedArtifactBias];
            rwValueItemProperty.Value = value;
        }
    }
    public bool CanApplyArtifactBiasSlaying
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanApplyArtifactBiasSlaying];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanApplyArtifactBiasSlaying];
            rwValueItemProperty.Value = value;
        }
    }
    public bool CanApplyBlowsBonus
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanApplyBlowsBonus];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanApplyBlowsBonus];
            rwValueItemProperty.Value = value;
        }
    }
    public bool CanReflectBoltsAndArrows
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanReflectBoltsAndArrows];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanReflectBoltsAndArrows];
            rwValueItemProperty.Value = value;
        }
    }
    public bool CanApplySlayingBonus
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanApplySlayingBonus];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanApplySlayingBonus];
            rwValueItemProperty.Value = value;
        }
    }
    public bool CanApplyBonusArmorClassMiscPower
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanApplyBonusArmorClassMiscPower];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanApplyBonusArmorClassMiscPower];
            rwValueItemProperty.Value = value;
        }
    }
    public bool CanProvideSheathOfElectricity
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanProvideSheathOfElectricity];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanProvideSheathOfElectricity];
            rwValueItemProperty.Value = value;
        }
    }
    public bool CanProvideSheathOfFire
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanProvideSheathOfFire];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanProvideSheathOfFire];
            rwValueItemProperty.Value = value;
        }
    }
    public int BonusHit
    {
        get
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusHit];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusHit];
            rwValueItemProperty.Value = value;
        }
    }
    public int BonusArmorClass
    {
        get
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusArmorClass];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusArmorClass];
            rwValueItemProperty.Value = value;
        }
    }
    public int BonusDamage
    {
        get
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusDamage];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusDamage];
            rwValueItemProperty.Value = value;
        }
    }
    public int BonusStrength
    {
        get
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusStrength];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusStrength];
            rwValueItemProperty.Value = value;
        }
    }
    public int BonusIntelligence
    {
        get
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusIntelligence];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusIntelligence];
            rwValueItemProperty.Value = value;
        }
    }
    public int BonusWisdom
    {
        get
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusWisdom];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusWisdom];
            rwValueItemProperty.Value = value;
        }
    }
    public int BonusDexterity
    {
        get
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusDexterity];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusDexterity];
            rwValueItemProperty.Value = value;
        }
    }
    public int BonusConstitution
    {
        get
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusConstitution];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusConstitution];
            rwValueItemProperty.Value = value;
        }
    }
    public int BonusCharisma
    {
        get
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusCharisma];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusCharisma];
            rwValueItemProperty.Value = value;
        }
    }
    public int BonusStealth
    {
        get
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusStealth];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusStealth];
            rwValueItemProperty.Value = value;
        }
    }
    public int BonusSearch
    {
        get
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusSearch];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusSearch];
            rwValueItemProperty.Value = value;
        }
    }
    public int BonusInfravision
    {
        get
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusInfravision];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusInfravision];
            rwValueItemProperty.Value = value;
        }
    }
    public int BonusTunnel
    {
        get
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusTunnel];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusTunnel];
            rwValueItemProperty.Value = value;
        }
    }
    public int BonusAttacks
    {
        get
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusAttacks];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusAttacks];
            rwValueItemProperty.Value = value;
        }
    }
    public int BonusSpeed
    {
        get
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusSpeed];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusSpeed];
            rwValueItemProperty.Value = value;
        }
    }
    public Activation? Activation
    {
        get
        {
            NullableReferenceItemProperty<Activation> nullableReferenceItemProperty = (NullableReferenceItemProperty<Activation>)ItemProperties[(int)ItemPropertiesEnum.Activation];
            return nullableReferenceItemProperty.Value;
        }
        set
        {
            NullableReferenceItemProperty<Activation> nullableReferenceItemProperty = (NullableReferenceItemProperty<Activation>)ItemProperties[(int)ItemPropertiesEnum.Activation];
            nullableReferenceItemProperty.Value = value;
        }
    }
    public bool Aggravate
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Aggravate];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Aggravate];
            rwValueItemProperty.Value = value;
        }
    }
    public bool AntiTheft
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.AntiTheft];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.AntiTheft];
            rwValueItemProperty.Value = value;
        }
    }
    public ArtifactBias? ArtifactBias
    {
        get
        {
            NullableReferenceItemProperty<ArtifactBias> nullableReferenceItemProperty = (NullableReferenceItemProperty<ArtifactBias>)ItemProperties[(int)ItemPropertiesEnum.ArtifactBias];
            return nullableReferenceItemProperty.Value;
        }
        set
        {
            NullableReferenceItemProperty<ArtifactBias> nullableReferenceItemProperty = (NullableReferenceItemProperty<ArtifactBias>)ItemProperties[(int)ItemPropertiesEnum.ArtifactBias];
            nullableReferenceItemProperty.Value = value;
        }
    }
    public bool Blessed
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Blessed];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Blessed];
            rwValueItemProperty.Value = value;
        }
    }
    public bool Blows
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Blows];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Blows];
            rwValueItemProperty.Value = value;
        }
    }
    public bool BrandAcid
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.BrandAcid];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.BrandAcid];
            rwValueItemProperty.Value = value;
        }
    }
    public bool BrandCold
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.BrandCold];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.BrandCold];
            rwValueItemProperty.Value = value;
        }
    }
    public bool BrandElec
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.BrandElec];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.BrandElec];
            rwValueItemProperty.Value = value;
        }
    }
    public bool BrandFire
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.BrandFire];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.BrandFire];
            rwValueItemProperty.Value = value;
        }
    }
    public bool BrandPois
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.BrandPois];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.BrandPois];
            rwValueItemProperty.Value = value;
        }
    }
    public bool Cha
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Cha];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Cha];
            rwValueItemProperty.Value = value;
        }
    }
    public bool Chaotic
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Chaotic];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Chaotic];
            rwValueItemProperty.Value = value;
        }
    }
    public bool Con
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Con];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Con];
            rwValueItemProperty.Value = value;
        }
    }
    public bool IsCursed
    {
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IsCursed];
            rwValueItemProperty.Value = value;
        }
    }
    public bool Dex
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Dex];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Dex];
            rwValueItemProperty.Value = value;
        }
    }
    public bool DrainExp
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.DrainExp];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.DrainExp];
            rwValueItemProperty.Value = value;
        }
    }
    public bool DreadCurse
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.DreadCurse];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.DreadCurse];
            rwValueItemProperty.Value = value;
        }
    }
    public bool EasyKnow
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.EasyKnow];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.EasyKnow];
            rwValueItemProperty.Value = value;
        }
    }
    public bool Feather
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Feather];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Feather];
            rwValueItemProperty.Value = value;
        }
    }
    public bool FreeAct
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.FreeAct];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.FreeAct];
            rwValueItemProperty.Value = value;
        }
    }
    public bool HeavyCurse
    {
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.HeavyCurse];
            rwValueItemProperty.Value = value;
        }
    }
    public bool HideType
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.HideType];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.HideType];
            rwValueItemProperty.Value = value;
        }
    }
    public bool HoldLife
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.HoldLife];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.HoldLife];
            rwValueItemProperty.Value = value;
        }
    }
    public bool IgnoreAcid
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IgnoreAcid];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IgnoreAcid];
            rwValueItemProperty.Value = value;
        }
    }
    public bool IgnoreCold
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IgnoreCold];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IgnoreCold];
            rwValueItemProperty.Value = value;
        }
    }
    public bool IgnoreElec
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IgnoreElec];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IgnoreElec];
            rwValueItemProperty.Value = value;
        }
    }
    public bool IgnoreFire
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IgnoreFire];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IgnoreFire];
            rwValueItemProperty.Value = value;
        }
    }
    public bool ImAcid
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ImAcid];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ImAcid];
            rwValueItemProperty.Value = value;
        }
    }
    public bool ImCold
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ImCold];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ImCold];
            rwValueItemProperty.Value = value;
        }
    }
    public bool ImElec
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ImElec];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ImElec];
            rwValueItemProperty.Value = value;
        }
    }
    public bool ImFire
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ImFire];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ImFire];
            rwValueItemProperty.Value = value;
        }
    }
    public bool Impact
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Impact];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Impact];
            rwValueItemProperty.Value = value;
        }
    }
    public bool Infra
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Infra];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Infra];
            rwValueItemProperty.Value = value;
        }
    }
    public bool InstaArt
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.InstaArt];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.InstaArt];
            rwValueItemProperty.Value = value;
        }
    }
    public bool Int
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Int];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Int];
            rwValueItemProperty.Value = value;
        }
    }
    public bool KillDragon
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.KillDragon];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.KillDragon];
            rwValueItemProperty.Value = value;
        }
    }
    public bool NoMagic
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.NoMagic];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.NoMagic];
            rwValueItemProperty.Value = value;
        }
    }
    public bool NoTele
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.NoTele];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.NoTele];
            rwValueItemProperty.Value = value;
        }
    }
    public bool PermaCurse
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.PermaCurse];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.PermaCurse];
            rwValueItemProperty.Value = value;
        }
    }
    public int Radius
    {
        get
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.Radius];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.Radius];
            rwValueItemProperty.Value = value;
        }
    }
    public bool Reflect
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Reflect];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Reflect];
            rwValueItemProperty.Value = value;
        }
    }
    public bool Regen
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Regen];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Regen];
            rwValueItemProperty.Value = value;
        }
    }
    public bool ResAcid
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResAcid];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResAcid];
            rwValueItemProperty.Value = value;
        }
    }
    public bool ResBlind
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResBlind];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResBlind];
            rwValueItemProperty.Value = value;
        }
    }
    public bool ResChaos
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResChaos];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResChaos];
            rwValueItemProperty.Value = value;
        }
    }
    public bool ResCold
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResCold];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResCold];
            rwValueItemProperty.Value = value;
        }
    }
    public bool ResConf
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResConf];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResConf];
            rwValueItemProperty.Value = value;
        }
    }
    public bool ResDark
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResDark];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResDark];
            rwValueItemProperty.Value = value;
        }
    }
    public bool ResDisen
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResDisen];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResDisen];
            rwValueItemProperty.Value = value;
        }
    }
    public bool ResElec
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResElec];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResElec];
            rwValueItemProperty.Value = value;
        }
    }
    public bool ResFear
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResFear];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResFear];
            rwValueItemProperty.Value = value;
        }
    }
    public bool ResFire
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResFire];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResFire];
            rwValueItemProperty.Value = value;
        }
    }
    public bool ResLight
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResLight];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResLight];
            rwValueItemProperty.Value = value;
        }
    }
    public bool ResNether
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResNether];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResNether];
            rwValueItemProperty.Value = value;
        }
    }
    public bool ResNexus
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResNexus];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResNexus];
            rwValueItemProperty.Value = value;
        }
    }
    public bool ResPois
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResPois];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResPois];
            rwValueItemProperty.Value = value;
        }
    }
    public bool ResShards
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResShards];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResShards];
            rwValueItemProperty.Value = value;
        }
    }
    public bool ResSound
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResSound];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResSound];
            rwValueItemProperty.Value = value;
        }
    }
    public bool Search
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Search];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Search];
            rwValueItemProperty.Value = value;
        }
    }
    public bool SeeInvis
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SeeInvis];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SeeInvis];
            rwValueItemProperty.Value = value;
        }
    }
    public bool ShElec
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ShElec];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ShElec];
            rwValueItemProperty.Value = value;
        }
    }
    public bool ShFire
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ShFire];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ShFire];
            rwValueItemProperty.Value = value;
        }
    }
    public bool ShowMods
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ShowMods];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ShowMods];
            rwValueItemProperty.Value = value;
        }
    }
    public bool SlayAnimal
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayAnimal];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayAnimal];
            rwValueItemProperty.Value = value;
        }
    }
    public bool SlayDemon
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayDemon];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayDemon];
            rwValueItemProperty.Value = value;
        }
    }
    public bool SlayDragon
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayDragon];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayDragon];
            rwValueItemProperty.Value = value;
        }
    }
    public bool SlayEvil
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayEvil];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayEvil];
            rwValueItemProperty.Value = value;
        }
    }
    public bool SlayGiant
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayGiant];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayGiant];
            rwValueItemProperty.Value = value;
        }
    }
    public bool SlayOrc
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayOrc];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayOrc];
            rwValueItemProperty.Value = value;
        }
    }
    public bool SlayTroll
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayTroll];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayTroll];
            rwValueItemProperty.Value = value;
        }
    }
    public bool SlayUndead
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayUndead];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayUndead];
            rwValueItemProperty.Value = value;
        }
    }
    public bool SlowDigest
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlowDigest];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlowDigest];
            rwValueItemProperty.Value = value;
        }
    }
    public bool Speed
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Speed];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Speed];
            rwValueItemProperty.Value = value;
        }
    }
    public bool Stealth
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Stealth];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Stealth];
            rwValueItemProperty.Value = value;
        }
    }
    public bool Str
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Str];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Str];
            rwValueItemProperty.Value = value;
        }
    }
    public bool SustCha
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustCha];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustCha];
            rwValueItemProperty.Value = value;
        }
    }
    public bool SustCon
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustCon];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustCon];
            rwValueItemProperty.Value = value;
        }
    }
    public bool SustDex
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustDex];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustDex];
            rwValueItemProperty.Value = value;
        }
    }
    public bool SustInt
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustInt];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustInt];
            rwValueItemProperty.Value = value;
        }
    }
    public bool SustStr
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustStr];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustStr];
            rwValueItemProperty.Value = value;
        }
    }
    public bool SustWis
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustWis];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustWis];
            rwValueItemProperty.Value = value;
        }
    }
    public bool Telepathy
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Telepathy];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Telepathy];
            rwValueItemProperty.Value = value;
        }
    }
    public bool Teleport
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Teleport];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Teleport];
            rwValueItemProperty.Value = value;
        }
    }
    public int TreasureRating
    {
        get
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.TreasureRating];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<int> rwValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.TreasureRating];
            rwValueItemProperty.Value = value;
        }
    }
    public bool Tunnel
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Tunnel];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Tunnel];
            rwValueItemProperty.Value = value;
        }
    }
    public bool Valueless
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Valueless];
            return ValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Valueless];
            ValueItemProperty.Value = value;
        }
    }
    public bool Vampiric
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Vampiric];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Vampiric];
            rwValueItemProperty.Value = value;
        }
    }
    public bool Vorpal
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Vorpal];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Vorpal];
            rwValueItemProperty.Value = value;
        }
    }
    public bool Wis
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Wis];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Wis];
            rwValueItemProperty.Value = value;
        }
    }
    public bool Wraith
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Wraith];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Wraith];
            rwValueItemProperty.Value = value;
        }
    }
    public bool XtraMight
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.XtraMight];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.XtraMight];
            rwValueItemProperty.Value = value;
        }
    }
    public bool XtraShots
    {
        get
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.XtraShots];
            return rwValueItemProperty.Value;
        }
        set
        {
            ValueItemProperty<bool> rwValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.XtraShots];
            rwValueItemProperty.Value = value;
        }
    }
    #endregion
}
