// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ThrowScript : Script, IScript, ICastSpellScript, IGameCommandScript
{
    private ThrowScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public string LearnedDetails => "";

    /// <summary>
    /// Executes the throw script and returns false.
    /// </summary>
    /// <returns></returns>
    public RepeatableResultEnum ExecuteGameCommandScript()
    {
        ExecuteScript();
        return RepeatableResultEnum.False;
    }

    /// <summary>
    /// Executes the throw script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.DoCmdThrow(1);
    }
}
