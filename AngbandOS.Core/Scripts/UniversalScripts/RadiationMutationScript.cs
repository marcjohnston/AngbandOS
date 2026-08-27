namespace AngbandOS.Core.Scripts;
internal class RadiationMutationScript : ActiveMutationScript
{
    private RadiationMutationScript(Game game) : base(game) { }
    public override string Name => "produce radiation";
    public override void ExecuteScript()
    {
        Game.MsgPrint("Radiation flows from your body!");
        Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(NukeProjectile));
        projectile.TargetedFire(0, Game.ExperienceLevel.IntValue * 2, 3 + (Game.ExperienceLevel.IntValue / 20), grid: true, item: true, kill: true, jump: false, beam: false, thru: true, hide: false, stop: true);
    }
}