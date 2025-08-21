namespace AngbandOS.Core.Scripts;
    [Serializable]
internal class SpitAcidMutationScript : UniversalScript, IGetKey
{
    private SpitAcidMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }
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