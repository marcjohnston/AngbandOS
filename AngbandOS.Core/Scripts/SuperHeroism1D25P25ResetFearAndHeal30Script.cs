// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SuperHeroism1D25P25ResetFearAndHeal30Script : Script, IEatOrQuaffScript, IScript, ICastSpellScript
{
    private SuperHeroism1D25P25ResetFearAndHeal30Script(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Restores 30 points of health, removes fear and adds between 25 and 50 turns of super heroism.  Returns true, if any action is noticed; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResult ExecuteEatOrQuaffScript()
    {
        bool isIdentified = false;

        // Berserk strength removes fear, heals 30 health, and gives you timed super heroism
        if (Game.FearTimer.ResetTimer())
        {
            isIdentified = true;
        }
        if (Game.SuperheroismTimer.AddTimer(Game.DieRoll(25) + 25))
        {
            isIdentified = true;
        }
        if (Game.RestoreHealth(30))
        {
            isIdentified = true;
        }
        return new IdentifiedResult(isIdentified);
    }

    /// <summary>
    /// Runs the INoticeableScript and disposes of the result.
    /// </summary>
    public void ExecuteScript()
    {
        ExecuteEatOrQuaffScript();
    }
    public string LearnedDetails => "dur 25+d25";
}
