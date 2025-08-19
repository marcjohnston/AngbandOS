// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.GridTileEffects;

[Serializable]
internal class LightWeakGridTileEffect : GridTileEffect
{
    private LightWeakGridTileEffect(Game game) : base(game) { } // This object is a singleton.

    public override IsNoticedEnum Apply(int x, int y)
    {
        GridTile cPtr = Game.Map.Grid[y][x];
        IsNoticedEnum isNoticed = IsNoticedEnum.False;
        cPtr.SelfLit = true;
        Game.NoteSpot(y, x);
        Game.ConsoleView.RefreshMapLocation(y, x);
        if (Game.PlayerCanSeeBold(y, x))
        {
            isNoticed = IsNoticedEnum.True;
        }
        if (cPtr.MonsterIndex != 0)
        {
            Game.UpdateMonsterVisibility(cPtr.MonsterIndex, false);
        }
        return isNoticed;
    }
}
