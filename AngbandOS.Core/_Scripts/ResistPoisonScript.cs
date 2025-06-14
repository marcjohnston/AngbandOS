// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ResistPoisonScript : Script, IScript, ICastSpellScript
{
    private ResistPoisonScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Adds between 20 and 40 turns of resist poison.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.PoisonResistanceTimer.AddTimer(Game.DieRoll(20) + 20);
    }
    public string LearnedDetails => "dur 20+d20";
}
