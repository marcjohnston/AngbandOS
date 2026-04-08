// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class HighMageZapScript : Script, IScript, ICastSpellScript
{
    private HighMageZapScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        Game.FireBoltOrBeam(Game.ExperienceLevel.IntValue + 10 - 10, Game.SingletonRepository.Get<Projectile>(nameof(ElectricityProjectile)), dir, Game.DiceRoll(3 + ((Game.ExperienceLevel.IntValue - 1) / 5), 3));
    }
    public string LearnedDetails => $"dam {3 + ((Game.ExperienceLevel.IntValue - 1) / 5)}d3";
}
