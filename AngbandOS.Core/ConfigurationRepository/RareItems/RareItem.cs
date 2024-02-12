// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RareItems;

/// <summary>
/// Represents additional characteristics that are applied to items.  These characteristics affect:
/// 1. Description - The item description is enhanced
/// 2. Item Characteristics - Rare items participate in the IItemCharacteristics interface and the rare item characteristics are merged with the original item.
/// 3. Application of Magic - Items with rare item characteristics 
/// </summary>
[Serializable]
internal abstract class RareItem : IItemCharacteristics, IGetKey<string>
{
    protected SaveGame SaveGame;
    protected RareItem(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    /// <summary>
    /// Performs the activation effect on an item and returns true, if the activation was successful; false, otherwise.  Returns false,
    /// by default.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public virtual bool DoActivate(Item item) 
    { 
        return false;
    }

    public virtual void ApplyMagic(Item item) { }

    /// <summary>
    /// Returns additional text that describes the activation ability of the rare item; or null, if the rare item cannot be activated.
    /// Activate = false;
    /// </summary>
    public virtual string? DescribeActivationEffect => null;

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
    public void Bind() { }

    /// <summary>
    /// Returns the symbol to use for rendering.
    /// </summary>
    public abstract Symbol Symbol { get; }

    public virtual ColorEnum Color => ColorEnum.White;
    public abstract string Name { get; }

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

    /// <summary>
    /// Returns the value of the rare item.  When this value is 0, the value of the item is 0 regardless of the value of the original item and the
    /// item is considered broken; otherwise this value is added to the value of the original item.
    /// </summary>
    public abstract int Cost { get; }

    public virtual bool Cursed { get; set; } = false;

    public virtual bool Dex { get; set; } = false;

    public virtual bool DrainExp { get; set; } = false;

    public virtual bool DreadCurse { get; set; } = false;

    public virtual bool EasyKnow { get; set; } = false;

    public virtual bool Feather { get; set; } = false;

    public virtual bool FreeAct { get; set; } = false;

    /// <summary>
    /// Returns the name of the rare item characteristics.  This name is appended to the description of items that have a rare item
    /// characteristics applied to it.
    /// </summary>
    public virtual string FriendlyName { get; }

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

    /// <summary>
    /// Returns a maximum value for a random amount of additional TypeSpecificValue when adding magic.  If the item is cursed or broken,
    /// this maximum value will be subtracted from the item
    /// </summary>
    public abstract int MaxPval { get; }

    /// <summary>
    /// Returns a maximum value for a random amount of additional BonusArmorClass when adding magic.  If the item is cursed or broken,
    /// this maximum value will be subtracted from the item
    /// </summary>
    public abstract int MaxToA { get; }

    /// <summary>
    /// Returns a maximum value for a random amount of additional BonusDamage when adding magic.  If the item is cursed or broken,
    /// this maximum value will be subtracted from the item
    /// </summary>
    public abstract int MaxToD { get; }

    /// <summary>
    /// Returns a maximum value for a random amount of additional BonusToHit when adding magic.  If the item is cursed or broken,
    /// this maximum value will be subtracted from the item
    /// </summary>
    public abstract int MaxToH { get; }

    public virtual bool NoMagic { get; set; } = false;

    public virtual bool NoTele { get; set; } = false;

    public virtual bool PermaCurse { get; set; } = false;

    public abstract int Rarity { get; }

    public abstract int Rating { get; }

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

    public abstract int Slot { get; }

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

    public virtual bool Tunnel { get; set; } = false;

    public virtual bool Vampiric { get; set; } = false;

    public virtual bool Vorpal { get; set; } = false;

    public virtual bool Wis { get; set; } = false;

    public virtual bool Wraith { get; set; } = false;

    public virtual bool XtraMight { get; set; } = false;

    public virtual bool XtraShots { get; set; } = false;
}
