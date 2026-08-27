
namespace AngbandOS.Core.Scripts;

internal class BlinkMutationScript : ActiveMutationScript
{
    private BlinkMutationScript(Game game) : base(game) { }
    public override string Name => "blink";
    public override void ExecuteScript()
    {
        Game.RunScript(nameof(TeleportSelf10TeleportSelfScript));
    }
}