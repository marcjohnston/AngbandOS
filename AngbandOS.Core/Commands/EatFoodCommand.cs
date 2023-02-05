namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Eat some food
    /// </summary>
    /// <param name="itemIndex"> The inventory index of the food item </param>
    [Serializable]
    internal class EatFoodCommand : Command
    {
        private EatFoodCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'E';

        public override bool Execute()
        {
            SaveGame.DoEatCmd();
            return false;
        }
    }
}
