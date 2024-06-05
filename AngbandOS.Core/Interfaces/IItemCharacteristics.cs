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
    /// <summary>
    /// Returns true, if items of this factory can be activated.  Returns true for all dragon scale mail and rings of ice, acid and flames.  Returns false, by default.  Items produced
    /// by this factory will implement the IItemActivatible interface.
    /// </summary>
    bool Activate { get; }
    bool Aggravate { get; }
    bool AntiTheft { get; }
    ArtifactBias? ArtifactBias { get; }
    bool Blessed { get; }

    /// <summary>
    /// Returns whether or not the item affects the blows delivered by the player when being worn.
    /// </summary>
    bool Blows { get; }

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
    /// Returns whether or not the item affects the charisma of the player when being worn.
    /// </summary>
    bool Cha { get; }

    /// <summary>
    /// Returns whether or not the item produced chaotic effects when being wielded.
    /// </summary>
    bool Chaotic { get; }

    /// <summary>
    /// Returns whether or not the item affects the constitution of the player when being worn.
    /// </summary>
    bool Con { get; }

    bool Cursed { get; }

    /// <summary>
    /// Returns whether or not the item affects the dexterity of the player when being worn.
    /// </summary>
    bool Dex { get; }

    bool DrainExp { get; }
    bool DreadCurse { get; }
    bool EasyKnow { get; }
    bool Feather { get; }
    bool FreeAct { get; }
    bool HeavyCurse { get; }
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

    /// <summary>
    /// Returns whether or not the item affects the infravision of the player when being worn.
    /// </summary>
    bool Infra { get; }

    bool InstaArt { get; }

    /// <summary>
    /// Returns whether or not the item affects the intelligence of the player when being worn.
    /// </summary>
    bool Int { get; }

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

    /// <summary>
    /// Returns whether or not the item affects the search capabilities of the player when being worn.
    /// </summary>
    bool Search { get; }

    bool SeeInvis { get; }
    bool ShElec { get; }
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

    /// <summary>
    /// Returns whether or not the item affects the attack speed of the player when being worn.
    /// </summary>
    bool Speed { get; }

    /// <summary>
    /// Returns whether or not the item affects the stealth of the player when being worn.
    /// </summary>
    bool Stealth { get; }

    /// <summary>
    /// Returns whether or not the item affects the strength of the player when being worn.
    /// </summary>
    bool Str { get; }

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


    /// <summary>
    /// Returns whether or not the item affects the tunneling capabilities of the player when being worn.
    /// </summary>
    bool Tunnel { get; }
    
    bool Vampiric { get; }

    /// <summary>
    /// Returns whether or not the item is very sharp and cuts foes of the player when being used.
    /// </summary>
    bool Vorpal { get; }

    /// <summary>
    /// Returns whether or not the item affects the wisdom of the player when being worn.
    /// </summary>
    bool Wis { get; }

    bool Wraith { get; }
    bool XtraMight { get; }
    bool XtraShots { get; }
}