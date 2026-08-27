namespace AngbandOS.Core.Scripts;
internal class RandomTeleportationRandomMutationScript : UniversalScript, IGetKey
{
    private RandomTeleportationRandomMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;

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