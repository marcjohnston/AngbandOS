namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Wield/wear an item
    /// </summary>
    [Serializable]
    internal class WieldInGameCommand : InGameCommand
    {
        private WieldInGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'w';

        public override bool Execute()
        {
            SaveGame.DoCmdWield();
            return false;
        }
    }
}
