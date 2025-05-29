namespace AngbandOS.Core.Scripts;

// Half-Titans can probe enemies
[Serializable]
internal class HalfTitanRacialPowerScript : Script, IScript
{
    private HalfTitanRacialPowerScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        Game.MsgPrint("You examine your foes...");
        Game.Probing();
    }
}