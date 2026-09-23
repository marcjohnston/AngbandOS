namespace AngbandOS.Core.Scripts;
internal class HypnoticGazeMutationScript : ActiveMutationScript
{
    private HypnoticGazeMutationScript(Game game) : base(game) { }
    public override string Name => "hypnotic gaze";
    public override void ExecuteScript()
    {
        Game.MsgPrint("Your eyes look mesmerizing...");
        if (Game.GetDirectionWithAim(out int dir))
        {
            Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(CharmProjectile));
            projectile.TargetedFire(dir, Game.ExperienceLevel.IntValue, 0, stop: true, kill: true, jump: false, beam: false, grid: false, item: false, thru: true, hide: false);
        }
    }
}