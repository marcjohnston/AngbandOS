// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawDTrapFlaggedAction : FlaggedAction
{
    private const int ColDtrap = 53;
    private const int RowDtrap = 44;
    private RedrawDTrapFlaggedAction(Game game) : base(game) { }
    protected override void Execute()
    {
        if (!Game.Grid[Game.MapY.Value][Game.MapX.Value].TrapsDetected)
        {
            Game.Screen.Print(ColorEnum.Green, "     ", RowDtrap, ColDtrap);
            return;
        }
        int count = Game.CountTraps(Game.MapX.Value, Game.MapY.Value);
        if (count == 4)
        {
            Game.Screen.Print(ColorEnum.Green, "DTrap", RowDtrap, ColDtrap);
        }
        else
        {
            Game.Screen.Print(ColorEnum.Yellow, "DTRAP", RowDtrap, ColDtrap);
        }
    }
}
