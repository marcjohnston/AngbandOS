// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class MageChaosBoltScript : Script, IScript, ICastSpellScript
{
    private MageChaosBoltScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Fires a bolt or a beam of chaos in a chosen direction.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        Game.FireBoltOrBeam(Game.ExperienceLevel.IntValue, Game.SingletonRepository.Get<Projectile>(nameof(ChaosProjectile)), dir, Game.DiceRoll(10 + ((Game.ExperienceLevel.IntValue - 5) / 4), 8));
    }
    public string LearnedDetails => $"dam {10 + ((Game.ExperienceLevel.IntValue - 5) / 4)}d8";
}
