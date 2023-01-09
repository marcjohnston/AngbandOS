namespace AngbandOS.Core.RedrawActions
{
    [Serializable]
    internal class PrArmorRedrawAction : RedrawAction
    {
        private const int ColAc = 0;
        private const int RowAc = 22;
        public PrArmorRedrawAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Draw()
        {
            SaveGame.Print("Cur AC ", RowAc, ColAc);
            string tmp = (SaveGame.Player.DisplayedBaseArmourClass + SaveGame.Player.DisplayedArmourClassBonus).ToString().PadLeft(5);
            SaveGame.Print(Colour.BrightGreen, tmp, RowAc, ColAc + 7);
        }
    }
}
