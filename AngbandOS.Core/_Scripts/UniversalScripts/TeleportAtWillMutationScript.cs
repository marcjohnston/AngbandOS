namespace AngbandOS.Core.Scripts;
internal class TeleportAtWillMutationScript : ActiveMutationScript
{
    private TeleportAtWillMutationScript(Game game) : base(game) { }
    public override string Name => "teleport";
    public override void ExecuteScript()
    {
        Game.MsgPrint("You concentrate...");
        Game.RunScript(nameof(TeleportSelf10P4xTeleportSelfScript));
    }
}