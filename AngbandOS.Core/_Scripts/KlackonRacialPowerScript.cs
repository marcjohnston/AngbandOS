namespace AngbandOS.Core.Scripts;

// Klackons can spit acid
[Serializable]
internal class KlackonRacialPowerScript : Script, IScript
{
    private KlackonRacialPowerScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        if (Game.GetDirectionWithAim(out int direction))
        {
            Game.MsgPrint("You spit acid.");
            if (Game.ExperienceLevel.IntValue < 25)
            {
                Game.FireBolt(Game.SingletonRepository.Get<Projectile>(nameof(AcidProjectile)), direction, Game.ExperienceLevel.IntValue);
            }
            else
            {
                Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(AcidProjectile)), direction, Game.ExperienceLevel.IntValue, 2);
            }
        }
    }
}