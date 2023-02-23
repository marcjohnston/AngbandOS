namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Alter a tile in a 'sensibe' way given the tile type
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException"> </exception>
    [Serializable]
    internal class AlterInGameCommand : InGameCommand
    {
        private AlterInGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => '+';

        public override int? Repeat => 99;

        public override bool Execute()
        {
            return SaveGame.DoAlter();
        }
    }
}
