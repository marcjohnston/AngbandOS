namespace AngbandOS.Core.Scripts;

// Draconians can breathe an element based on their class and level
[Serializable]
internal class DraconianRacialPowerScript : Script, IScript
{
    private DraconianRacialPowerScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        // Chance of replacing the default fire/cold element with a special one
        if (Game.DieRoll(100) < Game.ExperienceLevel.IntValue)
        {
            // Choose a racial power based on character class or default to cold/fire.
            Game.RunScript(nameof(UseRacialPowerScript));
        }
        else
        {
            Game.RunScript(RacialPower.GetCompositeKey(Game.Race, null));
        }
    }
}