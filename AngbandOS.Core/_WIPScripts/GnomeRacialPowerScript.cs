namespace AngbandOS.Core.Scripts;

// Gnomes can do a short-range teleport
[Serializable]
internal class GnomeRacialPowerScript : Script, IScript
{
    private GnomeRacialPowerScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        Game.MsgPrint("Blink!");
        Game.RunScript(nameof(TeleportSelf10P1xTeleportSelfScript));
    }
}