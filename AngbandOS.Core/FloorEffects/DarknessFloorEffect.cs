// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.FloorEffects;

[Serializable]
internal class DarknessFloorEffect : FloorEffect
{
    private DarknessFloorEffect(Game game) : base(game) { } // This object is a singleton.

    public override bool Apply(int x, int y)
    {
        GridTile cPtr = Game.Map.Grid[y][x];
        bool obvious = Game.PlayerCanSeeBold(y, x);
        cPtr.SelfLit = false;
        if (cPtr.FeatureType.IsOpenFloor)
        {
            cPtr.PlayerMemorized = false;
            Game.NoteSpot(y, x);
        }
        Game.ConsoleView.RefreshMapLocation(y, x);
        if (cPtr.MonsterIndex != 0)
        {
            Game.UpdateMonsterVisibility(cPtr.MonsterIndex, false);
        }
        return obvious;
    }
}
