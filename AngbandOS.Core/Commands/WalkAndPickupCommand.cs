namespace AngbandOS.Core.Commands
{
    [Serializable]
    internal class WalkAndPickupCommand : Command
    {
        private WalkAndPickupCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => ';';

        public override int? Repeat => null;

        public override bool Execute()
        {
            return SaveGame.DoCmdWalk(false);
        }
    }
}
