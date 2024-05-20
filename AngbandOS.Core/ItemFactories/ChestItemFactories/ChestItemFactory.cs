// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”


namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class ChestItemFactory : ItemFactory
{
    public ChestItemFactory(Game game) : base(game) { }
    protected override string ItemClassName => nameof(ChestsItemClass);
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Chest;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;

    public override bool IsStompable(Item item)
    {
        if (!item.IsKnown())
        {
            return false;
        }
        else if (item.ContainerIsOpen)
        {
            return Stompable[StompableType.Broken]; // Empty
        }
        else if (item.ContainerTrapConfiguration == null)
        {
            return Stompable[StompableType.Average];
        }
        else
        {
            if (item.ContainerTrapConfiguration.Traps.Length == 0)
            {
                return Stompable[StompableType.Good];
            }
            else
            {
                return Stompable[StompableType.Excellent];
            }
        }
    }

    public override string GetDetailedDescription(Item item)
    {
        string s = string.Empty;
        if (!item.IsKnown())
        {
        }
        else if (item.ContainerIsOpen)
        {
            s += " (empty)";
        }
        else if (item.ContainerTrapConfiguration == null)
        {
            s += " (unlocked)";
        }
        else if (!item.ContainerTrapConfiguration.IsTrapped)
        {
            s += " (disarmed)";
        }
        else
        {
            s += $" {item.ContainerTrapConfiguration.Description}";
        }

        // Chests do not have Mods, Damage or Bonus.  We are omitting the description for those features.
        return s;
    }

    /// <summary>
    /// Assigns the TypeSpecificValue for this chest.
    /// </summary>
    /// <param name="level"></param>
    /// <param name="power"></param>
    /// <remarks>
    /// Logic:
    /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
    /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
    /// </remarks>
    /// <param name="store"></param>
    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        if (item.Factory.LevelNormallyFound > 0)
        {
            int chestType = Game.DieRoll(item.Factory.LevelNormallyFound);
            item.ContainerIsOpen = false;
            int chestTrapConfigurationCount = Game.SingletonRepository.Get<ChestTrapConfiguration>().Length;
            int eightFivePercent = chestTrapConfigurationCount * 100 / 85;
            if (chestType > eightFivePercent)
            { 
                int randomRemaining = chestTrapConfigurationCount - eightFivePercent;
                chestType = eightFivePercent + Game.RandomLessThan(randomRemaining);
            }
            item.ContainerTrapConfiguration = Game.SingletonRepository.Get<ChestTrapConfiguration>(chestType);
            item.LevelOfObjectsInContainer = chestType;
        }
    }

    /// <summary>
    /// Returns false, because chests cannot be merged.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public override bool ItemsCanBeMerged(Item a, Item b)
    {
        return false;
    }

    /// <summary>
    /// Returns whether or not the chest is small.  Small chests have a 75% chance that the items in the chest are gold.  Large chest always return items.
    /// </summary>
    public abstract bool IsSmall { get; }
    public override int PackSort => 36;
    public abstract int NumberOfItemsContained { get; }

    public override ColorEnum Color => ColorEnum.Grey;
}
