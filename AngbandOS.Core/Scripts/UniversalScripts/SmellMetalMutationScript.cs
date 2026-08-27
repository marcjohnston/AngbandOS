namespace AngbandOS.Core.Scripts;
internal class SmellMetalMutationScript : ActiveMutationScript
{
    private SmellMetalMutationScript(Game game) : base(game) { }
    public override string Name => "smell metal";
    public override void ExecuteScript()
    {
        Game.DetectTreasure();
    }
}