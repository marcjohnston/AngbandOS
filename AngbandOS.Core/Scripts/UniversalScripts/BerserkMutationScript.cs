
namespace AngbandOS.Core.Scripts;
internal class BerserkMutationScript : ActiveMutationScript
{
    private BerserkMutationScript(Game game) : base(game) { }
    public override string Name => "berserk";
    public override void ExecuteScript()
    {
        Game.SuperheroismTimer.AddTimer(base.Game.DieRoll(25) + 25);
        Game.RestoreHealth(30);
        Game.FearTimer.ResetTimer();
    }
}
