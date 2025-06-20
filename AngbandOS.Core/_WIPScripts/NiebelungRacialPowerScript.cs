namespace AngbandOS.Core.Scripts;

// Nibelungen can detect traps, doors, and stairs
[Serializable]
internal class NiebelungRacialPowerScript : Script, IScript
{
    private NiebelungRacialPowerScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        Game.MsgPrint("You examine your surroundings.");
        Game.DetectTraps();
        Game.DetectDoors();
        Game.DetectStairs();
    }
}