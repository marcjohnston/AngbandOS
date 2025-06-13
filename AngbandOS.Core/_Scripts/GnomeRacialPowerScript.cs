namespace AngbandOS.Core.Scripts;

// Gnomes can do a short-range teleport
[Serializable]
internal class GnomeRacialPowerScript : Script, IScript
{
    private GnomeRacialPowerScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        Game.MsgPrint("Blink!");
        Game.RunScriptInt(nameof(TeleportSelfScript), 10 + Game.ExperienceLevel.IntValue);
    }
}