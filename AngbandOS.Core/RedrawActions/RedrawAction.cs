namespace AngbandOS.Core.RedrawActions
{
    [Serializable]
    internal abstract class RedrawAction
    {
        protected SaveGame SaveGame { get; }
        private bool _flag;
        public void Set()
        {
            _flag = true;
        }
        public void Clear()
        {
            _flag = false;
        }
        public bool IsSet => _flag;
        public void Redraw(bool force = false)
        {
            if (IsSet || force)
            {
                Clear();
                Draw();
            }
        }
        protected abstract void Draw();
        public RedrawAction(SaveGame saveGame)
        {
            SaveGame = saveGame;
        }
    }

    [Serializable]
    internal class PrCutRedrawAction : RedrawAction
    {
        private const int RowCut = 43;
        private const int ColCut = 13;
        public PrCutRedrawAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Draw()
        {
            int c = SaveGame.Player.TimedBleeding.TimeRemaining;
            if (c > 1000)
            {
                SaveGame.Print(Colour.BrightRed, "Mortal wound", RowCut, ColCut);
            }
            else if (c > 200)
            {
                SaveGame.Print(Colour.Red, "Deep gash   ", RowCut, ColCut);
            }
            else if (c > 100)
            {
                SaveGame.Print(Colour.Red, "Severe cut  ", RowCut, ColCut);
            }
            else if (c > 50)
            {
                SaveGame.Print(Colour.Orange, "Nasty cut   ", RowCut, ColCut);
            }
            else if (c > 25)
            {
                SaveGame.Print(Colour.Orange, "Bad cut     ", RowCut, ColCut);
            }
            else if (c > 10)
            {
                SaveGame.Print(Colour.Yellow, "Light cut   ", RowCut, ColCut);
            }
            else if (c > 0)
            {
                SaveGame.Print(Colour.Yellow, "Graze       ", RowCut, ColCut);
            }
            else
            {
                SaveGame.Print("            ", RowCut, ColCut);
            }
        }
    }
}
