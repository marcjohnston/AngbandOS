namespace AngbandOS.Core.Scripts;
internal class AttDragonRandomMutationMutationScript : UniversalScript, IGetKey
{
    private AttDragonRandomMutationMutationScript(Game game) : base(game) { }
    public string GetKey => throw new NotImplementedException();

    public void Bind(RestoreGameState? restoreGameState) { }

    public override void ExecuteScript()
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