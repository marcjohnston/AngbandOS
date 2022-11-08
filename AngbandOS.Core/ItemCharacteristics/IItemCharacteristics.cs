// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Enumerations
{
    /// <summary>
    /// Represents the interface an object needs to implement to be considered having all 90+ ItemCharacteristics.  This interface allows existing objects to denote
    /// that they implement the same ItemCharacteristics.
    /// </summary>
    /// <remarks>
    /// It would have been nice if we could have made this interface immutable but there are numerous places where the we set the properties one at a time.  This
    /// is mostly present in the Randart.  Due to that implementation, we will will take quite care not to make this into a hybrid of storing state and using
    /// instantiation.  As a result, we will instantiate instances of this class as readonly and manipulate only the properties.  Therefore, the associated methods
    /// will reflect such.
    /// </remarks>
    internal interface IItemCharacteristics
    {
        bool Blows { get; set; }
        bool BrandAcid { get; set; }
        bool BrandCold { get; set; }
        bool BrandElec { get; set; }
        bool BrandFire { get; set; }
        bool BrandPois { get; set; }
        bool Cha { get; set; }
        bool Chaotic { get; set; }
        bool Con { get; set; }
        bool Dex { get; set; }
        bool Impact { get; set; }
        bool Infra { get; set; }
        bool Int { get; set; }
        bool KillDragon { get; set; }
        bool Search { get; set; }
        bool SlayAnimal { get; set; }
        bool SlayDemon { get; set; }
        bool SlayDragon { get; set; }
        bool SlayEvil { get; set; }
        bool SlayGiant { get; set; }
        bool SlayOrc { get; set; }
        bool SlayTroll { get; set; }
        bool SlayUndead { get; set; }
        bool Speed { get; set; }
        bool Stealth { get; set; }
        bool Str { get; set; }
        bool Tunnel { get; set; }
        bool Vampiric { get; set; }
        bool Vorpal { get; set; }
        bool Wis { get; set; }
        bool FreeAct { get; set; }
        bool HoldLife { get; set; }
        bool ImAcid { get; set; }
        bool ImCold { get; set; }
        bool ImElec { get; set; }
        bool ImFire { get; set; }
        bool Reflect { get; set; }
        bool ResAcid { get; set; }
        bool ResBlind { get; set; }
        bool ResChaos { get; set; }
        bool ResCold { get; set; }
        bool ResConf { get; set; }
        bool ResDark { get; set; }
        bool ResDisen { get; set; }
        bool ResElec { get; set; }
        bool ResFear { get; set; }
        bool ResFire { get; set; }
        bool ResLight { get; set; }
        bool ResNether { get; set; }
        bool ResNexus { get; set; }
        bool ResPois { get; set; }
        bool ResShards { get; set; }
        bool ResSound { get; set; }
        bool SustCha { get; set; }
        bool SustCon { get; set; }
        bool SustDex { get; set; }
        bool SustInt { get; set; }
        bool SustStr { get; set; }
        bool SustWis { get; set; }
        bool AntiTheft { get; set; }
        bool Activate { get; set; }
        bool Aggravate { get; set; }
        bool Blessed { get; set; }
        bool Cursed { get; set; }
        bool DrainExp { get; set; }
        bool DreadCurse { get; set; }
        bool EasyKnow { get; set; }
        bool Feather { get; set; }
        bool HeavyCurse { get; set; }
        bool HideType { get; set; }
        bool IgnoreAcid { get; set; }
        bool IgnoreCold { get; set; }
        bool IgnoreElec { get; set; }
        bool IgnoreFire { get; set; }
        bool InstaArt { get; set; }
        bool Lightsource { get; set; }
        bool NoMagic { get; set; }
        bool NoTele { get; set; }
        bool PermaCurse { get; set; }
        bool Regen { get; set; }
        bool SeeInvis { get; set; }
        bool ShElec { get; set; }
        bool ShFire { get; set; }
        bool ShowMods { get; set; }
        bool SlowDigest { get; set; }
        bool Telepathy { get; set; }
        bool Teleport { get; set; }
        bool Wraith { get; set; }
        bool XtraMight { get; set; }
        bool XtraShots { get; set; }
    }
}