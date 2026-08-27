namespace AngbandOS.Core.Scripts;
internal class ShriekMutationScript : ActiveMutationScript
{
    private ShriekMutationScript(Game game) : base(game) { }
    public override string Name => "shriek";
    public override void ExecuteScript()
    {
        Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(SoundProjectile));
        projectile.TargetedFire(0, 4 * Game.ExperienceLevel.IntValue, 8, grid: true, item: true, kill: true, jump: false, beam: false, thru: true, hide: false, stop: true);
        Game.AggravateMonsters();
    }
}