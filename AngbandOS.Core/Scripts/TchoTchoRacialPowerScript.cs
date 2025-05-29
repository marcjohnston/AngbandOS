namespace AngbandOS.Core.Scripts;

// Tcho-Tcho can create The Yellow Sign
[Serializable]
internal class TchoTchoRacialPowerScript : Script, IScript
{
    private TchoTchoRacialPowerScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        Game.MsgPrint("You carefully draw The Yellow Sign...");
        Game.RunScript(nameof(YellowSignScript));
    }
}