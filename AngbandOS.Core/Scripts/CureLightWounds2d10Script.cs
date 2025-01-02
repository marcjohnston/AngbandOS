// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CureLightWounds2d10Script : Script, IScript, ICastSpellScript
{
    private CureLightWounds2d10Script(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Restores health between 2 and 10 points and reduces the bleeding timer by 10 turns.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.RestoreHealth(Game.DiceRoll(2, 10));
        Game.BleedingTimer.AddTimer(-10);
    }
}
