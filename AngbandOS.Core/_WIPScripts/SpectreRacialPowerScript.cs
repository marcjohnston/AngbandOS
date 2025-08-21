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
            Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(TurnAllProjectile));
            projectile.TargetedFire(direction, Game.ExperienceLevel.IntValue, 0, stop: true, kill: true, jump: false, beam: false, grid: false, item: false, thru: true, hide: false);
        }
    }
}