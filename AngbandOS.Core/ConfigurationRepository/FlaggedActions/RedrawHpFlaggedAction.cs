﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawHpFlaggedAction : FlaggedAction
{
    private const int RowMaxhp = 23;
    private const int RowCurhp = 24;
    private const int ColMaxhp = 0;
    private const int ColCurhp = 0;
    private RedrawHpFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        SaveGame.Screen.Print("Max HP ", RowMaxhp, ColMaxhp);
        string tmp = SaveGame.MaxHealth.ToString().PadLeft(5);
        ColourEnum colour = ColourEnum.BrightGreen;
        SaveGame.Screen.Print(colour, tmp, RowMaxhp, ColMaxhp + 7);
        SaveGame.Screen.Print("Cur HP ", RowCurhp, ColCurhp);
        tmp = SaveGame.Health.ToString().PadLeft(5);
        if (SaveGame.Health >= SaveGame.MaxHealth)
        {
            colour = ColourEnum.BrightGreen;
        }
        else if (SaveGame.Health > SaveGame.MaxHealth * Constants.HitpointWarn / 5)
        {
            colour = ColourEnum.BrightYellow;
        }
        else if (SaveGame.Health > SaveGame.MaxHealth * Constants.HitpointWarn / 10)
        {
            colour = ColourEnum.Orange;
        }
        else
        {
            colour = ColourEnum.BrightRed;
        }
        SaveGame.Screen.Print(colour, tmp, RowCurhp, ColCurhp + 7);
    }
}