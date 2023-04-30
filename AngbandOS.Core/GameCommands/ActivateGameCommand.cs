namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Activate an artifact or similar
    /// </summary>
    /// <param name="itemIndex">
    /// The inventory index of the item to be activated, or -999 to select item
    /// </param>
    [Serializable]
    internal class ActivateGameCommand : GameCommand
    {
        private ActivateGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'A';

        public override int? Repeat => 0;

        public override bool Execute()
        {
            SaveGame.DoActivate();
            return false;
        }
    }
}
