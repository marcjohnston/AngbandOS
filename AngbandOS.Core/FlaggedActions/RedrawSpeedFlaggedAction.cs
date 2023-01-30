
namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class RedrawSpeedFlaggedAction : FlaggedAction
    {
        private const int ColSpeed = 43;
        private const int RowSpeed = 44;
        public RedrawSpeedFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            int i = SaveGame.Player.Speed;
            Colour attr = Colour.White;
            string buf = "";
            if (SaveGame.Player.IsSearching)
            {
                i += 10;
            }
            int energy = Constants.ExtractEnergy[i];
            if (i > 110)
            {
                attr = Colour.BrightGreen;
                buf = $"Fast {energy / 10.0}";
            }
            else if (i < 110)
            {
                attr = Colour.BrightBrown;
                buf = $"Slow {energy / 10.0}";
            }
            SaveGame.Screen.Print(attr, buf.PadRight(14), RowSpeed, ColSpeed);
        }
    }
}
