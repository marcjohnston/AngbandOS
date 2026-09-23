// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

internal class NeuralBlastTalentScript : UniversalScript, IGetKey
{
    private NeuralBlastTalentScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind(RestoreGameState? restoreGameState) { }
    public override void ExecuteScript()
    {
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        if (Game.DieRoll(100) < Game.ExperienceLevel.IntValue * 2)
        {
            Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(PsiProjectile));
            projectile.TargetedFire(dir, Game.DiceRoll(3 + ((Game.ExperienceLevel.IntValue - 1) / 4), 3 + (Game.ExperienceLevel.IntValue / 15)), 0, beam: true, kill: true, jump: false, stop: false, grid: false, item: false, thru: true, hide: false);
        }
        else
        {
            Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(PsiProjectile));
            projectile.TargetedFire(dir, Game.DiceRoll(3 + ((Game.ExperienceLevel.IntValue - 1) / 4), 3 + (Game.ExperienceLevel.IntValue / 15)), 0, grid: true, item: true, kill: true, jump: false, beam: false, thru: true, hide: false, stop: true);
        }
    }
}
