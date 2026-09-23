// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

internal class DominationTalentScript : UniversalScript, IGetKey
{
    private DominationTalentScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind(RestoreGameState? restoreGameState) { }
    public override void ExecuteScript()
    {
        if (Game.ExperienceLevel.IntValue < 30)
        {
            if (!Game.GetDirectionWithAim(out int dir))
            {
                return;
            }
            Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(DominationProjectile));
            projectile.TargetedFire(dir, Game.ExperienceLevel.IntValue, 0, grid: true, item: true, kill: true, jump: false, beam: false, thru: true, hide: false, stop: true);
        }
        else
        {
            Game.RunScript(nameof(ControlAnimalAtLos2xProjectileScript));
        }
    }
}
