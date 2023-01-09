
namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class RedrawStunFlaggedAction : FlaggedAction
    {
        private const int ColStun = 0;
        private const int RowStun = 43;
        public RedrawStunFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            int s = SaveGame.Player.TimedStun.TimeRemaining;
            if (s > 100)
            {
                SaveGame.Print(Colour.Red, "Knocked out ", RowStun, ColStun);
            }
            else if (s > 50)
            {
                SaveGame.Print(Colour.Orange, "Heavy stun  ", RowStun, ColStun);
            }
            else if (s > 0)
            {
                SaveGame.Print(Colour.Orange, "Stun        ", RowStun, ColStun);
            }
            else
            {
                SaveGame.Print("            ", RowStun, ColStun);
            }
        }
    }
}
