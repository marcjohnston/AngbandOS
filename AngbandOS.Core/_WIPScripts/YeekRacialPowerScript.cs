namespace AngbandOS.Core.Scripts;

// Yeeks can scream
[Serializable]
internal class YeekRacialPowerScript : Script, IScript
{
    private YeekRacialPowerScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        if (Game.GetDirectionWithAim(out int direction))
        {
            Game.MsgPrint("You make a horrible scream!");
            Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(TurnAllProjectile));
            projectile.TargetedFire(direction, Game.ExperienceLevel.IntValue, 0, stop: true, kill: true, jump: false, beam: false, grid: false, item: false, thru: true, hide: false);
        }
    }
}