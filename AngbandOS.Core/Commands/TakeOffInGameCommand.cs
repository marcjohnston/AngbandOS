namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Take off an item
    /// </summary>
    [Serializable]
    internal class TakeOffInGameCommand : InGameCommand
    {
        private TakeOffInGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 't';

        public override bool Execute()
        {
            SaveGame.DoCmdTakeOff();
            return false;
        }
    }
}
