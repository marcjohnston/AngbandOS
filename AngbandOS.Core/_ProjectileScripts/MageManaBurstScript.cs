// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class MageManaBurstScript : Script, IScript, ICastSpellScript
{
    private MageManaBurstScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Fires a ball of missle in a chosen direction.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        int damage = Game.DiceRoll(3, 5) + Game.ExperienceLevel.IntValue + (Game.ExperienceLevel.IntValue / 2);
        int radius = Game.ExperienceLevel.IntValue < 30 ? 2 : 3;
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(MissileProjectile)), dir, damage, radius);
    }
    public string LearnedDetails => $"dam 3d5+{Game.ExperienceLevel.IntValue + Game.ExperienceLevel.IntValue / 2}";
}
