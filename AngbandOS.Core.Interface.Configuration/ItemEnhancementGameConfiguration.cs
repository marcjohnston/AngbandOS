// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Interface.Configuration;

/// <summary>
/// Represents a set of item characteristics that can be merged with another other IItemCharacterstics.  These objects are used by <see cref="RareItem"/> objects and the random 
/// artifact creation process.
/// </summary>
[Serializable]
public class ItemEnhancementGameConfiguration
{
    public virtual string? Key { get; set; } = null;

    public virtual string? DisarmTraps { get; set; } = null;
    public virtual string? UseDevice { get; set; } = null;

    public virtual string? SavingThrow { get; set; } = null;

    /// <summary>
    /// Returns true, if the item is susceptible to electricity.  Returns false, by default.
    /// </summary>
    public virtual string? HatesElectricity { get; set; } = null;

    /// <summary>
    /// Returns true, if the item is susceptible to fire.  Returns false, by default.
    /// </summary>
    public virtual string? HatesFire { get; set; } = null;

    /// <summary>
    /// Returns true, if the item is susceptible to acid.  Returns false, by default.
    /// </summary>
    public virtual string? HatesAcid { get; set; } = null;

    /// <summary>
    /// Returns true, if the item is susceptible to cold.  Returns false, by default.
    /// </summary>
    public virtual string? HatesCold { get; set; } = null;

    /// <summary>
    /// Returns the <see cref="ItemFactory"/> objects that this <see cref="ItemEnhancement"/> applies to; or null, if this <see cref="ItemEnhancement"/> can
    /// be applied to all <see cref="ItemFactory"/> objects.  This property is used to bind the <see cref="ApplicableItemFactories"/> property.
    /// </summary>
    public virtual string[]? ApplicableItemFactoryBindingKeys { get; set; } = null;

    public virtual string? AdditionalItemEnhancementWeightedRandomBindingKey { get; set; } = null;

    /// <summary>
    /// Returns the name of the rare item characteristics to append to the description of the original item, or null, to not modify the name.  Returns null, by default.
    /// </summary>
    public virtual string? FriendlyName { get; set; } = null;

    /// <summary>
    /// Returns true, if the item can apply a bonus armor class for miscellaneous power.  Only weapons return true.  Returns false, by default.
    /// </summary>
    public virtual bool? CanApplyBonusArmorClassMiscPower { get; set; } = null;

    /// <summary>
    /// Returns true, if an item of this factory can have be blessed for priestly biased artifacts.  Returns false, for all items except swords and polearms; which return false.
    /// </summary>
    public virtual bool? CanApplyBlessedArtifactBias { get; set; } = null;

    /// <summary>
    /// Returns true, if an item of this factory can have slaying bonus applied for biased artifacts.  Returns true, for all items except bows; which return false.
    /// </summary>
    public virtual bool? ArtifactBiasCanSlay { get; set; } = null;

    /// <summary>
    /// Returns true, if the item can apply a blows bonus.  Returns false, by default. Bows, return true.
    /// </summary>
    public virtual bool? CanApplyBlowsBonus { get; set; } = null;

    /// <summary>
    /// Returns true, if the item can reflect bolts and arrows.  Returns false, by default.  Shields, helms, cloaks and hard armor return true.
    /// </summary>
    public virtual bool? CanReflectBoltsAndArrows { get; set; } = null;

    /// <summary>
    /// Returns true, if the item is capable of having slaying bonuses applied.  Only weapons return true.  Returns false by default.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public virtual bool? CanApplySlayingBonus { get; set; } = null;

    public virtual string? Strength { get; set; } = null;
    public virtual string? Intelligence { get; set; } = null;
    public virtual string? Wisdom { get; set; } = null;
    public virtual string? Dexterity { get; set; } = null;
    public virtual string? Constitution { get; set; } = null;
    public virtual string? Charisma { get; set; } = null;
    public virtual string? Stealth { get; set; } = null;
    public virtual string? Search { get; set; } = null;
    public virtual string? Infravision { get; set; } = null;
    public virtual string? Tunnel { get; set; } = null;
    public virtual string? Attacks { get; set; } = null;
    public virtual string? Speed { get; set; } = null;
    public virtual string? BonusArmorClass { get; set; } = null;
    public virtual string? Hits { get; set; } = null;
    public virtual string? Damage { get; set; } = null;

    public virtual string? BaseArmorClass { get; set; } = null;

    /// <summary>
    /// Returns then name of an <see cref="Activation "/>, if the item can be activated; or null, if the item cannot be activated.  Dragon scale mail, rings of ice, acid and flames, the planar weapon, fixed artifacts and
    /// random artifacts may have an <see cref="Activation"/>.  Returns null, by default.  This property is used to bind the <see cref="Activation"/> property during the bind phase.
    /// </summary>
    /// <inheritdoc />
    public virtual string? ActivationName { get; set; }
    public virtual bool? Aggravate { get; set; } = null;
    public virtual bool? AntiTheft { get; set; } = null;
    public virtual string? ArtifactBiasWeightedRandomBindingKey { get; set; } = null;
    public virtual bool? Blessed { get; set; } = null;
    public virtual bool? Blows { get; set; } = null;
    public virtual bool? BrandAcid { get; set; } = null;
    public virtual bool? BrandCold { get; set; } = null;
    public virtual bool? BrandElec { get; set; } = null;
    public virtual bool? BrandFire { get; set; } = null;
    public virtual bool? BrandPois { get; set; } = null;
    public virtual bool? Chaotic { get; set; } = null;

    /// <summary>
    /// Returns the color that items of this type should be rendered with.  This color will be initially used to set the <see cref="FlavorColor"/> and item categories
    /// that have flavor may change the FlavorColor based on the flavor.
    /// </summary>
    public virtual ColorEnum? Color { get; set; } = null;

    public virtual bool? IsCursed { get; set; } = null;

    /// <summary>
    /// Returns the number of damage dice to apply to the item.
    /// </summary>
    public virtual int? DamageDice { get; set; } = null;

    /// <summary>
    /// Returns the number of dice sides to apply to the item.
    /// </summary>
    public virtual int? DiceSides { get; set; } = null;

    public virtual bool? DrainExp { get; set; } = null;
    public virtual bool? DreadCurse { get; set; } = null;
    public virtual bool? EasyKnow { get; set; } = null;
    public virtual bool? Feather { get; set; } = null;
    public virtual bool? FreeAct { get; set; } = null;
    public virtual bool? HeavyCurse { get; set; } = null;
    public virtual bool? HideType { get; set; } = null;
    public virtual bool? HoldLife { get; set; } = null;
    public virtual bool? IgnoreAcid { get; set; } = null;
    public virtual bool? IgnoreCold { get; set; } = null;
    public virtual bool? IgnoreElec { get; set; } = null;
    public virtual bool? IgnoreFire { get; set; } = null;
    public virtual bool? ImAcid { get; set; } = null;
    public virtual bool? ImCold { get; set; } = null;
    public virtual bool? ImElec { get; set; } = null;
    public virtual bool? ImFire { get; set; } = null;
    public virtual bool? Impact { get; set; } = null;
    public virtual bool? NoMagic { get; set; } = null;
    public virtual bool? NoTele { get; set; } = null;
    public virtual bool? PermaCurse { get; set; } = null;
    public virtual int? Radius { get; set; } = null;
    public virtual bool? Reflect { get; set; } = null;
    public virtual bool? Regen { get; set; } = null;
    public virtual bool? ResAcid { get; set; } = null;
    public virtual bool? ResBlind { get; set; } = null;
    public virtual bool? ResChaos { get; set; } = null;
    public virtual bool? ResCold { get; set; } = null;
    public virtual bool? ResConf { get; set; } = null;
    public virtual bool? ResDark { get; set; } = null;
    public virtual bool? ResDisen { get; set; } = null;
    public virtual bool? ResElec { get; set; } = null;
    public virtual bool? ResFear { get; set; } = null;
    public virtual bool? ResFire { get; set; } = null;
    public virtual bool? ResLight { get; set; } = null;
    public virtual bool? ResNether { get; set; } = null;
    public virtual bool? ResNexus { get; set; } = null;
    public virtual bool? ResPois { get; set; } = null;
    public virtual bool? ResShards { get; set; } = null;
    public virtual bool? ResSound { get; set; } = null;
    public virtual bool? SeeInvis { get; set; } = null;
    public virtual bool? ShElec { get; set; } = null;
    public virtual bool? ShFire { get; set; } = null;
    public virtual bool? ShowMods { get; set; } = null;
    public virtual bool? SlayAnimal { get; set; } = null;
    public virtual bool? SlayDemon { get; set; } = null;
    public virtual int? SlayDragon { get; set; } = null;
    public virtual bool? SlayEvil { get; set; } = null;
    public virtual bool? SlayGiant { get; set; } = null;
    public virtual bool? SlayOrc { get; set; } = null;
    public virtual bool? SlayTroll { get; set; } = null;
    public virtual bool? SlayUndead { get; set; } = null;
    public virtual bool? SlowDigest { get; set; } = null;
    public virtual bool? SustCha { get; set; } = null;
    public virtual bool? SustCon { get; set; } = null;
    public virtual bool? SustDex { get; set; } = null;
    public virtual bool? SustInt { get; set; } = null;
    public virtual bool? SustStr { get; set; } = null;
    public virtual bool? SustWis { get; set; } = null;
    public virtual bool? Telepathy { get; set; } = null;
    public virtual bool? Teleport { get; set; } = null;

    /// <summary>
    /// Returns an additional treasure rating to apply to the item.  This treasure rating will be added to the out-of-level delta that is automatically added.
    /// </summary>
    public virtual int? TreasureRating { get; set; } = null;

    /// <summary>
    /// Returns the additional value of the enhancement.  Returns 0, by default.
    /// </summary>
    public virtual int? Value { get; set; } = null;

    /// <summary>
    /// Returns true, if the enhancement causes the item to become valueless; false, if the item retains its value.  Returns false, by default.
    /// </summary>
    public virtual bool? Valueless { get; set; } = null;

    public virtual bool? Vampiric { get; set; } = null;
    public virtual int? Vorpal1InChance { get; set; } = null;
    public virtual int? VorpalExtraAttacks1InChance { get; set; } = null;
    public virtual int? Weight { get; set; } = null;
    public virtual bool? Wraith { get; set; } = null;   
    public virtual bool? XtraMight { get; set; } = null;
    public virtual bool? XtraShots { get; set; } = null;
}
