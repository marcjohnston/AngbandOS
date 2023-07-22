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
    public RedrawDTrapFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        int count = 0;
        if (SaveGame.Level.Grid[SaveGame.MapY][SaveGame.MapX].TileFlags.IsClear(GridTile.TrapsDetected))
        {
            SaveGame.Screen.Print(ColourEnum.Green, "     ", RowDtrap, ColDtrap);
            return;
        }
        if (SaveGame.Level.Grid[SaveGame.MapY - 1][SaveGame.MapX].TileFlags.IsSet(GridTile.TrapsDetected))
        {
            count++;
        }
        if (SaveGame.Level.Grid[SaveGame.MapY + 1][SaveGame.MapX].TileFlags.IsSet(GridTile.TrapsDetected))
        {
            count++;
        }
        if (SaveGame.Level.Grid[SaveGame.MapY][SaveGame.MapX - 1].TileFlags.IsSet(GridTile.TrapsDetected))
        {
            count++;
        }
        if (SaveGame.Level.Grid[SaveGame.MapY][SaveGame.MapX + 1].TileFlags.IsSet(GridTile.TrapsDetected))
        {
            count++;
        }
        if (count == 4)
        {
            SaveGame.Screen.Print(ColourEnum.Green, "DTrap", RowDtrap, ColDtrap);
        }
        else
        {
            SaveGame.Screen.Print(ColourEnum.Yellow, "DTRAP", RowDtrap, ColDtrap);
        }
    }
}
