namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class ChestItemClass : ItemFactory
    {
        public ChestItemClass(SaveGame saveGame) : base(saveGame) { }
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Chest;
        public override bool HatesFire => true;
        public override bool HatesAcid => true;

        /// <summary>
        /// Returns whether or not the chest is small.  Small chests have a 75% chance that the items in the chest are gold.  Large chest always return items.
        /// </summary>
        public abstract bool IsSmall { get; }
        public abstract int NumberOfItemsContained { get; }
        public override bool CanAbsorb(Item item, Item other)
        {
            return false;
        }

        public override Colour Colour => Colour.Grey;

        public override bool IsStompable(Item item)
        {
            if (!item.IsKnown())
            {
                return false;
            }
            else if (item.TypeSpecificValue == 0)
            {
                return item.Factory.Stompable[StompableType.Broken];
            }
            else if (item.TypeSpecificValue < 0)
            {
                return item.Factory.Stompable[StompableType.Average];
            }
            else
            {
                if (SaveGame.SingletonRepository.ChestTrapConfigurations[item.TypeSpecificValue].Traps.Length == 0)
                {
                      return item.Factory.Stompable[StompableType.Good];
                }
                else
                {
                    return item.Factory.Stompable[StompableType.Excellent];
                }
            }
        }

        public override string GetDetailedDescription(Item item)
        {
            string s = string.Empty;
            if (!item.IsKnown())
            {
            }
            else if (item.TypeSpecificValue == 0)
            {
                s += " (empty)";
            }
            else if (item.TypeSpecificValue < 0)
            {
                if (SaveGame.SingletonRepository.ChestTrapConfigurations[-item.TypeSpecificValue].IsTrapped)
                {
                    s += " (disarmed)";
                }
                else
                {
                    s += " (unlocked)";
                }
            }
            else
            {
                s += $" {SaveGame.SingletonRepository.ChestTrapConfigurations[item.TypeSpecificValue].Description}";
            }

            // Chests do not have Mods, Damage or Bonus.  We are omitting the description for those features.
            return s;
        }
    }
}
