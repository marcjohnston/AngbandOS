namespace AngbandOS.Core.Scripts;
internal class RandomTeleportationRandomMutationMutationScript : UniversalScript, IGetKey
{
    private RandomTeleportationRandomMutationMutationScript(Game game) : base(game) { }
    public string GetKey => throw new NotImplementedException();

    public void Bind(RestoreGameState? restoreGameState) { }

    public override void ExecuteScript()
    {
        if (base.Game.DieRoll(5000) != 88)
        {
            return;
        }
        if (Game.HasNexusResistance || Game.HasAntiTeleport)
        {
            return;
        }
        Game.Disturb(false);
        Game.MsgPrint("Your position suddenly seems very uncertain...");
        Game.MsgPrint(string.Empty);
        Game.RunScript(nameof(TeleportSelf40TeleportSelfScript));
    }
}