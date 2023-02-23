namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Stand still for a turn and pick up any items
    /// </summary>
    [Serializable]
    internal class StayAndPickupInGameCommand : InGameCommand
    {
        private StayAndPickupInGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => ',';

        public override int? Repeat => null;

        public override bool Execute()
        {
            SaveGame.DoCmdStay(true);
            return false;
        }
    }
}
