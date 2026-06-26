// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Rewards;

internal class PolyWndReward : Reward
{
    private PolyWndReward(Game game) : base(game) { }
    public override void GetReward(Patron patron)
    {
        Game.MsgPrint($"You feel the power of {patron.ShortName} touch you.");
        Game.RunScript(nameof(PolymorphWoundsScript));
    }
}