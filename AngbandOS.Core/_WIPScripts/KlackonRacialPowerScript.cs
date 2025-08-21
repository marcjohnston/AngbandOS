using AngbandOS.GamePacks.Cthangband;

namespace AngbandOS.Core.Scripts;

// Klackons can spit acid
[Serializable]
internal class KlackonRacialPowerScript : Script, IScript
{
    private KlackonRacialPowerScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(AcidProjectile));
        if (Game.GetDirectionWithAim(out int direction))
        {
            Game.MsgPrint("You spit acid.");
            if (Game.ExperienceLevel.IntValue < 25)
            {
                projectile.TargetedFire(direction, Game.ExperienceLevel.IntValue, 0, stop: true, kill: true, jump: false, beam: false, grid: false, item: false, thru: true, hide: false);
            }
            else
            {
                projectile.TargetedFire(direction, Game.ExperienceLevel.IntValue, 2, grid: true, item: true, kill: true, jump: false, beam: false, thru: true, hide: false, stop: true);
            }
        }
    }
}