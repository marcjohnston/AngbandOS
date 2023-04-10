namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class ChestItem : Item
    {
        public ChestItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }

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
        public override void ApplyMagic(int level, int power)
        {
            if (Factory.Level > 0)
            {
                TypeSpecificValue = Program.Rng.DieRoll(Factory.Level);
                if (TypeSpecificValue > 55)
                {
                    int chestTrapConfigurationCount = SaveGame.SingletonRepository.ChestTrapConfigurations.Count;
                    int randomRemaining = chestTrapConfigurationCount - 55;
                    TypeSpecificValue = (55 + Program.Rng.RandomLessThan(randomRemaining));
                }
            }
        }
    }
}