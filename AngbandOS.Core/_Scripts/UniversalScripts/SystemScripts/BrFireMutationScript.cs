namespace AngbandOS.Core.Scripts;
    [Serializable]
internal class BrFireMutationScript : UniversalScript, IGetKey
{
    private BrFireMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }
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