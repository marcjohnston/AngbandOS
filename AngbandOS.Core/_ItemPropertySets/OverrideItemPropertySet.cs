// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class OverrideItemPropertySet : ItemPropertySet
{
    public OverrideItemPropertySet()
    {
        // Create nullable item characteristics for every property.
        foreach (ItemPropertyFactory itemCharacteristicFactory in ItemPropertyFactories)
        {
            ItemProperties[itemCharacteristicFactory.Index] = itemCharacteristicFactory.InstantiateNullable();
        }
    }

    private OverrideItemPropertySet(ItemProperty[] itemCharacteristics) : base(itemCharacteristics) { }

    /// <summary>
    /// Returns a cloned set of item properties.
    /// </summary>
    /// <remarks>
    /// This override version of the clone is used to clone the <see cref="Item.OverrideItemCharacteristics"/> when cloning an <see cref="Item"/>.
    /// </remarks>
    /// <returns></returns>
    public OverrideItemPropertySet Clone()
    {
        ItemProperty[] clonedItemCharacteristics = CloneAllItemProperties();
        return new OverrideItemPropertySet(clonedItemCharacteristics);
    }

    /// <summary>
    /// Returns a read-only effective item property set by applying an override process from the nullable values in this property set with an incoming read-only item property set.
    /// </summary>
    /// <param name="roItemPropertySet"></param>
    /// <returns></returns>
    public RoItemPropertySet Override(RoItemPropertySet roItemPropertySet)
    {
        ItemProperty[] overriddenItemProperties = OverrideAllItemProperties(roItemPropertySet);
        return new RoItemPropertySet(overriddenItemProperties);
    }

    #region Properties
    //public bool? CanApplyBlessedArtifactBias
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> rwValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanApplyBlessedArtifactBias];
    //        return rwValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> rwValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanApplyBlessedArtifactBias];
    //        rwValueItemProperty.Value = value;
    //    }
    //}
    //public bool? CanApplyArtifactBiasSlaying
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> rwValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanApplyArtifactBiasSlaying];
    //        return rwValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> rwValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanApplyArtifactBiasSlaying];
    //        rwValueItemProperty.Value = value;
    //    }
    //}
    //public bool? CanApplyBlowsBonus
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> rwValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanApplyBlowsBonus];
    //        return rwValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> rwValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanApplyBlowsBonus];
    //        rwValueItemProperty.Value = value;
    //    }
    //}
    //public bool? CanReflectBoltsAndArrows
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> rwValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanReflectBoltsAndArrows];
    //        return rwValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> rwValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanReflectBoltsAndArrows];
    //        rwValueItemProperty.Value = value;
    //    }
    //}
    //public bool? CanApplySlayingBonus
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> rwValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanApplySlayingBonus];
    //        return rwValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> rwValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanApplySlayingBonus];
    //        rwValueItemProperty.Value = value;
    //    }
    //}
    //public bool? CanApplyBonusArmorClassMiscPower
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> rwValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanApplyBonusArmorClassMiscPower];
    //        return rwValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> rwValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanApplyBonusArmorClassMiscPower];
    //        rwValueItemProperty.Value = value;
    //    }
    //}
    //public bool? CanProvideSheathOfElectricity
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> rwValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanProvideSheathOfElectricity];
    //        return rwValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> rwValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanProvideSheathOfElectricity];
    //        rwValueItemProperty.Value = value;
    //    }
    //}
    //public bool? CanProvideSheathOfFire
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> rwValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanProvideSheathOfFire];
    //        return rwValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> rwValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.CanProvideSheathOfFire];
    //        rwValueItemProperty.Value = value;
    //    }
    //}
    //public int? BonusHit
    //{
    //    get
    //    {
    //        NullableValueItemProperty<int> rwValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusHit];
    //        return rwValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<int> rwValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusHit];
    //        rwValueItemProperty.Value = value;
    //    }
    //}
    //public int? BonusArmorClass
    //{
    //    get
    //    {
    //        NullableValueItemProperty<int> rwValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusArmorClass];
    //        return rwValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<int> rwValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusArmorClass];
    //        rwValueItemProperty.Value = value;
    //    }
    //}
    //public int? BonusDamage
    //{
    //    get
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusDamage];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusDamage];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public int? BonusStrength
    //{
    //    get
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusStrength];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusStrength];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public int? BonusIntelligence
    //{
    //    get
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusIntelligence];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusIntelligence];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public int? BonusWisdom
    //{
    //    get
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusWisdom];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusWisdom];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public int? BonusDexterity
    //{
    //    get
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusDexterity];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusDexterity];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public int? BonusConstitution
    //{
    //    get
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusConstitution];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusConstitution];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public int? BonusCharisma
    //{
    //    get
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusCharisma];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusCharisma];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public int? BonusStealth
    //{
    //    get
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusStealth];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusStealth];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public int? BonusSearch
    //{
    //    get
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusSearch];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusSearch];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public int? BonusInfravision
    //{
    //    get
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusInfravision];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusInfravision];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public int? BonusTunnel
    //{
    //    get
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusTunnel];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusTunnel];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public int? BonusAttacks
    //{
    //    get
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusAttacks];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusAttacks];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public int? BonusSpeed
    //{
    //    get
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusSpeed];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.BonusSpeed];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public Activation? Activation
    //{
    //    get
    //    {
    //        NullableReferenceItemProperty<Activation> nullableReferenceItemProperty = (NullableReferenceItemProperty<Activation>)ItemProperties[(int)ItemPropertiesEnum.Activation];
    //        return nullableReferenceItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableReferenceItemProperty<Activation> nullableReferenceItemProperty = (NullableReferenceItemProperty<Activation>)ItemProperties[(int)ItemPropertiesEnum.Activation];
    //        nullableReferenceItemProperty.Value = value;
    //    }
    //}
    //public bool? Aggravate
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Aggravate];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Aggravate];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? AntiTheft
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.AntiTheft];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.AntiTheft];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public ArtifactBias? ArtifactBias
    //{
    //    get
    //    {
    //        NullableReferenceItemProperty<ArtifactBias> nullableReferenceItemProperty = (NullableReferenceItemProperty<ArtifactBias>)ItemProperties[(int)ItemPropertiesEnum.ArtifactBias];
    //        return nullableReferenceItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableReferenceItemProperty<ArtifactBias> nullableReferenceItemProperty = (NullableReferenceItemProperty<ArtifactBias>)ItemProperties[(int)ItemPropertiesEnum.ArtifactBias];
    //        nullableReferenceItemProperty.Value = value;
    //    }
    //}
    //public bool? Blessed
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Blessed];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Blessed];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? Blows
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Blows];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Blows];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? BrandAcid
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.BrandAcid];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.BrandAcid];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? BrandCold
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.BrandCold];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.BrandCold];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? BrandElec
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.BrandElec];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.BrandElec];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? BrandFire
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.BrandFire];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.BrandFire];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? BrandPois
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.BrandPois];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.BrandPois];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? Cha
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Cha];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Cha];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? Chaotic
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Chaotic];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Chaotic];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? Con
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Con];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Con];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    public bool? IsCursed
    {
        get
        {
            NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IsCursed];
            return RwNullableValueItemProperty.Value;
        }
        set
        {
            NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IsCursed];
            RwNullableValueItemProperty.Value = value;
        }
    }
    //public bool? Dex
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Dex];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Dex];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? DrainExp
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.DrainExp];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.DrainExp];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? DreadCurse
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.DreadCurse];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.DreadCurse];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? EasyKnow
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.EasyKnow];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.EasyKnow];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? Feather
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Feather];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Feather];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? FreeAct
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.FreeAct];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.FreeAct];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    public bool? HeavyCurse
    {
        get
        {
            NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.HeavyCurse];
            return RwNullableValueItemProperty.Value;
        }
        set
        {
            NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.HeavyCurse];
            RwNullableValueItemProperty.Value = value;
        }
    }
    //public bool? HideType
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.HideType];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.HideType];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? HoldLife
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.HoldLife];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.HoldLife];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? IgnoreAcid
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IgnoreAcid];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IgnoreAcid];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? IgnoreCold
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IgnoreCold];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IgnoreCold];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? IgnoreElec
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IgnoreElec];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IgnoreElec];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? IgnoreFire
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IgnoreFire];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IgnoreFire];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? ImAcid
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ImAcid];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ImAcid];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? ImCold
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ImCold];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ImCold];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? ImElec
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ImElec];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ImElec];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? ImFire
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ImFire];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ImFire];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? Impact
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Impact];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Impact];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? Infra
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Infra];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Infra];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? InstaArt
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.InstaArt];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.InstaArt];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? Int
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Int];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Int];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? KillDragon
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.KillDragon];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.KillDragon];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? NoMagic
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.NoMagic];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.NoMagic];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? NoTele
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.NoTele];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.NoTele];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? PermaCurse
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.PermaCurse];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.PermaCurse];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public int? Radius
    //{
    //    get
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.Radius];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.Radius];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? Reflect
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Reflect];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Reflect];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? Regen
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Regen];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Regen];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? ResAcid
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResAcid];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResAcid];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? ResBlind
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResBlind];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResBlind];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? ResChaos
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResChaos];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResChaos];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? ResCold
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResCold];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResCold];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? ResConf
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResConf];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResConf];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? ResDark
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResDark];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResDark];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? ResDisen
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResDisen];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResDisen];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? ResElec
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResElec];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResElec];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? ResFear
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResFear];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResFear];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? ResFire
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResFire];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResFire];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? ResLight
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResLight];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResLight];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? ResNether
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResNether];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResNether];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? ResNexus
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResNexus];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResNexus];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? ResPois
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResPois];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResPois];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? ResShards
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResShards];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResShards];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? ResSound
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResSound];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ResSound];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? Search
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Search];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Search];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? SeeInvis
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SeeInvis];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SeeInvis];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? ShElec
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ShElec];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ShElec];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? ShFire
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ShFire];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ShFire];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? ShowMods
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ShowMods];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.ShowMods];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? SlayAnimal
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayAnimal];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayAnimal];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? SlayDemon
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayDemon];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayDemon];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? SlayDragon
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayDragon];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayDragon];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? SlayEvil
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayEvil];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayEvil];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? SlayGiant
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayGiant];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayGiant];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? SlayOrc
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayOrc];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayOrc];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? SlayTroll
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayTroll];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayTroll];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? SlayUndead
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayUndead];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlayUndead];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? SlowDigest
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlowDigest];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SlowDigest];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? Speed
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Speed];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Speed];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? Stealth
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Stealth];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Stealth];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? Str
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Str];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Str];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? SustCha
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustCha];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustCha];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? SustCon
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustCon];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustCon];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? SustDex
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustDex];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustDex];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? SustInt
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustInt];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustInt];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? SustStr
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustStr];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustStr];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? SustWis
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustWis];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.SustWis];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? Telepathy
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Telepathy];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Telepathy];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? Teleport
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Teleport];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Teleport];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public int? TreasureRating
    //{
    //    get
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.TreasureRating];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.TreasureRating];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? Tunnel
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Tunnel];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Tunnel];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? Vampiric
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Vampiric];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Vampiric];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? Vorpal
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Vorpal];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Vorpal];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? Wis
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Wis];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Wis];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? Wraith
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Wraith];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.Wraith];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? XtraMight
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.XtraMight];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.XtraMight];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    //public bool? XtraShots
    //{
    //    get
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.XtraShots];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.XtraShots];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}
    #endregion
}
