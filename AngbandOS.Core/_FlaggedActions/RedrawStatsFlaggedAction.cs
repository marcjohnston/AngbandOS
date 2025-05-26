// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawStatsFlaggedAction : FlaggedAction
{
    private const int RowStat = 15;
    private const int ColStat = 6;
    private RedrawStatsFlaggedAction(Game game) : base(game) { }
    private void PrtStat(Ability stat, int rowOffset)
    {
        if (stat.Innate < stat.InnateMax)
        {
            Game.Screen.Print(stat.NameReduced, RowStat + rowOffset, 0);
            string tmp = stat.Adjusted.StatToString();
            Game.Screen.Print(ColorEnum.Yellow, tmp, RowStat + rowOffset, ColStat);
        }
        else
        {
            Game.Screen.Print(stat.Name, RowStat + rowOffset, 0);
            string tmp = stat.Adjusted.StatToString();
            Game.Screen.Print(ColorEnum.BrightGreen, tmp, RowStat + rowOffset, ColStat);
        }
        if (stat.InnateMax == 18 + 100)
        {
            Game.Screen.Print("!", RowStat + rowOffset, 3);
        }
    }

    protected override void Execute()
    {
        PrtStat(Game.StrengthAbility, 0);
        PrtStat(Game.IntelligenceAbility, 1);
        PrtStat(Game.WisdomAbility, 2);
        PrtStat(Game.DexterityAbility, 3);
        PrtStat(Game.ConstitutionAbility, 4);
        PrtStat(Game.CharismaAbility, 5);
    }
}
