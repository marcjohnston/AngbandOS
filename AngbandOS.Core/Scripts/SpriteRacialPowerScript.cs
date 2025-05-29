namespace AngbandOS.Core.Scripts;

// Sprites can sleep monsters
[Serializable]
internal class SpriteRacialPowerScript : Script, IScript
{
    private SpriteRacialPowerScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        Game.MsgPrint("You throw some magic dust...");
        if (Game.ExperienceLevel.IntValue < 25)
        {
            Game.RunScript(nameof(OldSleep1xr1ProjectileScript));
        }
        else
        {
            Game.RunScript(nameof(OldSleepAtLos1xProjectileScript));
        }
    }
}