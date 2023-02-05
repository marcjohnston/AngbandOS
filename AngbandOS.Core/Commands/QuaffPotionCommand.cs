namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Quaff a potion from the inventory or the ground
    /// </summary>
    /// <param name="itemIndex"> The inventory index of the potion to quaff </param>
    [Serializable]
    internal class QuaffPotionCommand : Command
    {
        private QuaffPotionCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'q';

        public override bool Execute()
        {
            SaveGame.DoCmdQuaff();
            return false;
        }
    }
}
