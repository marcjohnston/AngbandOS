namespace AngbandOS.Core.Scripts;
internal class HalluRandomMutationScript : UniversalScript
{
    private HalluRandomMutationScript(Game game) : base(game) { }

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