namespace AngbandOS.Commands
{
    [Serializable]
    internal class SpaceCommand : Command
    {
        private SpaceCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => ' ';

        public override bool Execute()
        {
            return false;
        }
    }
}
