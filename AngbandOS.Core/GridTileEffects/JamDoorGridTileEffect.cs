// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.GridTileEffects;

[Serializable]
internal class JamDoorGridTileEffect : GridTileEffect
{
    private JamDoorGridTileEffect(Game game) : base(game) { } // This object is a singleton.

    public override IsNoticedEnum Apply(int x, int y)
    {
        GridTile cPtr = Game.Map.Grid[y][x];
        IsNoticedEnum isNoticed = IsNoticedEnum.False;
        if (cPtr.FeatureType.IsVisibleDoor)
        {
            Tile? jammedTile = cPtr.FeatureType.OnJammedTile;
            if (jammedTile == null)
            {
                throw new Exception("No jammed door specified.");
            }
            cPtr.SetFeature(jammedTile);
            if (Game.GridTileIsVisible(y, x))
            {
                Game.MsgPrint("The door seems stuck.");
                isNoticed = IsNoticedEnum.True;
            }
        }
        return isNoticed;
    }
}
