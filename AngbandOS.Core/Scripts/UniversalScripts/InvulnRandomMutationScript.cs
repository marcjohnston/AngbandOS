namespace AngbandOS.Core.Scripts;
internal class InvulnRandomMutationScript : UniversalScript, IGetKey
{
    private InvulnRandomMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;

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