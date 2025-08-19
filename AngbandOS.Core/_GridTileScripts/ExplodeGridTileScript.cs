// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.GridTileEffects;

[Serializable]
internal class ExplodeGridTileScript : GridTileScript
{
    private ExplodeGridTileScript(Game game) : base(game) { } // This object is a singleton.

    public override (IsNoticedEnum, DestroysContentsEnum) Apply(int x, int y)
    {
        Game.RunScript(nameof(ThereIsASuddenExplosionRenderMessageScript));
        Game.TakeHit(Game.DiceRoll(5, 8), "an exploding chest");
        return (IsNoticedEnum.True, DestroysContentsEnum.True);
    }
}
