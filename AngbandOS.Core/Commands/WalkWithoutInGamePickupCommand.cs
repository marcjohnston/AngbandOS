namespace AngbandOS.Core.Commands
{
    [Serializable]
    internal class WalkWithoutInGamePickupCommand : InGameCommand
    {
        private WalkWithoutInGamePickupCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => '-';

        public override int? Repeat => null;

        public override bool Execute()
        {
            SaveGame.DoCmdWalk(true);
            return false;
        }
    }
}
