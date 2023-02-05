namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Destroy a single item
    /// </summary>
    [Serializable]
    internal class DestroyCommand : Command
    {
        private DestroyCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'k';

        public override bool Execute()
        {
            SaveGame.DoCmdDestroy();
            return false;
        }
    }
}
