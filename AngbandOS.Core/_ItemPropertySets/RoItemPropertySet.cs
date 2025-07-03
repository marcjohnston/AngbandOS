// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class RoItemPropertySet : ItemPropertySet
{
    public RoItemPropertySet()
    {
        foreach (ItemPropertyFactory itemCharacteristicFactory in ItemPropertyFactories)
        {
            ItemProperties[itemCharacteristicFactory.Index] = itemCharacteristicFactory.Instantiate();
        }
    }

    public RoItemPropertySet(ItemProperty[] itemCharacteristics) : base(itemCharacteristics) { }

    /// <summary>
    /// Returns a cloned set of item properties.
    /// </summary>
    /// <returns></returns>
    public RoItemPropertySet Clone()
    {
        ItemProperty[] clonedItemCharacteristics = CloneAllItemProperties();
        return new RoItemPropertySet(clonedItemCharacteristics);
    }

    /// <summary>
    /// Returns a read-only set of item properties that represents the merging of this item property set with another item property set of any access-modifier.
    /// </summary>
    /// <param name="itemCharacteristics"></param>
    /// <returns></returns>
    public RoItemPropertySet Merge(ItemPropertySet? itemCharacteristics)
    {
        ItemProperty[] mergedItemCharacteristics = MergeAllItemProperties(itemCharacteristics);
        return new RoItemPropertySet(mergedItemCharacteristics);
    }

    public RwItemPropertySet AsWriteable()
    {
        return new RwItemPropertySet(ItemProperties);
    }

    #region Properties
    public bool CanApplyBlessedArtifactBias
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanApplyBlessedArtifactBias];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanApplyBlessedArtifactBias];
            ValueItemProperty.Value = value;
        }
    }
    public bool CanApplyArtifactBiasSlaying
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanApplyArtifactBiasSlaying];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanApplyArtifactBiasSlaying];
            ValueItemProperty.Value = value;
        }
    }
    public bool CanApplyBlowsBonus
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanApplyBlowsBonus];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanApplyBlowsBonus];
            ValueItemProperty.Value = value;
        }
    }
    public bool CanReflectBoltsAndArrows
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanReflectBoltsAndArrows];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanReflectBoltsAndArrows];
            ValueItemProperty.Value = value;
        }
    }
    public bool CanApplySlayingBonus
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanApplySlayingBonus];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanApplySlayingBonus];
            ValueItemProperty.Value = value;
        }
    }
    public bool CanApplyBonusArmorClassMiscPower
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanApplyBonusArmorClassMiscPower];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanApplyBonusArmorClassMiscPower];
            ValueItemProperty.Value = value;
        }
    }
    public bool CanProvideSheathOfElectricity
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanProvideSheathOfElectricity];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanProvideSheathOfElectricity];
            ValueItemProperty.Value = value;
        }
    }
    public bool CanProvideSheathOfFire
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanProvideSheathOfFire];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanProvideSheathOfFire];
            ValueItemProperty.Value = value;
        }
    }
    public int BonusHit
    {
        get
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusHit];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusHit];
            ValueItemProperty.Value = value;
        }
    }
    public int BonusArmorClass
    {
        get
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusArmorClass];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusArmorClass];
            ValueItemProperty.Value = value;
        }
    }
    public int BonusDamage
    {
        get
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusDamage];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusDamage];
            ValueItemProperty.Value = value;
        }
    }
    public int BonusStrength
    {
        get
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusStrength];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusStrength];
            ValueItemProperty.Value = value;
        }
    }
    public int BonusIntelligence
    {
        get
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusIntelligence];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusIntelligence];
            ValueItemProperty.Value = value;
        }
    }
    public int BonusWisdom
    {
        get
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusWisdom];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusWisdom];
            ValueItemProperty.Value = value;
        }
    }
    public int BonusDexterity
    {
        get
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusDexterity];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusDexterity];
            ValueItemProperty.Value = value;
        }
    }
    public int BonusConstitution
    {
        get
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusConstitution];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusConstitution];
            ValueItemProperty.Value = value;
        }
    }
    public int BonusCharisma
    {
        get
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusCharisma];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusCharisma];
            ValueItemProperty.Value = value;
        }
    }
    public int BonusStealth
    {
        get
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusStealth];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusStealth];
            ValueItemProperty.Value = value;
        }
    }
    public int BonusSearch
    {
        get
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusSearch];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusSearch];
            ValueItemProperty.Value = value;
        }
    }
    public int BonusInfravision
    {
        get
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusInfravision];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusInfravision];
            ValueItemProperty.Value = value;
        }
    }
    public int BonusTunnel
    {
        get
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusTunnel];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusTunnel];
            ValueItemProperty.Value = value;
        }
    }
    public int BonusAttacks
    {
        get
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusAttacks];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusAttacks];
            ValueItemProperty.Value = value;
        }
    }
    public int BonusSpeed
    {
        get
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusSpeed];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusSpeed];
            ValueItemProperty.Value = value;
        }
    }
    public Activation? Activation
    {
        get
        {
            NullableReferenceItemProperty<Activation> nullableReferenceItemProperty = (NullableReferenceItemProperty<Activation>)ItemProperties[(int)ItemPropertiesEnum.Activation];
            return nullableReferenceItemProperty.Value;
        }
        init
        {
            NullableReferenceItemProperty<Activation> nullableReferenceItemProperty = (NullableReferenceItemProperty<Activation>)ItemProperties[(int)ItemPropertiesEnum.Activation];
            nullableReferenceItemProperty.Value = value;
        }
    }
    public bool Aggravate
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Aggravate];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Aggravate];
            ValueItemProperty.Value = value;
        }
    }
    public bool AntiTheft
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.AntiTheft];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.AntiTheft];
            ValueItemProperty.Value = value;
        }
    }
    public ArtifactBias? ArtifactBias
    {
        get
        {
            NullableReferenceItemProperty<ArtifactBias> nullableReferenceItemProperty = (NullableReferenceItemProperty<ArtifactBias>)ItemProperties[(int)ItemPropertiesEnum.ArtifactBias];
            return nullableReferenceItemProperty.Value;
        }
        init
        {
            NullableReferenceItemProperty<ArtifactBias> nullableReferenceItemProperty = (NullableReferenceItemProperty<ArtifactBias>)ItemProperties[(int)ItemPropertiesEnum.ArtifactBias];
            nullableReferenceItemProperty.Value = value;
        }
    }
    public bool Blessed
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Blessed];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Blessed];
            ValueItemProperty.Value = value;
        }
    }
    public bool Blows
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Blows];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Blows];
            ValueItemProperty.Value = value;
        }
    }
    public bool BrandAcid
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.BrandAcid];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.BrandAcid];
            ValueItemProperty.Value = value;
        }
    }
    public bool BrandCold
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.BrandCold];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.BrandCold];
            ValueItemProperty.Value = value;
        }
    }
    public bool BrandElec
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.BrandElec];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.BrandElec];
            ValueItemProperty.Value = value;
        }
    }
    public bool BrandFire
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.BrandFire];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.BrandFire];
            ValueItemProperty.Value = value;
        }
    }
    public bool BrandPois
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.BrandPois];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.BrandPois];
            ValueItemProperty.Value = value;
        }
    }
    public bool Cha
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Cha];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Cha];
            ValueItemProperty.Value = value;
        }
    }
    public bool Chaotic
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Chaotic];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Chaotic];
            ValueItemProperty.Value = value;
        }
    }
    public bool Con
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Con];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Con];
            ValueItemProperty.Value = value;
        }
    }
    public bool IsCursed
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IsCursed];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IsCursed];
            ValueItemProperty.Value = value;
        }
    }
    public bool Dex
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Dex];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Dex];
            ValueItemProperty.Value = value;
        }
    }
    public bool DrainExp
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.DrainExp];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.DrainExp];
            ValueItemProperty.Value = value;
        }
    }
    public bool DreadCurse
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.DreadCurse];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.DreadCurse];
            ValueItemProperty.Value = value;
        }
    }
    public bool EasyKnow
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.EasyKnow];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.EasyKnow];
            ValueItemProperty.Value = value;
        }
    }
    public bool Feather
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Feather];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Feather];
            ValueItemProperty.Value = value;
        }
    }
    public bool FreeAct
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.FreeAct];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.FreeAct];
            ValueItemProperty.Value = value;
        }
    }
    public bool HeavyCurse
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.HeavyCurse];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.HeavyCurse];
            ValueItemProperty.Value = value;
        }
    }
    public bool HideType
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.HideType];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.HideType];
            ValueItemProperty.Value = value;
        }
    }
    public bool HoldLife
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.HoldLife];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.HoldLife];
            ValueItemProperty.Value = value;
        }
    }
    public bool IgnoreAcid
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IgnoreAcid];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IgnoreAcid];
            ValueItemProperty.Value = value;
        }
    }
    public bool IgnoreCold
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IgnoreCold];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IgnoreCold];
            ValueItemProperty.Value = value;
        }
    }
    public bool IgnoreElec
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IgnoreElec];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IgnoreElec];
            ValueItemProperty.Value = value;
        }
    }
    public bool IgnoreFire
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IgnoreFire];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IgnoreFire];
            ValueItemProperty.Value = value;
        }
    }
    public bool ImAcid
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ImAcid];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ImAcid];
            ValueItemProperty.Value = value;
        }
    }
    public bool ImCold
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ImCold];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ImCold];
            ValueItemProperty.Value = value;
        }
    }
    public bool ImElec
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ImElec];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ImElec];
            ValueItemProperty.Value = value;
        }
    }
    public bool ImFire
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ImFire];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ImFire];
            ValueItemProperty.Value = value;
        }
    }
    public bool Impact
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Impact];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Impact];
            ValueItemProperty.Value = value;
        }
    }
    public bool Infra
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Infra];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Infra];
            ValueItemProperty.Value = value;
        }
    }
    public bool InstaArt
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.InstaArt];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.InstaArt];
            ValueItemProperty.Value = value;
        }
    }
    public bool Int
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Int];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Int];
            ValueItemProperty.Value = value;
        }
    }
    public bool KillDragon
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.KillDragon];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.KillDragon];
            ValueItemProperty.Value = value;
        }
    }
    public bool NoMagic
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.NoMagic];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.NoMagic];
            ValueItemProperty.Value = value;
        }
    }
    public bool NoTele
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.NoTele];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.NoTele];
            ValueItemProperty.Value = value;
        }
    }
    public bool PermaCurse
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.PermaCurse];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.PermaCurse];
            ValueItemProperty.Value = value;
        }
    }
    public int Radius
    {
        get
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.Radius];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.Radius];
            ValueItemProperty.Value = value;
        }
    }
    public bool Reflect
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Reflect];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Reflect];
            ValueItemProperty.Value = value;
        }
    }
    public bool Regen
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Regen];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Regen];
            ValueItemProperty.Value = value;
        }
    }
    public bool ResAcid
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResAcid];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResAcid];
            ValueItemProperty.Value = value;
        }
    }
    public bool ResBlind
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResBlind];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResBlind];
            ValueItemProperty.Value = value;
        }
    }
    public bool ResChaos
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResChaos];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResChaos];
            ValueItemProperty.Value = value;
        }
    }
    public bool ResCold
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResCold];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResCold];
            ValueItemProperty.Value = value;
        }
    }
    public bool ResConf
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResConf];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResConf];
            ValueItemProperty.Value = value;
        }
    }
    public bool ResDark
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResDark];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResDark];
            ValueItemProperty.Value = value;
        }
    }
    public bool ResDisen
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResDisen];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResDisen];
            ValueItemProperty.Value = value;
        }
    }
    public bool ResElec
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResElec];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResElec];
            ValueItemProperty.Value = value;
        }
    }
    public bool ResFear
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResFear];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResFear];
            ValueItemProperty.Value = value;
        }
    }
    public bool ResFire
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResFire];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResFire];
            ValueItemProperty.Value = value;
        }
    }
    public bool ResLight
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResLight];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResLight];
            ValueItemProperty.Value = value;
        }
    }
    public bool ResNether
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResNether];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResNether];
            ValueItemProperty.Value = value;
        }
    }
    public bool ResNexus
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResNexus];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResNexus];
            ValueItemProperty.Value = value;
        }
    }
    public bool ResPois
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResPois];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResPois];
            ValueItemProperty.Value = value;
        }
    }
    public bool ResShards
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResShards];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResShards];
            ValueItemProperty.Value = value;
        }
    }
    public bool ResSound
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResSound];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResSound];
            ValueItemProperty.Value = value;
        }
    }
    public bool Search
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Search];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Search];
            ValueItemProperty.Value = value;
        }
    }
    public bool SeeInvis
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SeeInvis];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SeeInvis];
            ValueItemProperty.Value = value;
        }
    }
    public bool ShElec
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ShElec];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ShElec];
            ValueItemProperty.Value = value;
        }
    }
    public bool ShFire
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ShFire];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ShFire];
            ValueItemProperty.Value = value;
        }
    }
    public bool ShowMods
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ShowMods];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ShowMods];
            ValueItemProperty.Value = value;
        }
    }
    public bool SlayAnimal
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayAnimal];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayAnimal];
            ValueItemProperty.Value = value;
        }
    }
    public bool SlayDemon
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayDemon];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayDemon];
            ValueItemProperty.Value = value;
        }
    }
    public bool SlayDragon
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayDragon];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayDragon];
            ValueItemProperty.Value = value;
        }
    }
    public bool SlayEvil
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayEvil];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayEvil];
            ValueItemProperty.Value = value;
        }
    }
    public bool SlayGiant
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayGiant];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayGiant];
            ValueItemProperty.Value = value;
        }
    }
    public bool SlayOrc
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayOrc];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayOrc];
            ValueItemProperty.Value = value;
        }
    }
    public bool SlayTroll
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayTroll];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayTroll];
            ValueItemProperty.Value = value;
        }
    }
    public bool SlayUndead
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayUndead];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayUndead];
            ValueItemProperty.Value = value;
        }
    }
    public bool SlowDigest
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlowDigest];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlowDigest];
            ValueItemProperty.Value = value;
        }
    }
    public bool Speed
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Speed];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Speed];
            ValueItemProperty.Value = value;
        }
    }
    public bool Stealth
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Stealth];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Stealth];
            ValueItemProperty.Value = value;
        }
    }
    public bool Str
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Str];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Str];
            ValueItemProperty.Value = value;
        }
    }
    public bool SustCha
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustCha];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustCha];
            ValueItemProperty.Value = value;
        }
    }
    public bool SustCon
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustCon];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustCon];
            ValueItemProperty.Value = value;
        }
    }
    public bool SustDex
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustDex];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustDex];
            ValueItemProperty.Value = value;
        }
    }
    public bool SustInt
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustInt];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustInt];
            ValueItemProperty.Value = value;
        }
    }
    public bool SustStr
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustStr];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustStr];
            ValueItemProperty.Value = value;
        }
    }
    public bool SustWis
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustWis];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustWis];
            ValueItemProperty.Value = value;
        }
    }
    public bool Telepathy
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Telepathy];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Telepathy];
            ValueItemProperty.Value = value;
        }
    }
    public bool Teleport
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Teleport];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Teleport];
            ValueItemProperty.Value = value;
        }
    }
    public int TreasureRating
    {
        get
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.TreasureRating];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.TreasureRating];
            ValueItemProperty.Value = value;
        }
    }
    public bool Tunnel
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Tunnel];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Tunnel];
            ValueItemProperty.Value = value;
        }
    }
    public int Value
    {
        get
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.Value];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<int> ValueItemProperty = (ValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.Value];
            ValueItemProperty.Value = value;
        }
    }
    public bool Valueless
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Valueless];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Valueless];
            ValueItemProperty.Value = value;
        }
    }
    public bool Vampiric
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Vampiric];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Vampiric];
            ValueItemProperty.Value = value;
        }
    }
    public bool Vorpal
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Vorpal];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Vorpal];
            ValueItemProperty.Value = value;
        }
    }
    public bool Wis
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Wis];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Wis];
            ValueItemProperty.Value = value;
        }
    }
    public bool Wraith
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Wraith];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Wraith];
            ValueItemProperty.Value = value;
        }
    }
    public bool XtraMight
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.XtraMight];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.XtraMight];
            ValueItemProperty.Value = value;
        }
    }
    public bool XtraShots
    {
        get
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.XtraShots];
            return ValueItemProperty.Value;
        }
        init
        {
            ValueItemProperty<bool> ValueItemProperty = (ValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.XtraShots];
            ValueItemProperty.Value = value;
        }
    }
    #endregion
}
