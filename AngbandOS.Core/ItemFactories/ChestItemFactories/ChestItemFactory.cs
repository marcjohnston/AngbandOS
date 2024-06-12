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

    /// <summary>
    /// Returns false, because the player shouldn't be asked to stomp all Chests. 
    /// </summary>
    public override bool AskDestroyAll => false;

    public override bool IsContainer => true;

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
        else if (item.ContainerTraps == null)
        {
            return Stompable[StompableType.Average];
        }
        else
        {
            if (item.ContainerTraps.Length == 0)
            {
                return Stompable[StompableType.Good];
            }
            else
            {
                return Stompable[StompableType.Excellent];
            }
        }
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
    public override void EnchantItem(Item item, bool usedOkay, int level, int power)
    {
        if (item.Factory.LevelNormallyFound > 0)
        {
            int chestType = Game.DieRoll(item.Factory.LevelNormallyFound);
            item.ContainerIsOpen = false;
            int chestTrapConfigurationCount = Game.SingletonRepository.Count<ChestTrapConfiguration>();
            int eightFivePercent = chestTrapConfigurationCount * 100 / 85;
            if (chestType > eightFivePercent)
            { 
                int randomRemaining = chestTrapConfigurationCount - eightFivePercent;
                chestType = eightFivePercent + Game.RandomLessThan(randomRemaining);
            }
            item.ContainerTraps = Game.SingletonRepository.Get<ChestTrapConfiguration>(chestType).Traps;
            item.LevelOfObjectsInContainer = chestType;
        }
    }

    /// <summary>
    /// Returns whether or not the chest is small.  Small chests have a 75% chance that the items in the chest are gold.  Large chest always return items.
    /// </summary>
    public abstract bool IsSmall { get; }
    public override int PackSort => 36;

    public override ColorEnum Color => ColorEnum.Grey;
}
