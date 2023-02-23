namespace AngbandOS.Core.Commands
{
    [Serializable]
    internal class SpaceInGameCommand : InGameCommand
    {
        private SpaceInGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => ' ';

        public override bool Execute()
        {
            return false;
        }
    }
}
