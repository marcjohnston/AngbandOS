namespace AngbandOS.Core.Scripts;

// Spectres can howl
[Serializable]
internal class SpectreRacialPowerScript : Script, IScript
{
    private SpectreRacialPowerScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        Game.MsgPrint("You emit an eldritch howl!");
        if (Game.GetDirectionWithAim(out int direction))
        {
            Game.ScareMonster(direction, Game.ExperienceLevel.IntValue);
        }
    }
}