// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.Rewards;

[Serializable]
internal class GainAblReward : Reward
{
    private GainAblReward(Game game) : base(game) { }
    public override void GetReward(Patron patron)
    {
        Game.MsgPrint($"The voice of {patron.ShortName} rings out:");
        Game.MsgPrint("'Stay, mortal, and let me mould thee.'");
        if (Game.DieRoll(3) == 1 && !(patron.PreferredAbility < 0))
        {
            Game.TryIncreasingAbilityScore(patron.PreferredAbility);
        }
        else
        {
            Game.TryIncreasingAbilityScore(Game.DieRoll(6) - 1);
        }
    }
}