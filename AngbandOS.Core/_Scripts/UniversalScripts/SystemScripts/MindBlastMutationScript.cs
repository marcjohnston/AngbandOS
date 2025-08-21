namespace AngbandOS.Core.Scripts;
    [Serializable]
internal class MindBlastMutationScript : UniversalScript, IGetKey
{
    private MindBlastMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }
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