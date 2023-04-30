namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Destroy a single item
    /// </summary>
    [Serializable]
    internal class DestroyGameCommand : GameCommand
    {
        private DestroyGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'k';

        public override bool Execute()
        {
            SaveGame.DoCmdDestroy();
            return false;
        }
    }
}
