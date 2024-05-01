// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class AttDemonRandomMutation : Mutation
{
    private AttDemonRandomMutation(Game game) : base(game) { }
    public override int Frequency => 2;
    public override string GainMessage => "You start attracting demons.";
    public override string HaveMessage => "You attract demons.";
    public override string LoseMessage => "You stop attracting demons.";

    public override void ProcessWorld()
    {
        if (Game.HasAntiMagic || base.Game.DieRoll(6666) != 666)
        {
            return;
        }
        bool dSummon;
        if (base.Game.DieRoll(6) == 1)
        {
            dSummon = Game.SummonSpecificFriendly(Game.MapY.IntValue, Game.MapX.IntValue, Game.Difficulty, Game.SingletonRepository.Get<MonsterFilter>(nameof(DemonMonsterFilter)), true);
        }
        else
        {
            dSummon = Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, Game.Difficulty, Game.SingletonRepository.Get<MonsterFilter>(nameof(DemonMonsterFilter)));
        }
        if (!dSummon)
        {
            return;
        }
        Game.MsgPrint("You have attracted a demon!");
        Game.Disturb(false);
    }
}