namespace AngbandOS.Core.Scripts;
internal class AttDemonRandomMutationMutationScript : UniversalScript, IGetKey
{
    private AttDemonRandomMutationMutationScript(Game game) : base(game) { }
    public string GetKey => throw new NotImplementedException();

    public void Bind(RestoreGameState? restoreGameState) { }

    public override void ExecuteScript()
    {
        if (Game.HasAntiMagic || base.Game.DieRoll(6666) != 666)
        {
            return;
        }
        bool dSummon;
        if (base.Game.DieRoll(6) == 1)
        {
            dSummon = Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, Game.Difficulty, Game.SingletonRepository.Get<MonsterRaceFilter>(nameof(DemonMonsterRaceFilter)), true, true);
        }
        else
        {
            dSummon = Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, Game.Difficulty, Game.SingletonRepository.Get<MonsterRaceFilter>(nameof(DemonMonsterRaceFilter)), true, false);
        }
        if (!dSummon)
        {
            return;
        }
        Game.MsgPrint("You have attracted a demon!");
        Game.Disturb(false);
    }
}