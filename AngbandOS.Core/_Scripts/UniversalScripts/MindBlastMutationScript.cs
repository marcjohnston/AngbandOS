namespace AngbandOS.Core.Scripts;
internal class MindBlastMutationScript : ActiveMutationScript
{
    private MindBlastMutationScript(Game game) : base(game) { }
    public override string Name => "mind blast";
    public override void ExecuteScript()
    {
        Game.MsgPrint("You concentrate...");
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(PsiProjectile));
        projectile.TargetedFire(dir, base.Game.DiceRoll(3 + ((Game.ExperienceLevel.IntValue - 1) / 5), 3), 0, stop: true, kill: true, jump: false, beam: false, grid: false, item: false, thru: true, hide: false);
    }
}