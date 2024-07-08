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

    private ItemMatch[] AddStringsMatch(string title, string[]? matchingStrings, string[]? nonmatchingStrings, Func<Item, string> positiveLambdaEvaluation)
    {
        List<ItemMatch> itemMatchList = new List<ItemMatch>();
        if (matchingStrings != null)
        {
            itemMatchList.Add(new StringsItemMatch(Game, $"{title} in ({String.Join(",", matchingStrings)})", matchingStrings, true, positiveLambdaEvaluation));
        }
        if (nonmatchingStrings != null)
        {
            itemMatchList.Add(new StringsItemMatch(Game, $"{title} not in ({String.Join(",", nonmatchingStrings)})", nonmatchingStrings, false, positiveLambdaEvaluation));
        }
        return itemMatchList.ToArray();
    }

    private ItemMatch[] AddBooleanMatch(string title, bool? boolean, Func<Item, bool> positiveLambdaEvaluation)
    {
        List<ItemMatch> itemMatchList = new List<ItemMatch>();
        if (boolean.HasValue)
        {
            return new ItemMatch[]
            {
                new BooleanItemMatch(Game, $"{title}={boolean.Value}", boolean.Value, positiveLambdaEvaluation)
            };
        }
        return new ItemMatch[] { };
    }

    public virtual void Bind()
    {
        List<ItemMatch> itemMatchList = new List<ItemMatch>();
        itemMatchList.AddRange(AddBooleanMatch("CanBeActivated", CanBeActivated, (Item item) => item.GetMergedCharacteristics().Activation != null));
        itemMatchList.AddRange(AddBooleanMatch("CanBeAimed", CanBeAimed, (Item item) => item.Factory.AimingDetails != null));
        itemMatchList.AddRange(AddBooleanMatch("CanBeEaten", CanBeEaten, (Item item) => item.Factory.CanBeEaten));
        itemMatchList.AddRange(AddBooleanMatch("CanBeFired", CanBeFired, (Item item) =>
        {
            RangedWeaponInventorySlot rangedWeaponInventorySlot = (RangedWeaponInventorySlot)Game.SingletonRepository.Get<BaseInventorySlot>(nameof(RangedWeaponInventorySlot));
            WeightedRandom<int> weightedRandom = rangedWeaponInventorySlot.WeightedRandom;
            Item? rangedWeapon = Game.GetInventoryItem(weightedRandom.ChooseOrDefault());
            if (rangedWeapon == null || rangedWeapon.Factory.AmmunitionItemFactories == null)
            {
                return false;
            }

            return rangedWeapon.Factory.AmmunitionItemFactories.Contains(item.Factory);
        }));
        itemMatchList.AddRange(AddBooleanMatch(nameof(CanBeQuaffed), CanBeQuaffed, (Item item) => item.Factory.QuaffDetails != null));
        itemMatchList.AddRange(AddBooleanMatch(nameof(CanBeRead), CanBeRead, (Item item) => item.Factory.CanBeRead));
        itemMatchList.AddRange(AddBooleanMatch(nameof(CanBeRecharged), CanBeRecharged, (Item item) => item.Factory.RechargeScript != null));
        itemMatchList.AddRange(AddBooleanMatch(nameof(CanBeUsed), CanBeUsed, (Item item) => item.Factory.CanBeUsed));
        itemMatchList.AddRange(AddBooleanMatch(nameof(CanBeUsedToDig), CanBeUsedToDig, (Item item) => item.Factory.CanBeUsedToDig));
        itemMatchList.AddRange(AddBooleanMatch(nameof(CanBeZapped), CanBeZapped, (Item item) => item.Factory.ZapDetails != null));
        itemMatchList.AddRange(AddBooleanMatch(nameof(CanProjectArrows), CanProjectArrows, (Item item) => item.Factory.CanProjectArrows));
        itemMatchList.AddRange(AddBooleanMatch(nameof(IsArmor), IsArmor, (Item item) => item.Factory.IsArmor));
        itemMatchList.AddRange(AddBooleanMatch(nameof(IsBlessed), IsBlessed, (Item item) => item.Characteristics.Blessed));
        itemMatchList.AddRange(AddBooleanMatch(nameof(IsFuelForTorch), IsFuelForTorch, (Item item) => item.Factory.IsFuelForTorch));
        itemMatchList.AddRange(AddBooleanMatch(nameof(IsKnown), IsKnown, (Item item) => item.IsKnown()));
        itemMatchList.AddRange(AddBooleanMatch(nameof(IsLanternFuel), IsLanternFuel, (Item item) => item.Factory.IsFuelForLantern));
        itemMatchList.AddRange(AddBooleanMatch(nameof(IsOfValue), IsOfValue, (Item item) => item.Value() > 0));
        itemMatchList.AddRange(AddBooleanMatch(nameof(IsTooHeavyToWield), IsTooHeavyToWield, (Item item) => Game.AbilityScores[Ability.Strength].StrMaxWeaponWeight < item.Weight / 10));
        itemMatchList.AddRange(AddBooleanMatch(nameof(IsUsableSpellBook), IsUsableSpellBook, (Item item) => Game.PrimaryRealm != null && Game.PrimaryRealm.SpellBooks.Contains(item.Factory) || Game.SecondaryRealm != null && Game.SecondaryRealm.SpellBooks.Contains(item.Factory)));
        itemMatchList.AddRange(AddBooleanMatch(nameof(IsWeapon), IsWeapon, (Item item) => item.Factory.IsWeapon));
        itemMatchList.AddRange(AddBooleanMatch(nameof(IsWearableOrWieldable), IsWearableOrWieldable, (Item item) => item.Factory.IsWearableOrWieldable));
        itemMatchList.AddRange(AddStringsMatch("FactoryItemClassKeys", AnyMatchingFactoryItemClassKeys, AllNonMatchingFactoryItemClassKeys, (Item item) => item.Factory.ItemClass.Key));
        itemMatchList.AddRange(AddStringsMatch("FactoryKeys", AnyMatchingFactoryKeys, AllNonMatchingFactoryKeys, (Item item) => item.Factory.Key));
        ItemMatches = itemMatchList.ToArray();
    }

    public bool Matches(Item item)
    {
        foreach (ItemMatch itemMatch in ItemMatches)
        {
            if (!itemMatch.Matches(item))
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Returns true, if the item must be activatable; false, if the item cannot be activatable; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? CanBeActivated => null;

    /// <summary>
    /// Returns true, if the item can be aimed; false, if the item cannot be aimed; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? CanBeAimed => null;

    /// <summary>
    /// Returns true, if the item can be eaten; false, if the item cannot be eaten; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? CanBeEaten => null;

    /// <summary>
    /// Returns true, if the item can be fired; false, if the item cannot be fired; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? CanBeFired => null;

    /// <summary>
    /// Returns true, if the item can be quaffed; false, if the item cannot be quaffed; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? CanBeQuaffed => null;

    /// <summary>
    /// Returns true, if the item can be read; false, if the item cannot be read; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? CanBeRead => null;

    /// <summary>
    /// Returns true, if the item is rechargable; false, if the item cannot be rechargable; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? CanBeRecharged => null;

    /// <summary>
    /// Returns true, if the item can be used; false, if the item cannot be used; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? CanBeUsed => null;

    /// <summary>
    /// Returns true, if the item can be used to dig; false, if the item cannot be used to dig; or null, if indifferent.  Returns null, by default.
    /// </summary>
    [Obsolete("Use ItemClass")]
    public virtual bool? CanBeUsedToDig => null;

    /// <summary>
    /// Returns true, if the item can be zapped; false, if the item cannot be zapped; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? CanBeZapped => null;

    /// <summary>
    /// Returns true, if the item must be able to project arrows; false, if the item cannot project arrows; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? CanProjectArrows => null;

    /// <summary>
    /// Returns true, if the item is armor; false, if the item cannot be armor; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? IsArmor => null;

    /// <summary>
    /// Returns true, if the item must be blessed; false, if the item cannot be blessed; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? IsBlessed => null;

    /// <summary>
    /// Returns true, if the item must capable of fueling a torch; false, if the item cannot be fuel for a torch; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? IsFuelForTorch => null;

    /// <summary>
    /// Returns true, if the item must be known; false, if the item cannot be known; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? IsKnown => null;

    /// <summary>
    /// Returns true, if the item must capable of fueling a lantern; false, if the item cannot be fuel for a lantern; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? IsLanternFuel => null;

    /// <summary>
    /// Returns true, if the item must have a value greater than zero (>0); false, if the item must have a value of zero or less (<=0); or null, 
    /// if indifferent.  Returns null, by default.  Stores require their items to have value to be an item in the store.
    /// </summary>
    public virtual bool? IsOfValue => null;

    /// <summary>
    /// Returns true, if the item must be too heavy to wield; false, if the item cannot be too heavy to wield; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? IsTooHeavyToWield => null;

    /// <summary>
    /// Returns true, if the item is either the primary or secondary spell book; false, if the item cannot be either the primary or secondary spell book; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? IsUsableSpellBook => null;

    /// <summary>
    /// Returns true, if the item must a weapon; false, if the item cannot be a weapon; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? IsWeapon => null;

    /// <summary>
    /// Returns true, if the item is wearable; false, if the item cannot be wearable; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual bool? IsWearableOrWieldable => null;

    /// <summary>
    /// Returns the key for the ItemClass that the ItemFactory must belong to; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual string[]? AnyMatchingFactoryItemClassKeys => null;

    /// <summary>
    /// Returns the key for the ItemClass that the ItemFactory must belong to; or null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual string[]? AllNonMatchingFactoryItemClassKeys => null;

    /// <summary>
    /// Returns one or more <see cref="ItemFactory"/> keys for item factories that should match; null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual string[]? AnyMatchingFactoryKeys => null;

    /// <summary>
    /// Returns one or more <see cref="ItemFactory"/> keys for item factories that should not match; null, if indifferent.  Returns null, by default.
    /// </summary>
    public virtual string[]? AllNonMatchingFactoryKeys => null;
}
