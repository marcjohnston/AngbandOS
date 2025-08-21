namespace AngbandOS.Core.Scripts;
    [Serializable]
internal class HypnGazeMutationScript : UniversalScript, IGetKey
{
    private HypnGazeMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }
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