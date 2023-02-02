
namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class RedrawManaFlaggedAction : FlaggedAction
    {
        private const int ColCursp = 0;
        private const int RowCursp = 26;
        private const int RowMaxsp = 25;
        private const int ColMaxsp = 0;
        public RedrawManaFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            if (SaveGame.Player.BaseCharacterClass.SpellCastingType == CastingType.None)
            {
                return;
            }
            SaveGame.Screen.Print("Max SP ", RowMaxsp, ColMaxsp);
            string tmp = SaveGame.Player.MaxMana.ToString().PadLeft(5);
            Colour colour = Colour.BrightGreen;
            SaveGame.Screen.Print(colour, tmp, RowMaxsp, ColMaxsp + 7);
            SaveGame.Screen.Print("Cur SP ", RowCursp, ColCursp);
            tmp = SaveGame.Player.Mana.ToString().PadLeft(5);
            if (SaveGame.Player.Mana >= SaveGame.Player.MaxMana)
            {
                colour = Colour.BrightGreen;
            }
            else if (SaveGame.Player.Mana > SaveGame.Player.MaxMana * Constants.HitpointWarn / 5)
            {
                colour = Colour.BrightYellow;
            }
            else if (SaveGame.Player.Mana > SaveGame.Player.MaxMana * Constants.HitpointWarn / 10)
            {
                colour = Colour.Orange;
            }
            else
            {
                colour = Colour.BrightRed;
            }
            SaveGame.Screen.Print(colour, tmp, RowCursp, ColCursp + 7);
        }
    }
}
