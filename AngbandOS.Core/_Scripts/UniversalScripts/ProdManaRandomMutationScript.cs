namespace AngbandOS.Core.Scripts;
internal class ProdManaRandomMutationScript : UniversalScript, IGetKey
{
    private ProdManaRandomMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind(RestoreGameState? restoreGameState) { }

    public override void ExecuteScript()
    {
        if (Game.HasAntiMagic || base.Game.DieRoll(9000) != 1)
        {
            return;
        }
        Game.Disturb(false);
        Game.MsgPrint("Magical energy flows through you! You must release it!");
        Game.MsgPrint(string.Empty);

        // Get a direction.  We do not care if the player cancels the direction, we will release the energy anyway.
        Game.GetDirectionWithAim(out int direction);
        Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(ManaProjectile));
        projectile.TargetedFire(direction, Game.ExperienceLevel.IntValue * 2, 3, grid: true, item: true, kill: true, jump: false, beam: false, thru: true, hide: false, stop: true);
    }
}