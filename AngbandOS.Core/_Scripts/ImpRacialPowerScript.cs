namespace AngbandOS.Core.Scripts;

// Imps can cast fire bolt/ball
[Serializable]
internal class ImpRacialPowerScript : Script, IScript
{
    private ImpRacialPowerScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        if (Game.GetDirectionWithAim(out int direction))
        {
            if (Game.ExperienceLevel.IntValue >= 30)
            {
                Game.MsgPrint("You cast a ball of fire.");
                Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(FireProjectile)), direction, Game.ExperienceLevel.IntValue, 2);
            }
            else
            {
                Game.MsgPrint("You cast a bolt of fire.");
                Game.FireBolt(Game.SingletonRepository.Get<Projectile>(nameof(FireProjectile)), direction, Game.ExperienceLevel.IntValue);
            }
        }
    }
}