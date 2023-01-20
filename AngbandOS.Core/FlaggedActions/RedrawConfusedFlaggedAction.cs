
namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class RedrawConfusedFlaggedAction : FlaggedAction
    {
        private const int ColConfused = 15;
        private const int RowConfused = 44;
        public RedrawConfusedFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            if (SaveGame.Player.TimedConfusion.TimeRemaining > 0)
            {
                SaveGame.Screen.Print(Colour.Orange, "Confused", RowConfused, ColConfused);
            }
            else
            {
                SaveGame.Screen.Print("        ", RowConfused, ColConfused);
            }
        }
    }
}
