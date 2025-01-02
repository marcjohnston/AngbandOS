// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DetectTreasureAndGoldScript : Script, IScript, IReadScrollAndUseStaffScript
{
    private DetectTreasureAndGoldScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteReadScrollAndUseStaffScript();
    }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public IdentifiedAndUsedResult ExecuteReadScrollAndUseStaffScript()
    {
        bool isIdentified = false;
        if (Game.DetectTreasure())
        {
            isIdentified = true;
        }
        if (Game.DetectGold())
        {
            isIdentified = true;
        }
        return new IdentifiedAndUsedResult(isIdentified, true);
    }
}
