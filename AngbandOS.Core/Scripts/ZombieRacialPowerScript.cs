namespace AngbandOS.Core.Scripts;

// Skeletons and zombies can restore their life energy
[Serializable]
internal class ZombieRacialPowerScript : Script, IScript
{
    private ZombieRacialPowerScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        Game.MsgPrint("You attempt to restore your lost energies.");
        Game.RunScript(nameof(RestoreLevelScript));
    }
}