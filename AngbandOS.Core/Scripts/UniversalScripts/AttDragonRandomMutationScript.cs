namespace AngbandOS.Core.Scripts;
internal class AttDragonRandomMutationScript : UniversalScript, IGetKey
{
    private AttDragonRandomMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;

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