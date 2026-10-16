namespace AngbandOS.Core.Scripts;
internal class InvulnRandomMutationScript : UniversalScript
{
    private InvulnRandomMutationScript(Game game) : base(game) { }

    public override void ExecuteScript()
    {
        if (!Game.HasAntiMagic && Game.DieRoll(5000) == 1)
        {
            Game.Disturb(false);
            Game.MsgPrint("You feel invincible!");
            Game.MsgPrint(string.Empty);
            Game.InvulnerabilityTimer.AddTimer(Game.DieRoll(8) + 8);
        }
    }
}