// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.GridTileEffects;

[Serializable]
internal class MakeTrapGridTileScript : GridTileScript
{
    private MakeTrapGridTileScript(Game game) : base(game) { } // This object is a singleton.

    public override (IsNoticedEnum, DestroysContentsEnum) Apply(int x, int y)
    {
        if (Game.GridOpenNoItemOrCreature(y, x))
        {
            Game.PlaceTrap(y, x);
        }
        return (IsNoticedEnum.False, DestroysContentsEnum.False);
    }
}
