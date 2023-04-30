namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Use a staff from the inventory or floor
    /// </summary>
    /// <param name="itemIndex"> The inventory index of the item to use </param>
    [Serializable]
    internal class UseStaffGameCommand : GameCommand
    {
        private UseStaffGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'u';

        public override bool Execute()
        {
            SaveGame.DoUseStaff();
            return false;
        }
    }
}
