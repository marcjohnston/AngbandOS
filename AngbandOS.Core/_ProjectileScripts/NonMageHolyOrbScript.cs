// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class NonMageHolyOrbScript : Script, IScript, ICastSpellScript
{
    private NonMageHolyOrbScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Fires a ball of holy fire in a chosen direction.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(HolyFireProjectile)), dir, Game.DiceRoll(3, 6) + Game.ExperienceLevel.IntValue + (Game.ExperienceLevel.IntValue / 4), Game.ExperienceLevel.IntValue < 30 ? 2 : 3);
    }
    public string LearnedDetails => $"dam 3d6+{Game.ExperienceLevel.IntValue + Game.ExperienceLevel.IntValue / 4}";
}
