namespace AngbandOS.Core.Scripts;
internal class HalluRandomMutationScript : UniversalScript, IGetKey
{
    private HalluRandomMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind(RestoreGameState? restoreGameState) { }

    public override void ExecuteScript()
    {
        if (base.Game.DieRoll(6400) != 42)
        {
            return;
        }
        if (Game.HasChaosResistance)
        {
            return;
        }
        Game.Disturb(false);
        Game.SingletonRepository.Get<FlaggedAction>(nameof(PrExtraRedrawActionGroupSetFlaggedAction)).Set();
        Game.HallucinationsTimer.AddTimer(base.Game.RandomLessThan(50) + 20);
    }
}