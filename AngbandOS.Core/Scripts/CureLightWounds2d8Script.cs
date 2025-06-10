// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CureLightWounds2d8Script : Script, IScript, ICastSpellScript, IEatOrQuaffScript
{
    private CureLightWounds2d8Script(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the script and returns true because the action is always noticed.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResult ExecuteEatOrQuaffScript()
    {
        bool isIdentified = false;
        // Cure light wounds heals you 2d8 health and reduces bleeding
        if (Game.RestoreHealth(Game.DiceRoll(2, 8)))
        {
            isIdentified = true;
        }
        if (Game.BleedingTimer.AddTimer(-10))
        {
            isIdentified = true;
        }
        return new IdentifiedResult(isIdentified);
    }

    /// <summary>
    /// Executes the <see cref="IEatOrQuaffScript"/> script and returns nothing.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteEatOrQuaffScript();
    }
    public string LearnedDetails => "heal 2d8";    
}
