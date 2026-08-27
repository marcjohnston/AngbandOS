namespace AngbandOS.Core.Scripts;
internal class PanicHitMutationScript : ActiveMutationScript
{
    private PanicHitMutationScript(Game game) : base(game) { }
    public override string Name => "panic hit";
    public override void ExecuteScript()
    {
        if (!Game.GetDirectionNoAim(out int dir))
        {
            return;
        }
        int y = Game.MapY.IntValue + Game.KeypadDirectionYOffset[dir];
        int x = Game.MapX.IntValue + Game.KeypadDirectionXOffset[dir];
        if (Game.Grid[y][x].Monster is not null)
        {
            Game.PlayerAttackMonster(y, x);
            Game.RunScript(nameof(TeleportSelf30TeleportSelfScript));
        }
        else
        {
            Game.MsgPrint("You don't see any monster in this direction");
            Game.MsgPrint(string.Empty);
        }
    }
}