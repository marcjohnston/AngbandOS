// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.Rewards;

[Serializable]
internal class SerUndeReward : Reward
{
    private SerUndeReward(Game game) : base(game) { }
    public override void GetReward(Patron patron)
    {
        Game.MsgPrint($"{patron.ShortName} rewards you with an undead servant!");
        if (!Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, Game.Difficulty, Game.SingletonRepository.Get<MonsterRaceFilter>(nameof(UndeadMonsterRaceFilter)), false, true))
        {
            Game.MsgPrint("Nobody ever turns up...");
        }
    }
}