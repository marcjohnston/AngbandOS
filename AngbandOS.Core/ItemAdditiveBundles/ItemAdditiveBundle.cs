// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemAdditiveBundles;

/// <summary>
/// Represents an set of item characteristics.
/// </summary>
[Serializable]
internal abstract class ItemAdditiveBundle : IItemCharacteristics, IGetKey
{
    protected readonly Game Game;
    protected ItemAdditiveBundle(Game game)
    {
        Game = game;
    }
    public virtual bool Activate => false;
    public virtual bool Aggravate => false;
    public virtual bool AntiTheft => false;
    public virtual ArtifactBias? ArtifactBias => null;
    public virtual bool Blessed => false;
    public virtual bool Blows => false;
    public virtual bool BrandAcid => false;
    public virtual bool BrandCold => false;
    public virtual bool BrandElec => false;
    public virtual bool BrandFire => false;
    public virtual bool BrandPois => false;
    public virtual bool Cha => false;
    public virtual bool Chaotic => false;
    public virtual bool Con => false;
    public virtual bool Cursed => false;
    public virtual bool Dex => false;
    public virtual bool DrainExp => false;
    public virtual bool DreadCurse => false;
    public virtual bool EasyKnow => false;
    public virtual bool Feather => false;
    public virtual bool FreeAct => false;
    public virtual bool HeavyCurse => false;
    public virtual bool HideType => false;
    public virtual bool HoldLife => false;
    public virtual bool IgnoreAcid => false;
    public virtual bool IgnoreCold => false;
    public virtual bool IgnoreElec => false;
    public virtual bool IgnoreFire => false;
    public virtual bool ImAcid => false;
    public virtual bool ImCold => false;
    public virtual bool ImElec => false;
    public virtual bool ImFire => false;
    public virtual bool Impact => false;
    public virtual bool Infra => false;
    public virtual bool InstaArt => false;
    public virtual bool Int => false;
    public virtual bool KillDragon => false;
    public virtual bool NoMagic => false;
    public virtual bool NoTele => false;
    public virtual bool PermaCurse => false;

    /// <summary>
    /// Returns the radius of light that the additive bundle adds to the item light source; or 0, if the additive bundle doesn't modify the item light source capabilities.  Returns 0, by default.
    /// </summary>
    public virtual int Radius => 0;

    public virtual bool Reflect => false;
    public virtual bool Regen => false;
    public virtual bool ResAcid => false;
    public virtual bool ResBlind => false;
    public virtual bool ResChaos => false;
    public virtual bool ResCold => false;
    public virtual bool ResConf => false;
    public virtual bool ResDark => false;
    public virtual bool ResDisen => false;
    public virtual bool ResElec => false;
    public virtual bool ResFear => false;
    public virtual bool ResFire => false;
    public virtual bool ResLight => false;
    public virtual bool ResNether => false;
    public virtual bool ResNexus => false;
    public virtual bool ResPois => false;
    public virtual bool ResShards => false;
    public virtual bool ResSound => false;
    public virtual bool Search => false;
    public virtual bool SeeInvis => false;
    public virtual bool ShElec => false;
    public virtual bool ShFire => false;
    public virtual bool ShowMods => false;
    public virtual bool SlayAnimal => false;
    public virtual bool SlayDemon => false;
    public virtual bool SlayDragon => false;
    public virtual bool SlayEvil => false;
    public virtual bool SlayGiant => false;
    public virtual bool SlayOrc => false;
    public virtual bool SlayTroll => false;
    public virtual bool SlayUndead => false;
    public virtual bool SlowDigest => false;
    public virtual bool Speed => false;
    public virtual bool Stealth => false;
    public virtual bool Str => false;
    public virtual bool SustCha => false;
    public virtual bool SustCon => false;
    public virtual bool SustDex => false;
    public virtual bool SustInt => false;
    public virtual bool SustStr => false;
    public virtual bool SustWis => false;
    public virtual bool Telepathy => false;
    public virtual bool Teleport => false;
    public virtual bool Tunnel => false;
    public virtual bool Vampiric => false;
    public virtual bool Vorpal => false;
    public virtual bool Wis => false;
    public virtual bool Wraith => false;
    public virtual bool XtraMight => false;
    public virtual bool XtraShots => false;

    public virtual string Key => GetType().Name;
    public string GetKey => Key;

    public virtual void Bind() { }

    public string ToJson()
    {
        return "";
    }
}
