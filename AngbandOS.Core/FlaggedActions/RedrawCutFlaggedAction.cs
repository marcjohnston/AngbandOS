﻿namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class RedrawCutFlaggedAction : FlaggedAction
    {
        private const int RowCut = 43;
        private const int ColCut = 13;
        public RedrawCutFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            int c = SaveGame.Player.TimedBleeding.TimeRemaining;
            if (c > 1000)
            {
                SaveGame.Screen.Print(Colour.BrightRed, "Mortal wound", RowCut, ColCut);
            }
            else if (c > 200)
            {
                SaveGame.Screen.Print(Colour.Red, "Deep gash   ", RowCut, ColCut);
            }
            else if (c > 100)
            {
                SaveGame.Screen.Print(Colour.Red, "Severe cut  ", RowCut, ColCut);
            }
            else if (c > 50)
            {
                SaveGame.Screen.Print(Colour.Orange, "Nasty cut   ", RowCut, ColCut);
            }
            else if (c > 25)
            {
                SaveGame.Screen.Print(Colour.Orange, "Bad cut     ", RowCut, ColCut);
            }
            else if (c > 10)
            {
                SaveGame.Screen.Print(Colour.Yellow, "Light cut   ", RowCut, ColCut);
            }
            else if (c > 0)
            {
                SaveGame.Screen.Print(Colour.Yellow, "Graze       ", RowCut, ColCut);
            }
            else
            {
                SaveGame.Screen.Print("            ", RowCut, ColCut);
            }
        }
    }
}