// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

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
        if (SaveGame.BaseCharacterClass.SpellCastingType == null)
        {
            return;
        }
        SaveGame.Screen.Print("Max SP ", RowMaxsp, ColMaxsp);
        string tmp = SaveGame.MaxMana.ToString().PadLeft(5);
        ColourEnum colour = ColourEnum.BrightGreen;
        SaveGame.Screen.Print(colour, tmp, RowMaxsp, ColMaxsp + 7);
        SaveGame.Screen.Print("Cur SP ", RowCursp, ColCursp);
        tmp = SaveGame.Mana.ToString().PadLeft(5);
        if (SaveGame.Mana >= SaveGame.MaxMana)
        {
            colour = ColourEnum.BrightGreen;
        }
        else if (SaveGame.Mana > SaveGame.MaxMana * Constants.HitpointWarn / 5)
        {
            colour = ColourEnum.BrightYellow;
        }
        else if (SaveGame.Mana > SaveGame.MaxMana * Constants.HitpointWarn / 10)
        {
            colour = ColourEnum.Orange;
        }
        else
        {
            colour = ColourEnum.BrightRed;
        }
        SaveGame.Screen.Print(colour, tmp, RowCursp, ColCursp + 7);
    }
}
