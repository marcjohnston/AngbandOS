namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class ChestItemClass : ItemClass
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
                return item.BaseItemCategory.Stompable[StompableType.Broken];
            }
            else if (item.TypeSpecificValue < 0)
            {
                return item.BaseItemCategory.Stompable[StompableType.Average];
            }
            else
            {
                if (SaveGame.SingletonRepository.ChestTrapConfigurations[item.TypeSpecificValue].Traps.Length == 0)
                {
                      return item.BaseItemCategory.Stompable[StompableType.Good];
                }
                else
                {
                    return item.BaseItemCategory.Stompable[StompableType.Excellent];
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

        /// <summary>
        /// Assigns the TypeSpecificValue for this chest.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="level"></param>
        /// <param name="power"></param>
        /// <remarks>
        /// Logic:
        /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
        /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
        /// </remarks>
        public override void ApplyMagic(Item item, int level, int power)
        {
            if (item.BaseItemCategory.Level > 0)
            {
                item.TypeSpecificValue = Program.Rng.DieRoll(item.BaseItemCategory.Level);
                if (item.TypeSpecificValue > 55)
                {
                    int chestTrapConfigurationCount = SaveGame.SingletonRepository.ChestTrapConfigurations.Count;
                    int randomRemaining = chestTrapConfigurationCount - 55;
                    item.TypeSpecificValue = (55 + Program.Rng.RandomLessThan(randomRemaining));
                }
            }
        }
        public override int PackSort => 36;
    }
}
