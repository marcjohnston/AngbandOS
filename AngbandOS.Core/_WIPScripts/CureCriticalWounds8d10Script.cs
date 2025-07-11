// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CureCriticalWounds8d10Script : Script, IScript, ICastSpellScript
{
    private CureCriticalWounds8d10Script(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Restores health, heals stun and bleeding.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.RestoreHealth(Game.DiceRoll(8, 10));
        Game.StunTimer.ResetTimer();
        Game.RunScript(nameof(BleedingResetTimerScript));
    }
    public string LearnedDetails => "heal 8d10";
}
