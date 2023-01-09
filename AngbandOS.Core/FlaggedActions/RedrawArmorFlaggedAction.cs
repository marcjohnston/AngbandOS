namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class RedrawArmorFlaggedAction : FlaggedAction
    {
        private const int ColAc = 0;
        private const int RowAc = 22;
        public RedrawArmorFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            SaveGame.Print("Cur AC ", RowAc, ColAc);
            string tmp = (SaveGame.Player.DisplayedBaseArmourClass + SaveGame.Player.DisplayedArmourClassBonus).ToString().PadLeft(5);
            SaveGame.Print(Colour.BrightGreen, tmp, RowAc, ColAc + 7);
        }
    }
}
