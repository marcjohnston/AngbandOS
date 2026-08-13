namespace AngbandOS.Core.Scripts;
internal class RawChaosRandomMutationScript : UniversalScript, IGetKey
{
    private RawChaosRandomMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind(RestoreGameState? restoreGameState) { }

    public override void ExecuteScript()
    {
        if (Game.HasAntiMagic || base.Game.DieRoll(8000) != 1)
        {
            return;
        }
        Game.Disturb(false);
        Game.MsgPrint("You feel the world warping around you!");
        Game.MsgPrint(string.Empty);
        Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(ChaosProjectile));
        projectile.TargetedFire(0, Game.ExperienceLevel.IntValue, 8, grid: true, item: true, kill: true, jump: false, beam: false, thru: true, hide: false, stop: true);
    }
}