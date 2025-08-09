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

    /// <summary>
    /// Returns the additional value of the enhancement.  Returns 0, by default.
    /// </summary>
    public virtual int Value { get; set; } = 0;

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
    public virtual bool CanApplyBonusArmorClassMiscPower { get; set; } = false;

    /// <summary>
    /// Returns true, if an item of this factory can have be blessed for priestly biased artifacts.  Returns false, for all items except swords and polearms; which return false.
    /// </summary>
    public virtual bool CanApplyBlessedArtifactBias { get; set; } = false;

    /// <summary>
    /// Returns true, if an item of this factory can have slaying bonus applied for biased artifacts.  Returns true, for all items except bows; which return false.
    /// </summary>
    public virtual bool CanApplyArtifactBiasSlaying { get; set; } = true;

    /// <summary>
    /// Returns true, if the item can apply a blows bonus.  Returns false, by default. Bows, return true.
    /// </summary>
    public virtual bool CanApplyBlowsBonus { get; set; } = false;

    /// <summary>
    /// Returns true, if the item can reflect bolts and arrows.  Returns false, by default.  Shields, helms, cloaks and hard armor return true.
    /// </summary>
    public virtual bool CanReflectBoltsAndArrows { get; set; } = false;

    /// <summary>
    /// Returns true, if the item is capable of having slaying bonuses applied.  Only weapons return true.  Returns false by default.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public virtual bool CanApplySlayingBonus { get; set; } = false;

    public virtual string? BonusStrengthRollExpression { get; set; } = null;
    public virtual string? BonusIntelligenceRollExpression { get; set; } = null;
    public virtual string? BonusWisdomRollExpression { get; set; } = null;
    public virtual string? BonusDexterityRollExpression { get; set; } = null;
    public virtual string? BonusConstitutionRollExpression { get; set; } = null;
    public virtual string? BonusCharismaRollExpression { get; set; } = null;
    public virtual string? BonusStealthRollExpression { get; set; } = null;
    public virtual string? BonusSearchRollExpression { get; set; } = null;
    public virtual string? BonusInfravisionRollExpression { get; set; } = null;
    public virtual string? BonusTunnelRollExpression { get; set; } = null;
    public virtual string? BonusAttacksRollExpression { get; set; } = null;
    public virtual string? BonusSpeedRollExpression { get; set; } = null;
    public virtual string? BonusArmorClassRollExpression { get; set; } = null;
    public virtual string? BonusHitRollExpression { get; set; } = null;
    public virtual string? BonusDamageRollExpression { get; set; } = null;

    /// <summary>
    /// Returns then name of an <see cref="Activation "/>, if the item can be activated; or null, if the item cannot be activated.  Dragon scale mail, rings of ice, acid and flames, the planar weapon, fixed artifacts and
    /// random artifacts may have an <see cref="Activation"/>.  Returns null, by default.  This property is used to bind the <see cref="Activation"/> property during the bind phase.
    /// </summary>
    /// <inheritdoc />
    public virtual string? ActivationName { get; set; }
    public virtual bool Aggravate { get; set; } = false;
    public virtual bool AntiTheft { get; set; } = false;
    public virtual string? ArtifactBiasWeightedRandomBindingKey { get; set; } = null;
    public virtual bool Blessed { get; set; } = false;
    public virtual bool Blows { get; set; } = false;
    public virtual bool BrandAcid { get; set; } = false;
    public virtual bool BrandCold { get; set; } = false;
    public virtual bool BrandElec { get; set; } = false;
    public virtual bool BrandFire { get; set; } = false;
    public virtual bool BrandPois { get; set; } = false;
    public virtual bool Chaotic { get; set; } = false;
    public virtual int Cost { get; set; } = 0;
    public virtual bool IsCursed { get; set; } = false;
    public virtual int DamageDice { get; set; } = 0;
    public virtual bool DrainExp { get; set; } = false;
    public virtual bool DreadCurse { get; set; } = false;
    public virtual bool EasyKnow { get; set; } = false;
    public virtual bool Feather { get; set; } = false;
    public virtual bool FreeAct { get; set; } = false;
    public virtual bool HeavyCurse { get; set; } = false;
    public virtual bool HideType { get; set; } = false;
    public virtual bool HoldLife { get; set; } = false;
    public virtual bool IgnoreAcid { get; set; } = false;
    public virtual bool IgnoreCold { get; set; } = false;
    public virtual bool IgnoreElec { get; set; } = false;
    public virtual bool IgnoreFire { get; set; } = false;
    public virtual bool ImAcid { get; set; } = false;
    public virtual bool ImCold { get; set; } = false;
    public virtual bool ImElec { get; set; } = false;
    public virtual bool ImFire { get; set; } = false;
    public virtual bool Impact { get; set; } = false;
    public virtual bool NoMagic { get; set; } = false;
    public virtual bool NoTele { get; set; } = false;
    public virtual bool PermaCurse { get; set; } = false;
    public virtual int Radius { get; set; } = 0;
    public virtual bool Reflect { get; set; } = false;
    public virtual bool Regen { get; set; } = false;
    public virtual bool ResAcid { get; set; } = false;
    public virtual bool ResBlind { get; set; } = false;
    public virtual bool ResChaos { get; set; } = false;
    public virtual bool ResCold { get; set; } = false;
    public virtual bool ResConf { get; set; } = false;
    public virtual bool ResDark { get; set; } = false;
    public virtual bool ResDisen { get; set; } = false;
    public virtual bool ResElec { get; set; } = false;
    public virtual bool ResFear { get; set; } = false;
    public virtual bool ResFire { get; set; } = false;
    public virtual bool ResLight { get; set; } = false;
    public virtual bool ResNether { get; set; } = false;
    public virtual bool ResNexus { get; set; } = false;
    public virtual bool ResPois { get; set; } = false;
    public virtual bool ResShards { get; set; } = false;
    public virtual bool ResSound { get; set; } = false;
    public virtual bool SeeInvis { get; set; } = false;
    public virtual bool ShElec { get; set; } = false;
    public virtual bool ShFire { get; set; } = false;
    public virtual bool ShowMods { get; set; } = false;
    public virtual bool SlayAnimal { get; set; } = false;
    public virtual bool SlayDemon { get; set; } = false;
    public virtual int SlayDragon { get; set; } = 3;
    public virtual bool SlayEvil { get; set; } = false;
    public virtual bool SlayGiant { get; set; } = false;
    public virtual bool SlayOrc { get; set; } = false;
    public virtual bool SlayTroll { get; set; } = false;
    public virtual bool SlayUndead { get; set; } = false;
    public virtual bool SlowDigest { get; set; } = false;
    public virtual bool SustCha { get; set; } = false;
    public virtual bool SustCon { get; set; } = false;
    public virtual bool SustDex { get; set; } = false;
    public virtual bool SustInt { get; set; } = false;
    public virtual bool SustStr { get; set; } = false;
    public virtual bool SustWis { get; set; } = false;
    public virtual bool Telepathy { get; set; } = false;
    public virtual bool Teleport { get; set; } = false;
    public virtual int TreasureRating { get; set; } = 0;

    /// <summary>
    /// Returns true, if the enhancement causes the item to become valueless; false, if the item retains its value.  Returns false, by default.
    /// </summary>
    public virtual bool Valueless { get; set; } = false;

    public virtual bool Vampiric { get; set; } = false;
    public virtual bool Vorpal { get; set; } = false;
    public virtual int Weight { get; set; } = 0;
    public virtual bool Wraith { get; set; } = false;   
    public virtual bool XtraMight { get; set; } = false;
    public virtual bool XtraShots { get; set; } = false;
}
