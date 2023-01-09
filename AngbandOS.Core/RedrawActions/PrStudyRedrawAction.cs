
namespace AngbandOS.Core.RedrawActions
{
    [Serializable]
    internal class PrStudyRedrawAction : RedrawAction
    {
        private const int RowStudy = 44;
        private const int ColStudy = 60;
        public PrStudyRedrawAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Draw()
        {
            SaveGame.Print(SaveGame.Player.SpareSpellSlots != 0 ? "Study" : "     ", RowStudy, ColStudy);
        }
    }
}
