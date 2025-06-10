// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RemoveAllCurseScript : Script, IScript, ICastSpellScript
{
    private RemoveAllCurseScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Removes a curse from all items including heavy curses.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.RemoveCurseAux(true);
    }
    public string LearnedDetails => "";
}
