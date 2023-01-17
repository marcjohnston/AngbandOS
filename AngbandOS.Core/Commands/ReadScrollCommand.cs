namespace AngbandOS.Commands
{
    /// <summary>
    /// Read a scroll from the inventory or floor
    /// </summary>
    /// <param name="itemIndex"> The inventory index of the scroll to be read </param>
    [Serializable]
    internal class ReadScrollCommand : Command
    {
        private ReadScrollCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'r';

        public override bool Execute()
        {
            SaveGame.DoCmdReadScroll();
            return false;
        }
    }
}
