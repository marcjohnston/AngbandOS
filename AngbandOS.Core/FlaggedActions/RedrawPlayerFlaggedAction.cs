
namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class RedrawPlayerFlaggedAction : FlaggedAction
    {
        private const int ColName = 0;
        private const int RowName = 1;
        private const int ColRace = 0;
        private const int RowRace = 2;
        private const int ColClass = 0;
        private const int RowClass = 3;
        public RedrawPlayerFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        private void PrtField(string info, int row, int col) // TODO: Duplicate with PrTitleRedrawAction
        {
            SaveGame.Screen.Print(Colour.White, "             ", row, col);
            SaveGame.Screen.Print(Colour.BrightBlue, info, row, col);
        }
        protected override void Execute()
        {
            PrtField(SaveGame.Player.Name, RowName, ColName);
            PrtField(SaveGame.Player.Race.Title, RowRace, ColRace);
            PrtField(Profession.ClassSubName(SaveGame.Player.ProfessionIndex, SaveGame.Player.Realm1), RowClass, ColClass);
        }
    }
}
