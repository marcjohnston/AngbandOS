
namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class RedrawPoisonedFlaggedAction : FlaggedAction
    {
        private const int ColPoisoned = 33;
        private const int RowPoisoned = 44;
        public RedrawPoisonedFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            if (SaveGame.Player.TimedPoison.TimeRemaining > 0)
            {
                SaveGame.Screen.Print(Colour.Orange, "Poisoned", RowPoisoned, ColPoisoned);
            }
            else
            {
                SaveGame.Screen.Print("        ", RowPoisoned, ColPoisoned);
            }
        }
    }
}
