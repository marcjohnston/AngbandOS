namespace AngbandOS.Core.Scripts;

// Half-trolls can go berserk, which also heals them
[Serializable]
internal class HalfTrollRacialPowerScript : Script, IScript
{
    private HalfTrollRacialPowerScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        Game.MsgPrint("RAAAGH!");
        Game.FearTimer.ResetTimer();
        Game.SuperheroismTimer.AddTimer(10 + Game.DieRoll(Game.ExperienceLevel.IntValue));
        Game.RestoreHealth(30);
    }
}