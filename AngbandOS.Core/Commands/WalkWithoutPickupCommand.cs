namespace AngbandOS.Core.Commands
{
    [Serializable]
    internal class WalkWithoutPickupCommand : Command
    {
        private WalkWithoutPickupCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => '-';

        public override int? Repeat => null;

        public override bool Execute()
        {
            SaveGame.DoCmdWalk(true);
            return false;
        }
    }
}
