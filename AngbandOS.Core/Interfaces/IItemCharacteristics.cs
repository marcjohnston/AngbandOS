// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Interfaces;

/// <summary>
/// Represents the interface an object needs to implement to be considered having all 90+ ItemCharacteristics.  This interface allows existing objects to denote
/// that they implement the same ItemCharacteristics.
/// </summary>
/// <remarks>
/// </remarks>
internal interface IItemCharacteristics
{
    bool CanApplyBlessedArtifactBias { get; }
    bool CanApplyArtifactBiasSlaying { get; }
    bool CanApplyBlowsBonus { get; }
    bool CanReflectBoltsAndArrows { get; }
    bool CanApplySlayingBonus { get; }
    bool CanApplyBonusArmorClassMiscPower { get; }
    bool CanProvideSheathOfElectricity { get; }
    bool CanProvideSheathOfFire { get; }

    int BonusHit { get; }
    int BonusArmorClass { get; }
    int BonusDamage { get; }
    int BonusStrength { get; }
    int BonusIntelligence { get; }
    int BonusWisdom { get; }
    int BonusDexterity { get; }
    int BonusConstitution { get; }
    int BonusCharisma { get; }
    int BonusStealth { get; }
    int BonusSearch { get; }
    int BonusInfravision { get; }
    int BonusTunnel { get; }
    int BonusAttacks { get; }
    int BonusSpeed { get; }

    /// <summary>
    /// Returns whether or not the item affects the search capabilities of the player when being worn.
    /// </summary>
    bool Search { get; }

    /// <summary>
    /// Returns whether or not the item affects the tunneling capabilities of the player when being worn.
    /// </summary>
    bool Tunnel { get; }

    /// <summary>
    /// Returns whether or not the item affects the wisdom of the player when being worn.
    /// </summary>
    bool Wis { get; }

    /// <summary>
    /// Returns whether or not the item affects the attack speed of the player when being worn.
    /// </summary>
    bool Speed { get; }

    /// <summary>
    /// Returns whether or not the item affects the stealth of the player when being worn.
    /// </summary>
    bool Stealth { get; }

    /// <summary>
    /// Returns whether or not the item affects the intelligence of the player when being worn.
    /// </summary>
    bool Int { get; }

    /// <summary>
    /// Returns whether or not the item affects the infravision of the player when being worn.
    /// </summary>
    bool Infra { get; }

    /// <summary>
    /// Returns whether or not the item affects the constitution of the player when being worn.
    /// </summary>
    bool Con { get; }

    /// <summary>
    /// Returns whether or not the item affects the dexterity of the player when being worn.
    /// </summary>
    bool Dex { get; }

    /// <summary>
    /// Returns whether or not the item affects the charisma of the player when being worn.
    /// </summary>
    bool Cha { get; }

    /// <summary>
    /// Returns whether or not the item affects the strength of the player when being worn.
    /// </summary>
    bool Str { get; }

    /// <summary>
    /// Returns whether or not the item affects the blows delivered by the player when being worn.
    /// </summary>
    bool Blows { get; }

    /// <summary>
    /// Returns the <see cref="Activation"/>, if the item can be activated; or null, if the item cannot be activated.  This property is bound using the <see cref="ActivationName"/> property during
    /// the bind phase.
    /// </summary>
    Activation? Activation { get; }

    bool Aggravate { get; }
    bool AntiTheft { get; }
    ArtifactBias? ArtifactBias { get; }
    bool Blessed { get; }

    /// <summary>
    /// Returns whether or not the item does extra damage from acid when being wielded.
    /// </summary>
    bool BrandAcid { get; }

    /// <summary>
    /// Returns whether or not the item does extra damage from frost when being wielded.
    /// </summary>
    bool BrandCold { get; }

    /// <summary>
    /// Returns whether or not the item does extra damage from electricity when being wielded.
    /// </summary>
    bool BrandElec { get; }

    /// <summary>
    /// Returns whether or not the item does extra damage from fire when being wielded.
    /// </summary>
    bool BrandFire { get; }

    /// <summary>
    /// Returns whether or not the item poisons foes when being wielded.
    /// </summary>
    bool BrandPois { get; }

    /// <summary>
    /// Returns whether or not the item produced chaotic effects when being wielded.
    /// </summary>
    bool Chaotic { get; }

    bool IsCursed { get; }

    bool DrainExp { get; }
    bool DreadCurse { get; }
    bool EasyKnow { get; }
    bool Feather { get; }
    bool FreeAct { get; }
    bool HeavyCurse { get; }

    /// <summary>
    /// Returns true, if the name of the bonus value should be omitted in the verbose description; false, otherwise.  Currently, only speed, extra-blows, stealth, searching and infravision are supported.
    /// </summary>
    bool HideType { get; }

    bool HoldLife { get; }
    bool IgnoreAcid { get; }
    bool IgnoreCold { get; }
    bool IgnoreElec { get; }
    bool IgnoreFire { get; }
    bool ImAcid { get; }
    bool ImCold { get; }
    bool ImElec { get; }
    bool ImFire { get; }

    /// <summary>
    /// Returns whether or not the item causes earthquakes of the player when being worn.
    /// </summary>
    bool Impact { get; }

    bool InstaArt { get; }

    /// <summary>
    /// Returns whether or not the item is a great bane of dragons.
    /// </summary>
    bool KillDragon { get; }

    bool NoMagic { get; }
    bool NoTele { get; }
    bool PermaCurse { get; }

    /// <summary>
    /// Returns the radius of light that the additive bundle adds to the item light source; or 0, if the additive bundle doesn't modify the item light source capabilities.  Returns 0, by default.
    /// </summary>
    int Radius { get; }

    bool Reflect { get; }
    bool Regen { get; }
    bool ResAcid { get; }
    bool ResBlind { get; }
    bool ResChaos { get; }
    bool ResCold { get; }
    bool ResConf { get; }
    bool ResDark { get; }
    bool ResDisen { get; }
    bool ResElec { get; }
    bool ResFear { get; }
    bool ResFire { get; }
    bool ResLight { get; }
    bool ResNether { get; }
    bool ResNexus { get; }
    bool ResPois { get; }
    bool ResShards { get; }
    bool ResSound { get; }

    bool SeeInvis { get; }

    /// <summary>
    /// Returns true, if the item produces a sheath of electricity around the item; false, otherwise.
    /// </summary>
    bool ShElec { get; }

    /// <summary>
    /// Returns true, if the item produces a sheath of fire around the item; false, otherwise.
    /// </summary>
    bool ShFire { get; }

    bool ShowMods { get; }
    bool SlayAnimal { get; }
    bool SlayDemon { get; }
    bool SlayDragon { get; }
    bool SlayEvil { get; }
    bool SlayGiant { get; }
    bool SlayOrc { get; }
    bool SlayTroll { get; }
    bool SlayUndead { get; }
    bool SlowDigest { get; }

    bool SustCha { get; }
    bool SustCon { get; }
    bool SustDex { get; }
    bool SustInt { get; }
    bool SustStr { get; }
    bool SustWis { get; }
    bool Telepathy { get; }
    bool Teleport { get; }

    /// <summary>
    /// Returns a value to add to the treasure rating.  Returns 0, by default.
    /// </summary>
    int TreasureRating { get; }


    bool Vampiric { get; }

    /// <summary>
    /// Returns whether or not the item is very sharp and cuts foes of the player when being used.
    /// </summary>
    bool Vorpal { get; }

    bool Wraith { get; }
    bool XtraMight { get; }
    bool XtraShots { get; }
}