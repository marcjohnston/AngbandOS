namespace AngbandOS.Core.Scripts;
    [Serializable]
internal class GrowMoldMutationScript : UniversalScript, IGetKey
{
    private GrowMoldMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }
    public override void ExecuteScript()
    {
        for (int i = 0; i < 8; i++)
        {
            Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, Game.ExperienceLevel.IntValue, Game.SingletonRepository.Get<MonsterRaceFilter>(nameof(Bizarre1MonsterRaceFilter)), false, true);
        }
    }
}