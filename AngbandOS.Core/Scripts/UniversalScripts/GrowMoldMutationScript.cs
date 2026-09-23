namespace AngbandOS.Core.Scripts;
internal class GrowMoldMutationScript : ActiveMutationScript
{
    private GrowMoldMutationScript(Game game) : base(game) { }
    public override string Name => "grow mold";
    public override void ExecuteScript()
    {
        for (int i = 0; i < 8; i++)
        {
            Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, Game.ExperienceLevel.IntValue, Game.SingletonRepository.Get<MonsterRaceFilter>(nameof(Bizarre1MonsterRaceFilter)), false, true);
        }
    }
}