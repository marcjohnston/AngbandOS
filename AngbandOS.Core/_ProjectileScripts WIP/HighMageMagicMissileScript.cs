// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class HighMageMagicMissileScript : Script, IScript, ICastSpellScript
{
    private HighMageMagicMissileScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Fires a bolt or beam of missle in a chosen direction.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        Game.FireBoltOrBeam(Game.ExperienceLevel.IntValue, Game.SingletonRepository.Get<Projectile>(nameof(MissileProjectile)), dir, Game.DiceRoll(3 + ((Game.ExperienceLevel.IntValue - 1) / 5), 4));
    }
    public string LearnedDetails => $"dam {3 + ((Game.ExperienceLevel.IntValue - 1) / 5)}d4";
}
