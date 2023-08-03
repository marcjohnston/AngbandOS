// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RemoveViewFlaggedAction : FlaggedAction
{
    private RemoveViewFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        foreach (GridCoordinate gridCoordinate in SaveGame.View)
        {
            GridTile cPtr = SaveGame.Grid[gridCoordinate.Y][gridCoordinate.X];
            cPtr.TileFlags.Clear(GridTile.IsVisible);
            SaveGame.RedrawSingleLocation(gridCoordinate.Y, gridCoordinate.X);
        }
        SaveGame.View.Clear();
    }
}
