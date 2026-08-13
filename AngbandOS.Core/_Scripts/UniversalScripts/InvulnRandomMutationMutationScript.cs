namespace AngbandOS.Core.Scripts;
internal class InvulnRandomMutationMutationScript : UniversalScript, IGetKey
{
    private InvulnRandomMutationMutationScript(Game game) : base(game) { }
    public string GetKey => throw new NotImplementedException();

    public void Bind(RestoreGameState? restoreGameState) { }

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