// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal abstract class ItemMatchingCriteria : IGetKey<string>, IItemFilter
{
    protected SaveGame SaveGame { get; }
    protected ItemMatchingCriteria(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    /// <summary>
    /// Returns true, if the item must be blessed; false, if the item cannot be blessed; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? IsBlessed => null;

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
    /// Returns true, if the item must capable of fueling a lantern; false, if the item cannot be fuel for a lantern; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? IsLanternFuel => null;

    /// <summary>
    /// Returns true, if the item must capable of fueling a torch; false, if the item cannot be fuel for a torch; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? IsFuelForTorch => null;

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
        return true;
    }

}
