namespace AngbandOS.Core.Scripts;
internal class SpitAcidMutationScript : ActiveMutationScript
{
    private SpitAcidMutationScript(Game game) : base(game) { }
    public override string Name => "spit acid";
    protected override string? DamageExpressionText => "X";
    public override void ExecuteScript()
    {
        Game.MsgPrint("You spit acid...");
        if (Game.GetDirectionWithAim(out int dir))
        {
            Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(AcidProjectile));
            projectile.TargetedFire(dir, Game.ExperienceLevel.IntValue, 1 + (Game.ExperienceLevel.IntValue / 30), grid: true, item: true, kill: true, jump: false, beam: false, thru: true, hide: false, stop: true);
        }
    }
}