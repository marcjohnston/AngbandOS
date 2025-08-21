// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.GamePacks.Cthangband;

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class MaledictionScript : Script, IScript, ICastSpellScript
{
    private MaledictionScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Fires a ball of hellfire in a chosen direction and 80% of the time an additional bolt of deathray (0.001% [1/1000]), turn all (50%), old confusion (30%) or stun 
    /// on a monster (20%) of the time.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(HellfireProjectile)), dir, Game.DiceRoll(3 + ((Game.ExperienceLevel.IntValue - 1) / 5), 3), 0);
        if (Game.DieRoll(5) != 1)
        {
            return;
        }
        int dummy = Game.DieRoll(1000);
        if (dummy == 666)
        {
            Projectile deathRayProjectile = Game.SingletonRepository.Get<Projectile>(nameof(DeathRayProjectile));
            deathRayProjectile.TargetedFire(dir, Game.ExperienceLevel.IntValue, 0, stop: true, kill: true, jump: false, beam: false, grid: false, item: false, thru: true, hide: false);
        }
        if (dummy < 500)
        {
            Projectile turnAllProjectile = Game.SingletonRepository.Get<Projectile>(nameof(TurnAllProjectile));
            turnAllProjectile.TargetedFire(dir, Game.ExperienceLevel.IntValue, 0, stop: true, kill: true, jump: false, beam: false, grid: false, item: false, thru: true, hide: false);
        }
        if (dummy < 800)
        {
            Projectile oldConfuseProjectile = Game.SingletonRepository.Get<Projectile>(nameof(OldConfuseProjectile));
            oldConfuseProjectile.TargetedFire(dir, Game.ExperienceLevel.IntValue, 0, stop: true, kill: true, jump: false, beam: false, grid: false, item: false, thru: true, hide: false);
        }
        Projectile stunProjectile = Game.SingletonRepository.Get<Projectile>(nameof(StunProjectile));
        stunProjectile.TargetedFire(dir, Game.ExperienceLevel.IntValue, 0, stop: true, kill: true, jump: false, beam: false, grid: false, item: false, thru: true, hide: false);
    }
    public string LearnedDetails => $"dam {3 + ((Game.ExperienceLevel.IntValue - 1) / 5)}d3";
}
