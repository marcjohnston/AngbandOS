namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Drop an item
    /// </summary>
    [Serializable]
    internal class DropInGameCommand : InGameCommand
    {
        private DropInGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'd';

        public override bool Execute()
        {
            SaveGame.DoDropCmd();
            return false;
        }
    }
}