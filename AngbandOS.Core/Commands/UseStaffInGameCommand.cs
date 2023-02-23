namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Use a staff from the inventory or floor
    /// </summary>
    /// <param name="itemIndex"> The inventory index of the item to use </param>
    [Serializable]
    internal class UseStaffInGameCommand : InGameCommand
    {
        private UseStaffInGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'u';

        public override bool Execute()
        {
            SaveGame.DoUseStaff();
            return false;
        }
    }
}
