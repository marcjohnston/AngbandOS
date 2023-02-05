namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Throw an item
    /// </summary>
    [Serializable]
    internal class ThrowCommand : Command
    {
        private ThrowCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'v';

        public override bool Execute()
        {
            SaveGame.DoCmdThrow(1);
            return false;
        }
    }
}
