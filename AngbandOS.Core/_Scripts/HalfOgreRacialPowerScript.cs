namespace AngbandOS.Core.Scripts;

// Half-Ogres can go berserk
[Serializable]
internal class HalfOgreRacialPowerScript : Script, IScript
{
    private HalfOgreRacialPowerScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        Game.MsgPrint("Raaagh!");
        Game.FearTimer.ResetTimer();
        Game.SuperheroismTimer.AddTimer(10 + Game.DieRoll(Game.ExperienceLevel.IntValue));
        Game.RestoreHealth(30);
    }
}