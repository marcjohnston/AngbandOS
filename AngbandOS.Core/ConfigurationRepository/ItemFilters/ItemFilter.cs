// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal abstract class ItemFilter : IGetKey<string>, IItemFilter
{
    protected SaveGame SaveGame { get; }
    protected ItemFilter(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

    /// <summary>
    /// Returns true, if the item must be blessed; false, if the item cannot be blessed; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? IsBlessed => null;

    /// <summary>
    /// Returns true, if the item can be aimed; false, if the item cannot be aimed; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? CanBeAimed => null;

    /// <summary>
    /// Returns true, if the item must have a value greater than zero (>0); false, if the item must have a value of zero or less (<=0); or null, 
    /// if indifferent.  Returns true, by default.
    /// </summary>
    public virtual bool? HasValue => true;

    /// <summary>
    /// Returns true, if the item must be known; false, if the item cannot be known; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? IsKnown => null;

    /// <summary>
    /// Returns true, if the item must be activatable; false, if the item cannot be activatable; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? CanBeActivated => null;

    /// <summary>
    /// Returns true, if the item can be eaten; false, if the item cannot be eaten; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? CanBeEaten => null;

    /// <summary>
    /// Returns true, if the item can be quaffed; false, if the item cannot be quaffed; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? CanBeQuaffed => null;

    /// <summary>
    /// Returns true, if the item can be read; false, if the item cannot be read; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? CanBeRead => null;

    /// <summary>
    /// Returns true, if the item can be used; false, if the item cannot be used; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? CanBeUsed => null;

    /// <summary>
    /// Returns true, if the item can be zapped; false, if the item cannot be zapped; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? CanBeZapped => null;

    /// <summary>
    /// Returns true, if the item must capable of fueling a lantern; false, if the item cannot be fuel for a lantern; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? IsLanternFuel => null;

    /// <summary>
    /// Returns true, if the item must capable of fueling a torch; false, if the item cannot be fuel for a torch; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? IsFuelForTorch => null;

    /// <summary>
    /// Returns true, if the item is armor; false, if the item cannot be armor; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? IsArmor => null;

    /// <summary>
    /// Returns true, if the item must a weapon; false, if the item cannot be a weapon; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? IsWeapon => null;

    /// <summary>
    /// Returns true, if the item is wearable; false, if the item cannot be wearable; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? IsWearable => null;

    /// <summary>
    /// Returns true, if the item is rechargable; false, if the item cannot be rechargable; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? IsRechargable => null;

    /// <summary>
    /// Returns true, if the item is either the primary or secondary spell book; false, if the item cannot be either the primary or secondary spell book; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? IsUsableSpellBook => null;

    /// <summary>
    /// Returns true, if the item can be fired; false, if the item cannot be fired; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? CanBeFired => null;

    public virtual string Key => GetType().Name;
    public string GetKey => Key;

    public void Bind() { }

    public virtual bool ItemMatches(Item item)
    {
        item.RefreshFlagBasedProperties();
        if (IsBlessed != null && item.Characteristics.Blessed != IsBlessed)
        {
            return false;
        }
        if (HasValue == true && item.Value() <= 0)
        {
            return false;
        }
        if (HasValue == false && item.Value() > 0)
        {
            return false;
        }
        if (IsKnown != null && item.IsKnown() != IsKnown)
        {
            return false;
        }
        if (CanBeActivated != null && item.Characteristics.Activate != CanBeActivated)
        {
            return false;
        }
        if (IsLanternFuel != null && item.Factory.IsFuelForLantern != IsLanternFuel)
        {
            return false;
        }
        if (IsFuelForTorch != null && item.Factory.IsFuelForTorch != IsFuelForTorch)
        {
            return false;
        }
        if (IsWearable != null && item.Factory.IsWearable != IsWearable)
        {
            return false;
        }
        if (IsWeapon != null && item.Factory.IsWeapon != IsWeapon)
        {
            return false;
        }
        if (IsRechargable != null && item.Factory.IsRechargable != IsRechargable)
        {
            return false;
        }
        if (IsArmor != null && item.Factory.IsArmor != IsArmor)
        {
            return false;
        }
        if (CanBeFired != null && item.Factory.CanBeFired != CanBeFired)
        {
            return false;
        }
        if (CanBeAimed != null && item.Factory.CanBeAimed != CanBeAimed)
        {
            return false;
        }

        if (CanBeEaten != null && item.Factory.CanBeEaten != CanBeEaten)
        {
            return false;
        }
        if (CanBeQuaffed != null && item.Factory.CanBeQuaffed != CanBeQuaffed)
        {
            return false;
        }
        if (CanBeRead != null && item.Factory.CanBeRead != CanBeRead)
        {
            return false;
        }
        if (CanBeUsed != null && item.Factory.CanBeUsed != CanBeUsed)
        {
            return false;
        }
        if (CanBeZapped != null && item.Factory.CanBeZapped != CanBeZapped)
        {
            return false;
        }

        if (IsUsableSpellBook != null)
        {
            List<ItemTypeEnum> validItemTypes = new();
            if (SaveGame.PrimaryRealm != null)
            {
                validItemTypes.Add(SaveGame.PrimaryRealm.SpellBookItemCategory);
            }
            if (SaveGame.SecondaryRealm != null)
            {
                validItemTypes.Add(SaveGame.SecondaryRealm.SpellBookItemCategory);
            }
            if (IsUsableSpellBook == true && !validItemTypes.Contains(item.Category))
            {
                return false;
            }
            else if (IsUsableSpellBook == false && validItemTypes.Contains(item.Category))
            {
                return false;
            }
        }
        return true;
    }

}
