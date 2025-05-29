namespace AngbandOS.Core.Scripts;

// Golems can harden their skin
[Serializable]
internal class GolemRacialPowerScript : Script, IScript
{
    private GolemRacialPowerScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        Game.StoneskinTimer.AddTimer(Game.DieRoll(20) + 30);
    }
}