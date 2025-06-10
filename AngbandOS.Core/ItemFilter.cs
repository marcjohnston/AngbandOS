// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents an object that can compare items with some predefined matching criteria.  The predefined matching criteria are bound during the bind phase by adding <see cref="ItemMatch"/> objects
/// to the <see cref="ItemMatches"/> list.  This binding of predefined <see cref="ItemMatch"/> objects allows the matching of items at run-time to be as fast as possible; no unnecessary comparisions
/// are performed.  These <see cref="ItemFilter"/> objects are designed to support configurability.
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

    /// <summary>
    /// Adds either or both <see cref="StringsItemMatch"/> objects for positive and negative comparisons using two nullable string array properties.  
    /// </summary>
    /// <param name="title"></param>
    /// <param name="matchingStrings"></param>
    /// <param name="nonmatchingStrings"></param>
    /// <param name="positiveLambdaEvaluation"></param>
    /// <returns></returns>
    private ItemMatch[] AddContainsMatch<T>(T[]? matchingStrings, T[]? nonmatchingStrings, GetItemProperty<T> positiveLambdaEvaluation)
    {
        List<ItemMatch> itemMatchList = new List<ItemMatch>();
        if (matchingStrings != null)
        {
            itemMatchList.Add(new ContainsItemMatch<T>(Game, matchingStrings, true, positiveLambdaEvaluation));
        }
        if (nonmatchingStrings != null)
        {
            itemMatchList.Add(new ContainsItemMatch<T>(Game, nonmatchingStrings, false, positiveLambdaEvaluation));
        }
        return itemMatchList.ToArray();
    }

    /// <summary>
    /// Adds either or both <see cref="BooleanItemMatch"/> objects for positive and negative comparising using a single nullable boolean property.
    /// </summary>
    /// <param name="title"></param>
    /// <param name="boolean"></param>
    /// <param name="positiveLambdaEvaluation"></param>
    /// <returns></returns>
    private ItemMatch[] AddBooleanMatch(bool? boolean, GetItemProperty<bool> positiveLambdaEvaluation)
    {
        List<ItemMatch> itemMatchList = new List<ItemMatch>();
        if (boolean.HasValue)
        {
            return new ItemMatch[]
            {
                new BooleanItemMatch(Game, boolean.Value, positiveLambdaEvaluation)
            };
        }
        return new ItemMatch[] { };
    }

    public virtual void Bind()
    {
        AnyMatchingItemClasses = Game.SingletonRepository.GetNullable<ItemClass>(AnyMatchingItemClassNames);
        AllNonMatchingItemClasses = Game.SingletonRepository.GetNullable<ItemClass>(AllNonMatchingItemClassNames);
        AnyMatchingItemFactories = Game.SingletonRepository.GetNullable<ItemFactory>(AnyMatchingItemFactoryNames);
        AllNonMatchingItemFactories = Game.SingletonRepository.GetNullable<ItemFactory>(AllNonMatchingItemFactoryNames);

        List<ItemMatch> itemMatchList = new List<ItemMatch>();
        itemMatchList.AddRange(AddBooleanMatch(CanBeActivated, new CanBeActivatedBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(CanBeAimed, new CanBeAimedBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(CanBeEaten, new CanBeEatenBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(CanBeFired, new CanBeFiredBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(CanBeQuaffed, new CanBeQuaffedBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(CanBeRead, new CanBeReadBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(CanBeRecharged, new CanBeReadBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(CanBeUsed, new CanBeUsedBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(CanBeUsedToDig, new CanTunnelBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(CanBeZapped, new CanBeZappedBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(CanProjectArrows, new CanProjectArrowsBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(IsArmor, new IsArmorBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(IsBlessed, new IsBlessedBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(IsFuelForTorch, new IsFuelForTorchBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(IsKnown, new IsKnownBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(IsLanternFuel, new IsLanternFuelBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(IsOfValue, new IsOfValueBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(IsTooHeavyToWield, new IsTooHeavyToWieldBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(IsUsableSpellBook, new IsUsableSpellBookBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(IsWeapon, new IsWeaponBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddBooleanMatch(IsWearableOrWieldable, new IsWearableOrWieldableBooleanGetItemProperty(Game)));
        itemMatchList.AddRange(AddContainsMatch<ItemClass>(AnyMatchingItemClasses, AllNonMatchingItemClasses, new ItemClassGetItemProperty(Game)));
        itemMatchList.AddRange(AddContainsMatch<ItemFactory>(AnyMatchingItemFactories, AllNonMatchingItemFactories, new ItemFactoryGetItemProperty(Game)));
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
    protected virtual string[]? AnyMatchingItemClassNames => null;
    public ItemClass[]? AnyMatchingItemClasses { get; private set; }

    /// <summary>
    /// Returns the key for the ItemClass that the ItemFactory must belong to; or null, if indifferent.  Returns null, by default.
    /// </summary>
    protected virtual string[]? AllNonMatchingItemClassNames => null;
    public ItemClass[]? AllNonMatchingItemClasses { get; private set; }

    /// <summary>
    /// Returns one or more <see cref="ItemFactory"/> keys for item factories that should match; null, if indifferent.  Returns null, by default.
    /// </summary>
    protected virtual string[]? AnyMatchingItemFactoryNames => null;
    public ItemFactory[]? AnyMatchingItemFactories { get; private set; }

    /// <summary>
    /// Returns one or more <see cref="ItemFactory"/> keys for item factories that should not match; null, if indifferent.  Returns null, by default.
    /// </summary>
    protected virtual string[]? AllNonMatchingItemFactoryNames => null;
    public ItemFactory[]? AllNonMatchingItemFactories { get; private set; }
}
