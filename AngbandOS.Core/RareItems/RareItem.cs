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
internal abstract class RareItem : ItemAdditiveBundle, IGetKey
{
    protected RareItem(Game game) : base(game) { }

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
    public virtual void Bind() { }

    /// <summary>
    /// Returns the value of the rare item.  When this value is 0, the value of the item is 0 regardless of the value of the original item and the
    /// item is considered broken; otherwise this value is added to the value of the original item.
    /// </summary>
    public abstract int Cost { get; }

    /// <summary>
    /// Returns the name of the rare item characteristics.  This name is appended to the description of items that have a rare item
    /// characteristics applied to it.
    /// </summary>
    public virtual string FriendlyName { get; }

    /// <summary>
    /// Returns a maximum value for a random amount of additional TypeSpecificValue when adding magic.  If the item is cursed or broken,
    /// this maximum value will be subtracted from the item.  Returns 0, by default.
    /// </summary>
    public virtual int MaxPval => 0;

    /// <summary>
    /// Returns a maximum value for a random amount of additional BonusArmorClass when adding magic.  If the item is cursed or broken,
    /// this maximum value will be subtracted from the item
    /// </summary>
    public virtual int MaxToA => 0;

    /// <summary>
    /// Returns a maximum value for a random amount of additional BonusDamage when adding magic.  If the item is cursed or broken,
    /// this maximum value will be subtracted from the item
    /// </summary>
    public virtual int MaxToD => 0;

    /// <summary>
    /// Returns a maximum value for a random amount of additional BonusToHit when adding magic.  If the item is cursed or broken,
    /// this maximum value will be subtracted from the item
    /// </summary>
    public virtual int MaxToH => 0;

    /// <summary>
    /// Returns the value to be added to the treasure rating for these rare items.
    /// </summary>
    public abstract int Rating { get; }
}
