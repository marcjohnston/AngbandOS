namespace AngbandOS.Core.Scripts;

// Half-orcs can remove fear
[Serializable]
internal class HalfOrcRacialPowerScript : Script, IScript
{
    private HalfOrcRacialPowerScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        Game.MsgPrint("You play tough.");
        Game.FearTimer.ResetTimer();
    }
}