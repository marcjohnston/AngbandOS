
namespace AngbandOS.Core.RedrawActions
{
    [Serializable]
    internal class PrStateRedrawAction : RedrawAction
    {
        private const int ColState = 27;
        private const int RowState = 43;
        public PrStateRedrawAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Draw()
        {
            Colour attr = Colour.White;
            string text;
            if (SaveGame.Player.TimedParalysis.TimeRemaining > 0)
            {
                attr = Colour.Red;
                text = "Paralyzed!";
            }
            else if (SaveGame.Resting != 0)
            {
                text = "Rest ";
                if (SaveGame.Resting > 0)
                {
                    text += SaveGame.Resting.ToString().PadLeft(5);
                }
                else if (SaveGame.Resting == -1)
                {
                    text += "*****";
                }
                else if (SaveGame.Resting == -2)
                {
                    text += "&&&&&";
                }
                else
                {
                    text += "?????";
                }
            }
            else if (SaveGame.CommandRepeat != 0)
            {
                if (SaveGame.CommandRepeat > 999)
                {
                    text = "Rep. " + SaveGame.CommandRepeat.ToString().PadRight(5);
                }
                else
                {
                    text = "Repeat " + SaveGame.CommandRepeat.ToString().PadRight(3);
                }
            }
            else if (SaveGame.Player.IsSearching)
            {
                text = "Searching ";
            }
            else
            {
                text = "          ";
            }
            SaveGame.Print(attr, text, RowState, ColState);
        }
    }
}
