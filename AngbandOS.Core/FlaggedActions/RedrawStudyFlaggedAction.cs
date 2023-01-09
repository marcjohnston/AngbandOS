
namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class RedrawStudyFlaggedAction : FlaggedAction
    {
        private const int RowStudy = 44;
        private const int ColStudy = 60;
        public RedrawStudyFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            SaveGame.Print(SaveGame.Player.SpareSpellSlots != 0 ? "Study" : "     ", RowStudy, ColStudy);
        }
    }
}
