// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Rewards;

[Serializable]
internal class SummonMReward : Reward
{
    private SummonMReward(Game game) : base(game) { }
    public override void GetReward(Patron patron)
    {
        Game.MsgPrint($"The voice of {patron.ShortName} booms out:");
        Game.MsgPrint("'My pets, destroy the arrogant mortal!'");
        for (int dummy = 0; dummy < Game.DieRoll(5) + 1; dummy++)
        {
            Game.SummonSpecific(Game.MapY.Value, Game.MapX.Value, Game.Difficulty, null);
        }
    }
}