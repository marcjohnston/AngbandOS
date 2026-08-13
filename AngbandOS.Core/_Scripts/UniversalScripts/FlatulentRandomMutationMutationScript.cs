namespace AngbandOS.Core.Scripts;
internal class FlatulentRandomMutationMutationScript : UniversalScript, IGetKey
{
    private FlatulentRandomMutationMutationScript(Game game) : base(game) { }
    public string GetKey => throw new NotImplementedException();

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