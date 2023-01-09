
namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class RedrawAfraidFlaggedAction : FlaggedAction
    {
        private const int ColAfraid = 25;
        private const int RowAfraid = 44;
        public RedrawAfraidFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            if (SaveGame.Player.TimedFear.TimeRemaining > 0)
            {
                SaveGame.Print(Colour.Orange, "Afraid", RowAfraid, ColAfraid);
            }
            else
            {
                SaveGame.Print("      ", RowAfraid, ColAfraid);
            }
        }
    }
}
