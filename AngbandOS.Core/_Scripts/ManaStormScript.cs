// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ManaStormScript : Script, IScript, ICastSpellScript
{
    private ManaStormScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Fires a ball of mana in a chosen direction.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(ManaProjectile)), dir, 300 + (Game.ExperienceLevel.IntValue * 2), 4);
    }
    public string LearnedDetails => $"dam {300 + (Game.ExperienceLevel.IntValue * 2)}";
}
