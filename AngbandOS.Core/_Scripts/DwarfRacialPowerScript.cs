namespace AngbandOS.Core.Scripts;

// Dwarves can detect traps, doors, and stairs
[Serializable]
internal class DwarfRacialPowerScript : Script, IScript
{
    private DwarfRacialPowerScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        Game.MsgPrint("You examine your surroundings.");
        Game.DetectTraps();
        Game.DetectDoors();
        Game.DetectStairs();
    }
}