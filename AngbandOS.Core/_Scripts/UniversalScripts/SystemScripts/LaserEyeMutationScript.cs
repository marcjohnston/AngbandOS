namespace AngbandOS.Core.Scripts;
    [Serializable]
internal class LaserEyeMutationScript : UniversalScript, IGetKey
{
    private LaserEyeMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }
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