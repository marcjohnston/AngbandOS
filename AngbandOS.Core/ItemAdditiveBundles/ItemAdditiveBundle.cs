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

    public virtual string Key => GetType().Name;
    public string GetKey => Key;

    public virtual void Bind()
    {
        Activation = Game.SingletonRepository.GetNullable<Activation>(ActivationName);
    }

    public string ToJson()
    {
        return "";
    }

    /// <summary>
    /// Returns then name of an <see cref="Activation "/>, if the item can be activated; or null, if the item cannot be activated.  Dragon scale mail, rings of ice, acid and flames, the planar weapon, fixed artifacts and
    /// random artifacts may have an <see cref="Activation"/>.  Returns null, by default.  This property is used to bind the <see cref="Activation"/> property during the bind phase.
    /// </summary>
    /// <inheritdoc />
    protected virtual string? ActivationName { get; }

    /// <inheritdoc />
    public Activation? Activation { get; protected set; }
    
    /// <inheritdoc />
    public virtual bool Aggravate => false;
    
    /// <inheritdoc />
    public virtual bool AntiTheft => false;
    
    /// <inheritdoc />
    public virtual ArtifactBias? ArtifactBias => null;
    
    /// <inheritdoc />
    public virtual bool Blessed => false;

    /// <inheritdoc/>
    public virtual bool Blows => false;
    
    /// <inheritdoc />
    public virtual bool BrandAcid => false;
    
    /// <inheritdoc />
    public virtual bool BrandCold => false;
    
    /// <inheritdoc />
    public virtual bool BrandElec => false;
    
    /// <inheritdoc />
    public virtual bool BrandFire => false;
    
    /// <inheritdoc />
    public virtual bool BrandPois => false;
    
    /// <inheritdoc />
    public virtual bool Cha => false;
    
    /// <inheritdoc />
    public virtual bool Chaotic => false;
    
    /// <inheritdoc />
    public virtual bool Con => false;
    
    /// <inheritdoc />
    public virtual bool IsCursed => false;
    
    /// <inheritdoc />
    public virtual bool Dex => false;
    
    /// <inheritdoc />
    public virtual bool DrainExp => false;
    
    /// <inheritdoc />
    public virtual bool DreadCurse => false;
    
    /// <inheritdoc />
    public virtual bool EasyKnow => false;
    
    /// <inheritdoc />
    public virtual bool Feather => false;
    
    /// <inheritdoc />
    public virtual bool FreeAct => false;
    
    /// <inheritdoc />
    public virtual bool HeavyCurse => false;
    
    /// <inheritdoc />
    public virtual bool HideType => false;
    
    /// <inheritdoc />
    public virtual bool HoldLife => false;
    
    /// <inheritdoc />
    public virtual bool IgnoreAcid => false;
    
    /// <inheritdoc />
    public virtual bool IgnoreCold => false;
    
    /// <inheritdoc />
    public virtual bool IgnoreElec => false;
    
    /// <inheritdoc />
    public virtual bool IgnoreFire => false;
    
    /// <inheritdoc />
    public virtual bool ImAcid => false;
    
    /// <inheritdoc />
    public virtual bool ImCold => false;
    
    /// <inheritdoc />
    public virtual bool ImElec => false;
    
    /// <inheritdoc />
    public virtual bool ImFire => false;
    
    /// <inheritdoc />
    public virtual bool Impact => false;
    
    /// <inheritdoc />
    public virtual bool Infra => false;
    
    /// <inheritdoc />
    public virtual bool InstaArt => false;
    
    /// <inheritdoc />
    public virtual bool Int => false;
    
    /// <inheritdoc />
    public virtual bool KillDragon => false;
    
    /// <inheritdoc />
    public virtual bool NoMagic => false;
    
    /// <inheritdoc />
    public virtual bool NoTele => false;
    
    /// <inheritdoc />
    public virtual bool PermaCurse => false;
    
    /// <inheritdoc />
    public virtual int Radius => 0;
    
    /// <inheritdoc />
    public virtual bool Reflect => false;
    
    /// <inheritdoc />
    public virtual bool Regen => false;
    
    /// <inheritdoc />
    public virtual bool ResAcid => false;
    
    /// <inheritdoc />
    public virtual bool ResBlind => false;
    
    /// <inheritdoc />
    public virtual bool ResChaos => false;
    
    /// <inheritdoc />
    public virtual bool ResCold => false;
    
    /// <inheritdoc />
    public virtual bool ResConf => false;
    
    /// <inheritdoc />
    public virtual bool ResDark => false;
    
    /// <inheritdoc />
    public virtual bool ResDisen => false;
    
    /// <inheritdoc />
    public virtual bool ResElec => false;
    
    /// <inheritdoc />
    public virtual bool ResFear => false;
    
    /// <inheritdoc />
    public virtual bool ResFire => false;
    
    /// <inheritdoc />
    public virtual bool ResLight => false;
    
    /// <inheritdoc />
    public virtual bool ResNether => false;
    
    /// <inheritdoc />
    public virtual bool ResNexus => false;
    
    /// <inheritdoc />
    public virtual bool ResPois => false;
    
    /// <inheritdoc />
    public virtual bool ResShards => false;
    
    /// <inheritdoc />
    public virtual bool ResSound => false;
    
    /// <inheritdoc />
    public virtual bool Search => false;
    
    /// <inheritdoc />
    public virtual bool SeeInvis => false;
    
    /// <inheritdoc />
    public virtual bool ShElec => false;
    
    /// <inheritdoc />
    public virtual bool ShFire => false;
    
    /// <inheritdoc />
    public virtual bool ShowMods => false;
    
    /// <inheritdoc />
    public virtual bool SlayAnimal => false;
    
    /// <inheritdoc />
    public virtual bool SlayDemon => false;
    
    /// <inheritdoc />
    public virtual bool SlayDragon => false;
    
    /// <inheritdoc />
    public virtual bool SlayEvil => false;
    
    /// <inheritdoc />
    public virtual bool SlayGiant => false;
    
    /// <inheritdoc />
    public virtual bool SlayOrc => false;
    
    /// <inheritdoc />
    public virtual bool SlayTroll => false;
    
    /// <inheritdoc />
    public virtual bool SlayUndead => false;
    
    /// <inheritdoc />
    public virtual bool SlowDigest => false;
    
    /// <inheritdoc />
    public virtual bool Speed => false;
    
    /// <inheritdoc />
    public virtual bool Stealth => false;
    
    /// <inheritdoc />
    public virtual bool Str => false;
    
    /// <inheritdoc />
    public virtual bool SustCha => false;
    
    /// <inheritdoc />
    public virtual bool SustCon => false;
    
    /// <inheritdoc />
    public virtual bool SustDex => false;
    
    /// <inheritdoc />
    public virtual bool SustInt => false;
    
    /// <inheritdoc />
    public virtual bool SustStr => false;
    
    /// <inheritdoc />
    public virtual bool SustWis => false;
    
    /// <inheritdoc />
    public virtual bool Telepathy => false;
    
    /// <inheritdoc />
    public virtual bool Teleport => false;

    /// <inheritdoc />
    public virtual int TreasureRating => 0;

    /// <inheritdoc />
    public virtual bool Tunnel => false;
    
    /// <inheritdoc />
    public virtual bool Vampiric => false;
    
    /// <inheritdoc />
    public virtual bool Vorpal => false;
    
    /// <inheritdoc />
    public virtual bool Wis => false;
    
    /// <inheritdoc />
    public virtual bool Wraith => false;
    
    /// <inheritdoc />
    public virtual bool XtraMight => false;
    
    /// <inheritdoc />
    public virtual bool XtraShots => false;
}
