namespace AngbandOS.Core.Scripts;
    [Serializable]
internal class RadiationMutationScript : UniversalScript, IGetKey
{
    private RadiationMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }
    public override void ExecuteScript()
    {
        Game.MsgPrint("Radiation flows from your body!");
        Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(NukeProjectile));
        projectile.TargetedFire(0, Game.ExperienceLevel.IntValue * 2, 3 + (Game.ExperienceLevel.IntValue / 20), grid: true, item: true, kill: true, jump: false, beam: false, thru: true, hide: false, stop: true);
    }
}