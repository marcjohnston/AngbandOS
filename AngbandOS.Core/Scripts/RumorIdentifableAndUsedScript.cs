// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RumorIdentifableAndUsedScript : Script, IReadScrollOrUseStaffScript
{
    private RumorIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public IdentifiedAndUsedResult ExecuteReadScrollOrUseStaffScript()
    {
        Game.MsgPrint("There is message on the scroll. It says:");
        Game.MsgPrint(null);
        Game.RunScript(nameof(GetRumorScript));
        return new IdentifiedAndUsedResult(true, true);
    }
}

