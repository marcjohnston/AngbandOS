namespace AngbandOS.Core.Commands
{
    [Serializable]
    internal class WalkAndPickupInGameCommand : InGameCommand
    {
        private WalkAndPickupInGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => ';';

        public override int? Repeat => null;

        public override bool Execute()
        {
            return SaveGame.DoCmdWalk(false);
        }
    }
}
