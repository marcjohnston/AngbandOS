namespace AngbandOS.Core.Scripts;
internal class DazzleMutationScript : ActiveMutationScript
{
    private DazzleMutationScript(Game game) : base(game) { }
    public override string Name => "dazzle";
    public override void ExecuteScript()
    {
        Game.RunScript(nameof(StunAtLos1xProjectileScript));
        Game.RunScript(nameof(OldConfuseAtLos4xProjectileScript));
        Game.RunScript(nameof(TurnAllAtLos4xProjectileScript));
    }
}