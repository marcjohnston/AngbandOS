// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal abstract class FixedArtifact : IItemCharacteristics, IGetKey
{
    protected readonly SaveGame SaveGame;

    protected FixedArtifact(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    /// <summary>
    ///  Returns an activation object, if the fixed artifact can be activated; otherwise, null is returned.  This property is bound from ActivationName property
    ///  during the bind phase.
    /// </summary>
    public Activation? Activation { get; private set; }

    /// <summary>
    /// Returns the name of the activation, if the fixed artifact can be activated; otherwise, null is returned.  This property is bound to the Activation property
    /// during the bind phase.
    /// </summary>
    protected virtual string? ActivationName => null;

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind()
    {
        BaseItemFactory = SaveGame.SingletonRepository.ItemFactories.Get(BaseItemFactoryName);
        Activation = SaveGame.SingletonRepository.Activations.BindNullable(ActivationName);
    }

    /// <summary>
    /// Represents the quantity of this artifact currently in existence.
    /// </summary>
    public int CurNum = 0;

    /// <summary>
    /// Returns the multipler to use when being used to kill a dragon.  The SwordOfLightning returns a 3.  All other weapons return 1.
    /// </summary>
    public virtual int KillDragonMultiplier => 1;

    /// <summary>
    /// Allows the fixed artifact to apply resistances and power as needed.  Does nothing, by default.
    /// </summary>
    /// <returns></returns>
    public virtual void ApplyResistances(Item item) { }

    protected abstract string BaseItemFactoryName { get; }

    /// <summary>
    /// Returns the item factory that acts as the base item for fixed artifacts of this type.
    /// </summary>
    public ItemFactory BaseItemFactory { get; private set; }

    /// <summary>
    /// Returns a 1-in-chance value of the weapon doing extra vorpal damage.  Does not affect non-vorpal cutting weapons.  Default to a 1-in-6 chance.
    /// </summary>
    public virtual int VorpalExtraDamage1InChance => 6;

    public virtual bool IsVorpalBlade => false;

    /// <summary>
    /// Returns a 1-in-chance value of the weapon doing extra vorpal attacks. Does not affect non-vorpal cutting weapons.  Default to a 1-in-4 chance.
    /// </summary>
    public virtual int VorpalExtraAttacks1InChance => 4;

    public virtual ColorEnum Color => ColorEnum.White;
    public abstract string Name { get; }

    public abstract int Ac { get; }

    public virtual bool Activate { get; set; } = false;

    public virtual bool AntiTheft { get; set; } = false;

    public virtual bool Aggravate { get; set; } = false;

    public virtual bool Blessed { get; set; } = false;

    public virtual bool Blows { get; set; } = false;

    public virtual bool BrandAcid { get; set; } = false;

    public virtual bool BrandCold { get; set; } = false;

    public virtual bool BrandElec { get; set; } = false;

    public virtual bool BrandFire { get; set; } = false;

    public virtual bool BrandPois { get; set; } = false;

    public virtual bool Cha { get; set; } = false;

    public virtual bool Chaotic { get; set; } = false;

    public virtual bool Con { get; set; } = false;

    public abstract int Cost { get; }

    public virtual bool Cursed { get; set; } = false;

    public abstract int Dd { get; }

    public virtual bool Dex { get; set; } = false;

    public virtual bool DrainExp { get; set; } = false;

    public virtual bool DreadCurse { get; set; } = false;

    public abstract int Ds { get; }

    public virtual bool EasyKnow { get; set; } = false;

    public virtual bool Feather { get; set; } = false;

    public virtual bool FreeAct { get; set; } = false;

    public abstract string FriendlyName { get; }

    public virtual bool HasOwnType => false;

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

    public virtual bool Infra { get; set; } = false;

    public virtual bool InstaArt { get; set; } = false;

    public virtual bool Int { get; set; } = false;

    public virtual bool KillDragon { get; set; } = false;

    public abstract int Level { get; }

    public virtual bool Lightsource { get; set; } = false;

    public virtual bool NoMagic { get; set; } = false;

    public virtual bool NoTele { get; set; } = false;

    public virtual bool PermaCurse { get; set; } = false;

    public abstract int Pval { get; }

    public abstract int Rarity { get; }

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

    public virtual bool Search { get; set; } = false;

    public virtual bool SeeInvis { get; set; } = false;

    public virtual bool ShElec { get; set; } = false;

    public virtual bool ShFire { get; set; } = false;

    public virtual bool ShowMods { get; set; } = false;

    public virtual bool SlayAnimal { get; set; } = false;

    public virtual bool SlayDemon { get; set; } = false;

    public virtual bool SlayDragon { get; set; } = false;

    public virtual bool SlayEvil { get; set; } = false;

    public virtual bool SlayGiant { get; set; } = false;

    public virtual bool SlayOrc { get; set; } = false;

    public virtual bool SlayTroll { get; set; } = false;

    public virtual bool SlayUndead { get; set; } = false;

    public virtual bool SlowDigest { get; set; } = false;

    public virtual bool Speed { get; set; } = false;

    public virtual bool Stealth { get; set; } = false;

    public virtual bool Str { get; set; } = false;

    public virtual bool SustCha { get; set; } = false;

    public virtual bool SustCon { get; set; } = false;

    public virtual bool SustDex { get; set; } = false;

    public virtual bool SustInt { get; set; } = false;

    public virtual bool SustStr { get; set; } = false;

    public virtual bool SustWis { get; set; } = false;

    public virtual bool Telepathy { get; set; } = false;

    public virtual bool Teleport { get; set; } = false;

    public abstract int ToA { get; }

    public abstract int ToD { get; }

    public abstract int ToH { get; }

    public virtual bool Tunnel { get; set; } = false;

    public virtual bool Vampiric { get; set; } = false;

    public virtual bool Vorpal { get; set; } = false;

    public abstract int Weight { get; }

    public virtual bool Wis { get; set; } = false;

    public virtual bool Wraith { get; set; } = false;

    public virtual bool XtraMight { get; set; } = false;

    public virtual bool XtraShots { get; set; } = false;
}
