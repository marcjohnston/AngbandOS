// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class AttDragonRandomMutation : Mutation
{
    private AttDragonRandomMutation(Game game) : base(game) { }
    public override int Frequency => 1;
    public override string GainMessage => "You start attracting dragons.";
    public override string HaveMessage => "You attract dragons.";
    public override string LoseMessage => "You stop attracting dragons.";

    public override void ProcessWorld()
    {
        if (Game.HasAntiMagic || base.Game.DieRoll(3000) != 13)
        {
            return;
        }
        bool dSummon;
        if (base.Game.DieRoll(5) == 1)
        {
            dSummon = Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, Game.Difficulty, Game.SingletonRepository.Get<MonsterRaceFilter>(nameof(DragonMonsterRaceFilter)), true, true);
        }
        else
        {
            dSummon = Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, Game.Difficulty, Game.SingletonRepository.Get<MonsterRaceFilter>(nameof(DragonMonsterRaceFilter)), true, false);
        }
        if (!dSummon)
        {
            return;
        }
        Game.MsgPrint("You have attracted a dragon!");
        Game.Disturb(false);
    }
}