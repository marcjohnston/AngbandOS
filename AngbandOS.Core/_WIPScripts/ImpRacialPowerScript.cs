using AngbandOS.GamePacks.Cthangband;

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
            Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(FireProjectile));
            if (Game.ExperienceLevel.IntValue >= 30)
            {
                Game.MsgPrint("You cast a ball of fire.");
                Game.FireBall(projectile, direction, Game.ExperienceLevel.IntValue, 2);
            }
            else
            {
                Game.MsgPrint("You cast a bolt of fire.");
                projectile.TargetedFire(direction, Game.ExperienceLevel.IntValue, 0, stop: true, kill: true, jump: false, beam: false, grid: false, item: false, thru: true, hide: false);
            }
        }
    }
}