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
    bool Activate { get; }
    bool Aggravate { get; }
    bool AntiTheft { get; }
    ArtifactBias? ArtifactBias { get; }
    bool Blessed { get; }
    bool Blows { get; }
    bool BrandAcid { get; }
    bool BrandCold { get; }
    bool BrandElec { get; }
    bool BrandFire { get; }
    bool BrandPois { get; }
    bool Cha { get; }
    bool Chaotic { get; }
    bool Con { get; }
    bool Cursed { get; }
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
    bool Impact { get; }
    bool Infra { get; }
    bool InstaArt { get; }
    bool Int { get; }
    bool KillDragon { get; }
    bool Lightsource { get; }
    bool NoMagic { get; }
    bool NoTele { get; }
    bool PermaCurse { get; }
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
    bool Speed { get; }
    bool Stealth { get; }
    bool Str { get; }
    bool SustCha { get; }
    bool SustCon { get; }
    bool SustDex { get; }
    bool SustInt { get; }
    bool SustStr { get; }
    bool SustWis { get; }
    bool Telepathy { get; }
    bool Teleport { get; }
    bool Tunnel { get; }
    bool Vampiric { get; }
    bool Vorpal { get; }
    bool Wis { get; }
    bool Wraith { get; }
    bool XtraMight { get; }
    bool XtraShots { get; }
}