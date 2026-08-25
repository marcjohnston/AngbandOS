namespace AngbandOS.Core.Scripts;
internal class LaserEyesMutationScript : ActiveMutationScript
{
    private LaserEyesMutationScript(Game game) : base(game) { }
    public override string Name => "laser eyes";
    public override void ExecuteScript()
    {
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(LightProjectile));
        projectile.TargetedFire(dir, 2 * Game.ExperienceLevel.IntValue, 0, beam: true, kill: true, jump: false, stop: false, grid: false, item: false, thru: true, hide: false);
    }
}