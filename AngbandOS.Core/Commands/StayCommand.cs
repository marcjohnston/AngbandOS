namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Stand still for a turn without picking up any items
    /// </summary>
    [Serializable]
    internal class StayCommand : Command
    {
        private StayCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'g';

        public override int? Repeat => null;

        public override bool Execute()
        {
            SaveGame.DoCmdStay(false);
            return false;
        }
    }
}
