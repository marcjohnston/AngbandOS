// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawAfraidFlaggedAction : FlaggedAction
{
    private const int ColAfraid = 25;
    private const int RowAfraid = 44;
    private RedrawAfraidFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        if (SaveGame.FearTimer.Value > 0)
        {
            SaveGame.Screen.Print(ColorEnum.Orange, "Afraid", RowAfraid, ColAfraid);
        }
        else
        {
            SaveGame.Screen.Print("      ", RowAfraid, ColAfraid);
        }
    }
}
