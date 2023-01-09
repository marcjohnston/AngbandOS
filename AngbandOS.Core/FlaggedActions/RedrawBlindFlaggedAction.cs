
namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class RedrawBlindFlaggedAction : FlaggedAction
    {
        private const int ColBlind = 8;
        private const int RowBlind = 44;
        public RedrawBlindFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            if (SaveGame.Player.TimedBlindness.TimeRemaining > 0)
            {
                SaveGame.Print(Colour.Orange, "Blind", RowBlind, ColBlind);
            }
            else
            {
                SaveGame.Print("     ", RowBlind, ColBlind);
            }
        }
    }
}
