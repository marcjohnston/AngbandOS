// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SeeInvisible1d24p24Script : Script, IScript, ICastSpellScript
{
    private SeeInvisible1d24p24Script(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Adds between 24 and 48 turns of see invisibility.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.SeeInvisibilityTimer.AddTimer(Game.DieRoll(24) + 24);
    }
    public string LearnedDetails => "dur 24+d24";
}
