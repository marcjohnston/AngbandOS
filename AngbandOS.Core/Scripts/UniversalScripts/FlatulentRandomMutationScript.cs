namespace AngbandOS.Core.Scripts;
internal class FlatulentRandomMutationScript : UniversalScript, IGetKey
{
    private FlatulentRandomMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind(RestoreGameState? restoreGameState) { }

    public override void ExecuteScript()
    {
        if (base.Game.DieRoll(3000) == 13)
        {
            Game.Disturb(false);
            Game.MsgPrint("BRRAAAP! Oops.");
            Game.MsgPrint(string.Empty);
            Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(PoisonGasProjectile));
            projectile.TargetedFire(0, Game.ExperienceLevel.IntValue, 3, grid: true, item: true, kill: true, jump: false, beam: false, thru: true, hide: false, stop: true);
        }
    }
}