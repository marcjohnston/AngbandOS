namespace AngbandOS.Core.Commands
{
    [Serializable]
    internal class CastCommand : Command
    {
        private CastCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'm';

        public override bool Execute()
        {
            SaveGame.DoCast();
            return false;
        }
    }
}
