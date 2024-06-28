// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.ItemFactories;

namespace AngbandOS.Core;

/// <summary>
/// Represents an item filter for all items regardless of their value.  Does not filter any items out of the selection.
/// </summary>
[Serializable]
internal abstract class ItemFilter : IGetKey, IItemFilter
{
    protected readonly Game Game;
    protected ItemFilter(Game game)
    {
        Game = game;
    }

    protected ItemMatch[] ItemMatches { get; private set; }

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

    private ItemMatch[] AddStringsMatch(string title, string[]? matchingStrings, string[]? nonmatchingStrings, Func<Item, string> evaluateLambda)
    {
        List<ItemMatch> itemMatchList = new List<ItemMatch>();
        if (matchingStrings != null)
        {
            itemMatchList.Add(new StringsItemMatch(Game, $"{title} in ({String.Join(",", matchingStrings)})", matchingStrings, true, evaluateLambda));
        }
        if (nonmatchingStrings != null)
        {
            itemMatchList.Add(new StringsItemMatch(Game, $"{title} not in ({String.Join(",", nonmatchingStrings)})", nonmatchingStrings, false, evaluateLambda));
        }
        return itemMatchList.ToArray();
    }

    private ItemMatch[] AddBooleanMatch(string title, bool? boolean, Func<Item, bool> evaluateLambda)
    {
        List<ItemMatch> itemMatchList = new List<ItemMatch>();
        if (boolean.HasValue)
        {
            return new ItemMatch[]
            {
                new BooleanItemMatch(Game, $"{title}={boolean.Value}", boolean.Value, evaluateLambda)
            };
        }
        return new ItemMatch[] { };
    }

    public virtual void Bind()
    {
        List<ItemMatch> itemMatchList = new List<ItemMatch>();
        itemMatchList.AddRange(AddStringsMatch("FactoryKeys", AnyMatchingFactoryKeys, AllNonMatchingFactoryKeys, (Item item) => item.Factory.Key));
        itemMatchList.AddRange(AddStringsMatch("FactoryItemClassKeys", AnyMatchingFactoryItemClassKeys, AllNonMatchingFactoryItemClassKeys, (Item item) => item.Factory.ItemClass.Key));
        itemMatchList.AddRange(AddBooleanMatch("IsOfValue", IsOfValue, (Item item) => item.Value() > 0));
        itemMatchList.AddRange(AddBooleanMatch("IsKnown", IsKnown, (Item item) => item.IsKnown()));
        itemMatchList.AddRange(AddBooleanMatch("IsTooHeavyToWield", IsTooHeavyToWield, (Item item) => Game.AbilityScores[Ability.Strength].StrMaxWeaponWeight < item.Weight / 10));
        itemMatchList.AddRange(AddBooleanMatch("IsLanternFuel", IsLanternFuel, (Item item) => item.Factory.IsFuelForLantern));
        itemMatchList.AddRange(AddBooleanMatch("IsWeapon", IsWeapon, (Item item) => item.Factory.IsWeapon));
        itemMatchList.AddRange(AddBooleanMatch("CanBeEaten", CanBeEaten, (Item item) => item.Factory.CanBeEaten));
        itemMatchList.AddRange(AddBooleanMatch("CanBeQuaffed", CanBeQuaffed, (Item item) => item.Factory.CanBeQuaffed));
        itemMatchList.AddRange(AddBooleanMatch("CanBeRead", CanBeRead, (Item item) => item.Factory.CanBeRead));
        itemMatchList.AddRange(AddBooleanMatch("CanBeUsed", CanBeUsed, (Item item) => item.Factory.CanBeUsed));
        itemMatchList.AddRange(AddBooleanMatch("CanProjectArrows", CanProjectArrows, (Item item) => item.Factory.CanProjectArrows));
        itemMatchList.AddRange(AddBooleanMatch("CanBeUsedToDig", CanBeUsedToDig, (Item item) => item.Factory.CanBeUsedToDig));
        itemMatchList.AddRange(AddBooleanMatch("IsFuelForTorch", IsFuelForTorch, (Item item) => item.Factory.IsFuelForTorch));
        itemMatchList.AddRange(AddBooleanMatch("IsWearable", IsWearable, (Item item) => item.Factory.IsWearable));
        itemMatchList.AddRange(AddBooleanMatch("IsArmor", IsArmor, (Item item) => item.Factory.IsArmor));
        itemMatchList.AddRange(AddBooleanMatch("CanBeFired", CanBeFired, (Item item) => item.Factory.CanBeFired));
        itemMatchList.AddRange(AddBooleanMatch("IsBlessed", IsBlessed, (Item item) => item.Characteristics.Blessed));
        ItemMatches = itemMatchList.ToArray();
    }

    /// <summary>
    /// Returns one or more <see cref="ItemFactory"/> keys for item factories that should match; null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual string[]? AnyMatchingFactoryKeys => null;

    /// <summary>
    /// Returns one or more <see cref="ItemFactory"/> keys for item factories that should not match; null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual string[]? AllNonMatchingFactoryKeys => null;

    /// <summary>
    /// Returns the key for the ItemClass that the ItemFactory must belong to; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual string[]? AnyMatchingFactoryItemClassKeys => null;

    /// <summary>
    /// Returns the key for the ItemClass that the ItemFactory must belong to; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual string[]? AllNonMatchingFactoryItemClassKeys => null;

    /// <summary>
    /// Returns true, if the item must have a value greater than zero (>0); false, if the item must have a value of zero or less (<=0); or null, 
    /// if indifferent.  Returns null, by default.  Stores require their items to have value to be an item in the store.
    /// </summary>
    public virtual bool? IsOfValue => null;

    /// <summary>
    /// Returns true, if the item must be known; false, if the item cannot be known; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? IsKnown => null;

    /// <summary>
    /// Returns true, if the item must be too heavy to wield; false, if the item cannot be too heavy to wield; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? IsTooHeavyToWield => null;


    /// <summary>
    /// Returns true, if the item must be able to project arrows; false, if the item cannot project arrows; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? CanProjectArrows => null;

    /// <summary>
    /// Returns true, if the item must be blessed; false, if the item cannot be blessed; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? IsBlessed => null;

    /// <summary>
    /// Returns true, if the item can be aimed; false, if the item cannot be aimed; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? CanBeAimed => null;

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

    /// <summary>
    /// Returns true, if the item can be used to dig; false, if the item cannot be used to dig; or null, if indifferent.  Returns null, by default.
    /// </summary>
    [Obsolete("Use ItemClass")]
    public virtual bool? CanBeUsedToDig => null;

    public virtual bool Matches(Item item)
    {
        foreach (ItemMatch itemMatch in ItemMatches)
        {
            if (!itemMatch.Matches(item))
            {
                return false;
            }
        }

        ItemCharacteristics mergedCharacteristics = item.GetMergedCharacteristics();
        if (CanBeActivated.HasValue)
        {
            if (CanBeActivated.Value && mergedCharacteristics.Activation == null)
            {
                return false;
            }
            else if (!CanBeActivated.Value && mergedCharacteristics.Activation != null)
            {
                return false;
            }
        }
        if (IsRechargable.HasValue)
        {
            if (IsRechargable.Value && item.Factory.RechargeScript == null)
            {
                return false;
            }
            else if (!IsRechargable.Value && item.Factory.RechargeScript != null)
            {
                return false;
            }
        }
        if (CanBeAimed.HasValue)
        {
            if (CanBeAimed.Value && item.Factory.AimingDetails == null)
            {
                return false;
            }
            else if (!CanBeAimed.Value && item.Factory.AimingDetails != null)
            {
                return false;
            }
        }

        if (CanBeZapped.HasValue)
        {
            if (CanBeZapped.Value && item.Factory.ZapDetails == null)
            {
                return false;
            }
            if (!CanBeZapped.Value && item.Factory.ZapDetails != null)
            {
                return false;
            }
        }

        // Check to see if the item must be a usable spell book.
        if (IsUsableSpellBook != null && IsUsableSpellBook.Value)
        {
            // A usable spell book is required.  Ensure it is a book.
            BookItemFactory? bookItemFactory = item.TryGetFactory<BookItemFactory>();
            if (bookItemFactory == null)
            {
                return false;
            }

            // Ensure the player has magic.
            if (Game.PrimaryRealm == null)
            {
                return false;
            }

            // Check to see if the book doesn't belong to the primary realm.
            if (Game.PrimaryRealm != bookItemFactory.Realm)
            {
                // It doesn't.  Check to see if there is a secondary realm.
                if (Game.SecondaryRealm == null)
                {
                    // There isn't.  No match.
                    return false;
                }

                // There is a secondary realm, check to see if the book doesn't belong to it.
                if (Game.SecondaryRealm != bookItemFactory.Realm)
                {
                    return false;
                }
            }
        }

        if (IsUsableSpellBook != null && !IsUsableSpellBook.Value)
        {
            BookItemFactory? bookItemFactory = item.TryGetFactory<BookItemFactory>();
            if (bookItemFactory != null)
            {
                if (Game.PrimaryRealm != null && Game.PrimaryRealm == bookItemFactory.Realm || Game.SecondaryRealm != null && Game.SecondaryRealm == bookItemFactory.Realm)
                {
                    return false;
                }
            }
        }
        return true;
    }
}
