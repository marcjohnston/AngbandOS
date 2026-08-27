namespace AngbandOS.Core.Scripts;
internal class BrFireMutationScript : ActiveMutationScript
{
    private BrFireMutationScript(Game game) : base(game) { }
    public override string Name => "fire breath";
    protected override string? DamageExpressionText => "2*X";
    public override void ExecuteScript()
    {
        Game.MsgPrint("You breathe fire...");
        if (Game.GetDirectionWithAim(out int dir))
        {
            Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(FireProjectile));
            projectile.TargetedFire(dir, Game.ExperienceLevel.IntValue * 2, -(1 + (Game.ExperienceLevel.IntValue / 20)), grid: true, item: true, kill: true, jump: false, beam: false, thru: true, hide: false, stop: true);
        }
    }
}