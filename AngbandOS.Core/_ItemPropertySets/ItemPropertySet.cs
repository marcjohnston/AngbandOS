// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

/// <summary>
/// Represents a set of item characteristics with a specific set of access modifiers and nullability.
/// </summary>
/// <remarks>
/// This item properties subsystem was developed to handle two major issues: volume of code and correctness validation.
/// 
/// -Volume-
/// A game <see cref="Item"/> has over a hundred properties.  Items also need to perform various operations on these properties.
/// 1. The properties are often modified with an <see cref="ItemEnhancement"/>.  The effective property value is computed from several layers of enhancements using "merge" functionality.
/// 2. Items often need to be "cloned".
/// 3. The equality of two items need to be checked via an "equals" process.
/// Implementing these various methods on hundreds of properties manually requires many lines of code; bloating the project.  It also becomes difficult to ensure every property was handled in each
/// of the processing methods.  The addition or deleting of a property becomes even more difficult to ensure it is accounted for in every processing method.
/// 
/// -Correctness Validation-
/// The item merge process to compute the effective values for item properties needed compile-time checks to ensure property values are maintained and written properly.  To do this, it was 
/// determined that immutable item property structures would be the best choice.  The effective values of an item consists of the merging of:
/// 1. The item factory which is generated from an <see cref="ItemEnhancement"/>,
/// 2. A fixed artifact, rare item or random artifact, which are also generated from one or more <see cref="ItemEnhancement"/>, and
/// 3. Additional player enhancements.
/// 4. Finally, the Cursed, Heavy Curse and Broken properties ultimately override the effective value.  This type of functionality requires a nullable value to implement the "optional" override.
/// 
/// To ensure the results from generating a set of characteristics from an <see cref="ItemEnhancement"/> weren't accidentally modified, it was deemed that they should be immutable.
/// 
/// There are 3 variations in use:
/// 1. read-only (Ro): this variation represents a set of non-nullable item properties with init setters as the access modifier,
/// 2. read-write (Rw): this variation represents a set of non-nullable item properties with set as the access modifier so that the properties are read-write,
/// 3. override: this variation represnets a set of nullable item properties with set as the access modifier so that the properties are read-write.
/// 
/// Properties are managed via an <see cref="ItemPropertiesEnum"/>. 
/// 
/// </remarks>
[Serializable]
internal abstract class ItemPropertySet
{
    private void RegisterValueItemCharacteristic<T>(ItemPropertiesEnum index) where T : struct
    {
        ItemPropertyFactories.Add(new ValueItemPropertyFactory<T>((int)index));
    }

    private void RegisterReferenceItemCharacteristic<T>(ItemPropertiesEnum index) where T : class
    {
        ItemPropertyFactories.Add(new ReferenceItemPropertyFactory<T>((int)index));
    }

    protected readonly List<ItemPropertyFactory> ItemPropertyFactories = new List<ItemPropertyFactory>();
    protected readonly ItemProperty[] ItemProperties;

    protected ItemPropertySet()
    {
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.CanApplyBlessedArtifactBias);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.CanApplyArtifactBiasSlaying);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.CanApplyBlowsBonus);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.CanReflectBoltsAndArrows);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.CanApplySlayingBonus);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.CanApplyBonusArmorClassMiscPower);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.CanProvideSheathOfElectricity);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.CanProvideSheathOfFire);
        RegisterValueItemCharacteristic<int>(ItemPropertiesEnum.BonusHit);
        RegisterValueItemCharacteristic<int>(ItemPropertiesEnum.BonusArmorClass);
        RegisterValueItemCharacteristic<int>(ItemPropertiesEnum.BonusDamage);
        RegisterValueItemCharacteristic<int>(ItemPropertiesEnum.BonusStrength);
        RegisterValueItemCharacteristic<int>(ItemPropertiesEnum.BonusIntelligence);
        RegisterValueItemCharacteristic<int>(ItemPropertiesEnum.BonusWisdom);
        RegisterValueItemCharacteristic<int>(ItemPropertiesEnum.BonusDexterity);
        RegisterValueItemCharacteristic<int>(ItemPropertiesEnum.BonusConstitution);
        RegisterValueItemCharacteristic<int>(ItemPropertiesEnum.BonusCharisma);
        RegisterValueItemCharacteristic<int>(ItemPropertiesEnum.BonusStealth);
        RegisterValueItemCharacteristic<int>(ItemPropertiesEnum.BonusSearch);
        RegisterValueItemCharacteristic<int>(ItemPropertiesEnum.BonusInfravision);
        RegisterValueItemCharacteristic<int>(ItemPropertiesEnum.BonusTunnel);
        RegisterValueItemCharacteristic<int>(ItemPropertiesEnum.BonusAttacks);
        RegisterValueItemCharacteristic<int>(ItemPropertiesEnum.BonusSpeed);
        RegisterReferenceItemCharacteristic<Activation>(ItemPropertiesEnum.Activation);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.Aggravate);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.AntiTheft);
        RegisterReferenceItemCharacteristic<ArtifactBias>(ItemPropertiesEnum.ArtifactBias);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.Blessed);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.Blows);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.BrandAcid);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.BrandCold);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.BrandElec);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.BrandFire);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.BrandPois);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.Cha);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.Chaotic);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.Con);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.IsCursed);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.Dex);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.DrainExp);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.DreadCurse);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.EasyKnow);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.Feather);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.FreeAct);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.HeavyCurse);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.HideType);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.HoldLife);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.IgnoreAcid);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.IgnoreCold);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.IgnoreElec);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.IgnoreFire);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.ImAcid);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.ImCold);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.ImElec);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.ImFire);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.Impact);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.Infra);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.InstaArt);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.Int);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.KillDragon);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.NoMagic);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.NoTele);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.PermaCurse);
        RegisterValueItemCharacteristic<int>(ItemPropertiesEnum.Radius);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.Reflect);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.Regen);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.ResAcid);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.ResBlind);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.ResChaos);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.ResCold);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.ResConf);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.ResDark);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.ResDisen);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.ResElec);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.ResFear);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.ResFire);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.ResLight);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.ResNether);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.ResNexus);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.ResPois);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.ResShards);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.ResSound);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.Search);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.SeeInvis);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.ShElec);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.ShFire);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.ShowMods);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.SlayAnimal);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.SlayDemon);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.SlayDragon);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.SlayEvil);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.SlayGiant);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.SlayOrc);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.SlayTroll);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.SlayUndead);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.SlowDigest);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.Speed);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.Stealth);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.Str);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.SustCha);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.SustCon);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.SustDex);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.SustInt);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.SustStr);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.SustWis);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.Telepathy);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.Teleport);
        RegisterValueItemCharacteristic<int>(ItemPropertiesEnum.TreasureRating);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.Tunnel);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.Vampiric);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.Vorpal);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.Wis);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.Wraith);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.XtraMight);
        RegisterValueItemCharacteristic<bool>(ItemPropertiesEnum.XtraShots);

        ItemProperties = new ItemProperty[(int)ItemPropertiesEnum.LENGTH];
    }

    protected ItemPropertySet(ItemProperty[] itemCharacteristics) : this()
    {
        ItemProperties = itemCharacteristics;
    }

    protected ItemProperty[] CloneAllItemProperties()
    {
        return ItemProperties.Select(itemCharacteristic => itemCharacteristic.Clone()).ToArray();
    }

    protected ItemProperty[] OverrideAllItemProperties(ItemPropertySet itemPropertySet)
    {
        return ItemProperties.Select(_itemProperty => _itemProperty.Override(itemPropertySet.ItemProperties[_itemProperty.Index])).ToArray();
    }

    protected ItemProperty[] MergeAllItemProperties(ItemPropertySet? itemPropertySet)
    {
        if (itemPropertySet is null)
        {
            return ItemProperties;
        }
        else
        {
            return ItemProperties.Select(_itemProperty => _itemProperty.Merge(itemPropertySet.ItemProperties[_itemProperty.Index])).ToArray();
        }
    }

    #region Equality
    public override bool Equals(object? obj)
    {
        if (obj is not ItemPropertySet other)
        {
            return false;
        }

        return ItemProperties.All(_itemProperty => _itemProperty.Equals(other.ItemProperties[_itemProperty.Index]));
    }

    public static bool operator ==(ItemPropertySet? left, ItemPropertySet? right)
    {
        if (ReferenceEquals(left, right))
        {
            return true;
        }
        if (left is null || right is null)
        {
            return false;
        }

        return left.Equals(right);
    }

    public static bool operator !=(ItemPropertySet? left, ItemPropertySet? right)
    {
        return !(left == right);
    }
    #endregion
}
