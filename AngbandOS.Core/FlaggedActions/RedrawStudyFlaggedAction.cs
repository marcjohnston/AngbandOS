// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawStudyFlaggedAction : FlaggedAction
{
    private const int RowStudy = 44;
    private const int ColStudy = 60;
    private RedrawStudyFlaggedAction(Game game) : base(game) { }
    protected override void Execute()
    {
        Game.Screen.Print(Game.SpareSpellSlots.Value != 0 ? "Study" : "     ", RowStudy, ColStudy);
    }
}
