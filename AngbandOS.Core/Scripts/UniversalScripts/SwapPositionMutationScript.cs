namespace AngbandOS.Core.Scripts;
internal class SwapPositionMutationScript : ActiveMutationScript
{
    private SwapPositionMutationScript(Game game) : base(game) { }
    public override string Name => "sterilize";
    public override void ExecuteScript()
    {
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        Game.TeleportSwap(dir);
    }
}