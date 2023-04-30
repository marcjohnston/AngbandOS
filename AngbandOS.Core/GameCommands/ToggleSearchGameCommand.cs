namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Toggle whether we're automatically searching while moving
    /// </summary>
    [Serializable]
    internal class ToggleSearchGameCommand : GameCommand
    {
        private ToggleSearchGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'S';

        public override bool Execute()
        {
            SaveGame.DoToggleSearch();
            return false;
        }
    }
}
