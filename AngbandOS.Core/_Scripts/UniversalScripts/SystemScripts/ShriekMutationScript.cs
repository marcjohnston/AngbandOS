namespace AngbandOS.Core.Scripts;
    [Serializable]
internal class ShriekMutationScript : UniversalScript, IGetKey
{
    private ShriekMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }
    public override void ExecuteScript()
    {
        Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(SoundProjectile));
        projectile.TargetedFire(0, 4 * Game.ExperienceLevel.IntValue, 8, grid: true, item: true, kill: true, jump: false, beam: false, thru: true, hide: false, stop: true);
        Game.AggravateMonsters();
    }
}